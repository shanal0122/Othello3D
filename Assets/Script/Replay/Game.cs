using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Replay
{
  public class Game : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //オセロ盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private int language;
      private int nowTurn = 0; //今表示しているターン。初期配置は0ターン目
      private int constantTotalTurn; //合計ターン数。定数
      private string recordstr; //PlayerPrefsの"Record_of_finised_game"を格納
      private int gameMode; //PlayerPrefsの"Record_of_finished_gamemode"を格納
      private int[] turn; //nターン目が終わった後に打つ人のターンを表示する。（はじめは黒なので1）
      private int[,] squareList; //マスの情報を格納する。[ターン目,xLength * zLength * _y + xLength * _z + _x]
      private bool changeIndication = true; //trueになるとターンや手番の表示を変える
      private bool keyDetectable = true; //falseのときカメラ移動とキー入力を受け付けない（スマホ版のみ：Menu画面、Instruction画面を開いている時））
      private float stoneSize;
      public GameObject blackStone;
      public GameObject whiteStone;
      public Transform stone;
      public GameObject quitConfirmCanvas;
      public Text blackTurnText;
      public Text whiteTurnText;
      public Text blackStoneNumText;
      public Text whiteStoneNumText;
      public GameObject menuCanvas;
      public GameObject cameraSensiSlider;
      public GameObject scrollReverserButton;
      public Text scrollReverserOnOffText;
      public GameObject stoneSizeSlider;
      private AudioSource audioSource;
      public GameObject bgmVolumeSlider;
      public CameraMover cameraMover;
      public GameObject replaySlider;
      public GameObject instructionCanvas;
      private GameObject[,,] bs; //[x,y,z]にあるblackStoneを格納
      private GameObject[,,] ws; //[x,y,z]にあるwhiteStoneを格納
      public Text claimText;


      void Awake()
      {
          language = PlayerPrefs.GetInt("Value_of_Language", 0);
          swidth = Screen.width; sheight = Screen.height;
          cameraSensiSlider.GetComponent<Slider>().value = 2 * PlayerPrefs.GetFloat("Value_of_MovingSpeed", 20f) / 5;
          if(language == 0)
          {
            if(PlayerPrefs.GetInt("Value_of_ScrollReverser", 1) == 1){ scrollReverserOnOffText.text = "順方向"; }
            else{ scrollReverserOnOffText.text = "逆方向"; }
          }
          if(language == 1)
          {
            if(PlayerPrefs.GetInt("Value_of_ScrollReverser", 1) == 1){ scrollReverserOnOffText.text = "Forward"; }
            else{ scrollReverserOnOffText.text = "Reverse"; }
          }
          stoneSizeSlider.GetComponent<Slider>().value = 20 * PlayerPrefs.GetFloat("Value_of_StoneSize", 0.6f);
          stoneSize = PlayerPrefs.GetFloat("Value_of_StoneSize", 0.6f);
          stoneSizeSlider.GetComponent<Slider>().onValueChanged.AddListener(OnStoneSizeSlide);
          audioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
          bgmVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Value_of_BGMVolume", 0.5f) * 10f;
      }

      void Start()
      {
          bs = new GameObject[xLength,yLength,zLength];
          ws = new GameObject[xLength,yLength,zLength];
         for(int y=0; y<yLength; y++)
         {
           for(int z=0; z<zLength; z++)
           {
             for(int x=0; x<xLength; x++)
            {
               bs[x,y,z] = Instantiate(blackStone, stone);
               bs[x,y,z].transform.position = new Vector3(x,y,z);
               bs[x,y,z].SetActive(false);
               ws[x,y,z] = Instantiate(whiteStone, stone);
               ws[x,y,z].transform.position = new Vector3(x,y,z);
               ws[x,y,z].SetActive(false);
             }
           }
         }

         gameMode = PlayerPrefs.GetInt("Record_of_finished_gamemode");
         recordstr = PlayerPrefs.GetString("Record_of_finished_game");
         string[] strArray = recordstr.Split(',');
         constantTotalTurn = int.Parse(strArray[0]);
         turn = new int[constantTotalTurn + 1];
         squareList = new int[constantTotalTurn + 1, xLength*yLength*zLength];
         for(int t=0; t<=constantTotalTurn; t++)
         {
           turn[t] = int.Parse(strArray[(t + 1) * (xLength * yLength * zLength + 1)]);
           for(int _y=0; _y<yLength; _y++)
           {
             for(int _z=0; _z<zLength; _z++)
             {
               for(int _x=0; _x<xLength; _x++)
               {
                 squareList[t, xLength * zLength * _y + xLength * _z + _x] = int.Parse(strArray[1 + (xLength * yLength * zLength + 1) * t + xLength * zLength * _y + xLength * _z + _x]);
               }
             }
           }
         }
         Replay(0);
      }

      void Update()
      {
        if(Input.GetKeyDown(KeyCode.Backspace)){ OnBackClick(); }
        if(Input.GetKeyDown(KeyCode.Return)){ OnAheadClick(); }
        if(changeIndication)
        {
          NowTurnIndicate();
          TurnIndicate();
          StoneNumIndicate() ;
          changeIndication = false;
        }
      }


      private void Replay(int tr) //trターン目の盤面を表示する
      {
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              if(squareList[nowTurn, xLength * zLength * y + xLength * z + x] == 1)
              {
                bs[x,y,z].SetActive(false);
              }
              if(squareList[nowTurn, xLength * zLength * y + xLength * z + x] == -1)
              {
                ws[x,y,z].SetActive(false);
              }
              if(squareList[tr, xLength * zLength * y + xLength * z + x] == 1)
              {
                bs[x,y,z].SetActive(true);
              }
              if(squareList[tr, xLength * zLength * y + xLength * z + x] == -1)
              {
                ws[x,y,z].SetActive(true);
              }
            }
          }
        }
        nowTurn = tr;
      }

      private void NowTurnIndicate() //現在のターンをclaimTextに表示
      {
        if(language == 0){ claimText.text = nowTurn + " 手目"; }
        if(language == 1){ claimText.text = "Turn : " + nowTurn; }

      }

      private void TurnIndicate() //テキストにターンを表示する
      {
        if(language == 0)
        {
          if(gameMode == 1 || gameMode == 2)
          {
            int t = turn[nowTurn];
            if(nowTurn == constantTotalTurn)
            {
              blackTurnText.text = "";
              whiteTurnText.text = "";
            }else if(t == 1)
            {
              blackTurnText.text = "あなたの番です";
              whiteTurnText.text = "相手の番です";
            }else if(t == -1)
            {
              blackTurnText.text = "相手の番です";
              whiteTurnText.text = "あなたの番です";
            }
          }
          if(gameMode == 3 || gameMode == 4)
          {
            int t = turn[nowTurn];
            if(nowTurn == constantTotalTurn)
            {
              blackTurnText.text = "";
              whiteTurnText.text = "";
            }else if(t == 1)
            {
              blackTurnText.text = "あなたの番です";
              whiteTurnText.text = "CPU";
            }else if(t == -1)
            {
              blackTurnText.text = "あなた";
              whiteTurnText.text = "CPUの番です";
            }
          }
        }
        if(language == 1)
        {
          if(gameMode == 1 || gameMode == 2)
          {
            int t = turn[nowTurn];
            if(nowTurn == constantTotalTurn)
            {
              blackTurnText.text = "";
              whiteTurnText.text = "";
            }else if(t == 1)
            {
              blackTurnText.text = "your turn";
              whiteTurnText.text = "opponent's turn";
            }else if(t == -1)
            {
              blackTurnText.text = "opponent's turn";
              whiteTurnText.text = "your turn";
            }
          }
          if(gameMode == 3 || gameMode == 4)
          {
            int t = turn[nowTurn];
            if(nowTurn == constantTotalTurn)
            {
              blackTurnText.text = "";
              whiteTurnText.text = "";
            }else if(t == 1)
            {
              blackTurnText.text = "your turn";
              whiteTurnText.text = "CPU";
            }else if(t == -1)
            {
              blackTurnText.text = "you";
              whiteTurnText.text = "CPU's turn";
            }
          }
        }
      }

      private void DefStoneSize()
      {
        blackStone.transform.localScale = new Vector3(stoneSize, stoneSize, stoneSize);
        whiteStone.transform.localScale = new Vector3(stoneSize, stoneSize, stoneSize);
      }

      public void StoneNumIndicate() //テキストに現在のターンの各色の石の数を表示する
      {
        int bl = CountStone(1);
        blackStoneNumText.text = bl.ToString();
        int wh = CountStone(-1);
        whiteStoneNumText.text = wh.ToString();
      }

      public int CountStone(int stone) //現在のターンに盤上にあるstoneの数を数える
      {
        int stoneNum = 0;
        for(int n=0; n<xLength*yLength*zLength; n++)
        {
          if(squareList[nowTurn, n] == stone) {stoneNum++;}
        }
        if(stone != 1 && stone != -1)
        {
          Debug.Log("Error : Stone/CountStone");//////////////////////////////////////////////////////////////////////////////////////
        }
        return stoneNum;
      }

      public void ChangeStoneSize()
      {
        DefStoneSize();
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              if(bs[x,y,z] != null){ Destroy(bs[x,y,z]); }
              if(ws[x,y,z] != null){ Destroy(ws[x,y,z]); }
              bs[x,y,z] = Instantiate(blackStone, this.transform);
              bs[x,y,z].transform.position = new Vector3(x,y,z);
              bs[x,y,z].SetActive(false);
              ws[x,y,z] = Instantiate(whiteStone, this.transform);
              ws[x,y,z].transform.position = new Vector3(x,y,z);
              ws[x,y,z].SetActive(false);
              Replay(nowTurn);
            }
          }
        }
      }

      public void OnBackClick()
      {
        if(nowTurn > 0)
        {
          Replay(nowTurn-1);
        }
        replaySlider.GetComponent<Slider>().value = (float)nowTurn / constantTotalTurn;
        changeIndication = true;
      }

      public void OnAheadClick()
      {
        if(nowTurn < constantTotalTurn)
        {
          Replay(nowTurn+1);
        }
        replaySlider.GetComponent<Slider>().value = (float)nowTurn / constantTotalTurn;
        changeIndication = true;
      }

      public void OnMenuClick() //Menuボタンを押した時メニューウィンドウを表示させる。
      {
        menuCanvas.GetComponent<Canvas>().enabled = true;
        if(swidth <= sheight){ keyDetectable = false; }
      }

      public void OnMenuCloseClick() //メニューウィンドウのバツボタンを押した時メニューウィンドウを消す
      {
        menuCanvas.GetComponent<Canvas>().enabled = false;
        if(swidth <= sheight){ keyDetectable = true; }
      }

      public void OnCameraSensiSlide() //カメラ感度のスライダーの値を取得
      {
        cameraMover.MovingSpeed = 5 * cameraSensiSlider.GetComponent<Slider>().value / 2;
        PlayerPrefs.SetFloat("Value_of_MovingSpeed", cameraMover.MovingSpeed);
        PlayerPrefs.Save();
      }

      public void OnScrollReverseClick() //スクロール反転の値を取得
      {
        int s;
        if(cameraMover.ScrollReverser == 0){ s=1; } else{ s=0; } //ScrollReverserが1（順方向）の時に押すと0（逆方向）になるのでsは0
        cameraMover.ScrollReverser = s;
        PlayerPrefs.SetInt("Value_of_ScrollReverser", s);
        PlayerPrefs.Save();
        if(language == 0)
        {
          if(s == 1){ scrollReverserOnOffText.text = "順方向"; } else{ scrollReverserOnOffText.text = "逆方向"; }
        }
        if(language == 1)
        {
          if(s == 1){ scrollReverserOnOffText.text = "Forward"; } else{ scrollReverserOnOffText.text = "Reverse"; }
        }
      }

      public void OnStoneSizeSlide(float value) //石のサイズのスライダーの値を取得
      {
        stoneSize = stoneSizeSlider.GetComponent<Slider>().value / 20;
        PlayerPrefs.SetFloat("Value_of_StoneSize", stoneSize);
        PlayerPrefs.Save();
        ChangeStoneSize();
      }

      public void OnBGMVolumeSlide() //BGMの音量のスライダーの値を取得
      {
        audioSource.volume = bgmVolumeSlider.GetComponent<Slider>().value / 10;
        PlayerPrefs.SetFloat("Value_of_BGMVolume", audioSource.volume);
        PlayerPrefs.Save();
      }


      public void OnInstructionClick() //操作方法ボタンを押した時操作方法ウィンドウを表示させる
      {
        instructionCanvas.GetComponent<Canvas>().enabled = true;
        menuCanvas.GetComponent<Canvas>().enabled = false;
        if(swidth <= sheight){ keyDetectable = false; }
      }

      public void OnInstructionCloseClick() //操作方法ウィンドウのバツボタンを押した時操作方法ウィンドウを消す
      {
        instructionCanvas.GetComponent<Canvas>().enabled = false;
        if(swidth <= sheight){ keyDetectable = true; }
      }

      public void OnLoadTitleClick()
      {
        quitConfirmCanvas.GetComponent<Canvas>().enabled = true;
      }

      public void OnQuitYesClick()
      {
        quitConfirmCanvas.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene("Choose");
      }

      public void OnQuitNoClick()
      {
        quitConfirmCanvas.GetComponent<Canvas>().enabled = false;
      }

      public void OnReplaySlide()
      {
        int tr = Mathf.FloorToInt(constantTotalTurn * replaySlider.GetComponent<Slider>().value);
        Replay(tr);
        changeIndication = true;
      }


      public bool KeyDetectable{ get {return keyDetectable;} set {keyDetectable = value;}}
  }
}
