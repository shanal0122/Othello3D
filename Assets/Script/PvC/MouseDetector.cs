using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PvC
{
  public class MouseDetector : MonoBehaviour
  {
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private int xLength = Choose.InitialSetting.xLength; //オセロ盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private int language;
      private int playerTurn = Choose.InitialSetting.playerTurn; //プレイヤーの手番
      private string recordOfSuspendedKeyName; //PlayerPrefsにセーブするためのマスの情報のキーの名前（中断後再開機能）
      public Stone stone;
      public Game game;
      public InfoDisplay infoDisplay;
      public ChangeColor changeColor;
      public GameObject menuCanvas;
      public GameObject cameraSensiSlider;
      public CameraMover cameraMover;
      public GameObject scrollReverserButton;
      public Text scrollReverserOnOffText;
      public GameObject putableButton;
      public Text putableOnOffText;
      public GameObject stoneSizeSlider;
      private AudioSource audioSource;
      public GameObject bgmVolumeSlider;
      public GameObject instructionCanvas1;
      public GameObject instructionCanvas2;
      public GameObject saveConfirmCanvas;
      public GameObject quitConfirmCanvas;


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
          if(language == 0)
          {
            if(PlayerPrefs.GetFloat("Value_of_PutableInform", 1) == 1){ putableOnOffText.text = "オン"; }
            else{ putableOnOffText.text = "オフ"; }
          }
          if(language == 1)
          {
            if(PlayerPrefs.GetFloat("Value_of_PutableInform", 1) == 1){ putableOnOffText.text = "On"; }
            else{ putableOnOffText.text = "Off"; }
          }
          stoneSizeSlider.GetComponent<Slider>().value = 20 * PlayerPrefs.GetFloat("Value_of_StoneSize", 0.6f);
          stoneSizeSlider.GetComponent<Slider>().onValueChanged.AddListener(OnStoneSizeSlide);
          audioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
          bgmVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Value_of_BGMVolume", 0.5f) * 10f;
          recordOfSuspendedKeyName = "Record_of_supended_game_" + Choose.InitialSetting.gameMode;
      }


      public void OnCancelClick() //待ったを押した時の処理。CameraMover.csのsquareListにリプレイ情報を格納している
      {
        if(game.TotalTurn > 0 && game.KeyDetectable && playerTurn * playerTurn == 1)
        {
          stone.PutAllStoneAsList(); //game.totalTurn、game.Turnはこの先で変更している
          changeColor.UndoAllSphereColor();
          infoDisplay.StoneNumIndicate();
          game.XCoordi = game.YCoordi = game.ZCoordi = 0;
          game.SetBeforePressed = false;
          game.SetAfterXPressed = false;
          game.SetAfterZPressed = false;
          game.SetAfterYPressed = false;
          game.SetEnterPressed = false;
        }
      }

      public void OnMenuClick() //Menuボタンを押した時メニューウィンドウを表示させる。
      {
        menuCanvas.GetComponent<Canvas>().enabled = true;
        if(swidth <= sheight){ game.KeyDetectable = false; game.CameraDetectable = false; }
      }

      public void OnMenuCloseClick() //メニューウィンドウのバツボタンを押した時メニューウィンドウを消す
      {
        menuCanvas.GetComponent<Canvas>().enabled = false;
        if(swidth <= sheight){ game.KeyDetectable = true; game.CameraDetectable = true; }
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

      public void OnPutableClick() //お助け機能の値を取得
      {
        float s;
        if(game.PutableInform){ s = 0; } //putableInformがtrueの時に押すとfalseになるのでsは0
        else{ s = 1; }
        PlayerPrefs.SetFloat("Value_of_PutableInform", s);
        PlayerPrefs.Save();
        if(s == 0)
        {
            game.PutableInform = false;
            if(language == 0){ putableOnOffText.text = "オフ"; }
            if(language == 1){ putableOnOffText.text = "Off"; }
            changeColor.UndoAllBoardColor();
            if(game.XCoordi == 0 && game.ZCoordi == 0 && game.YCoordi == 0)
            {

            }
            else if(game.ZCoordi == 0 && game.YCoordi == 0)
            {
                for(int y=0; y<yLength; y++)
                {
                    for(int z=0; z<zLength; z++)
                    {
                        changeColor.ShineBoardColor(game.XCoordi-1,y,z);
                    }
                }
            }else if(game.YCoordi == 0)
            {
                for(int y=0; y<yLength; y++)
                {
                    changeColor.ShineBoardColor(game.XCoordi-1,y,game.ZCoordi-1);
                }
            }else
            {
                changeColor.ShineBoardColor(game.XCoordi-1,game.YCoordi-1,game.ZCoordi-1);
            }
        }
        if(s == 1)
        {
            int turn = game.Turn;
            game.PutableInform = true;
            if(language == 0){ putableOnOffText.text = "オン"; }
            if(language == 1){ putableOnOffText.text = "On"; }
            if(game.XCoordi == 0 && game.ZCoordi == 0 && game.YCoordi == 0)
            {
                for(int y=0; y<yLength; y++)
                {
                  for(int z=0; z<zLength; z++)
                  {
                    for(int x=0; x<xLength; x++)
                    {
                      stone.Inform(turn,x,y,z);
                    }
                  }
                }
            }
            else if(game.ZCoordi == 0 && game.YCoordi == 0)
            {
                for(int y=0; y<yLength; y++)
                {
                    for(int z=0; z<zLength; z++)
                    {
                        stone.Inform(turn,game.XCoordi-1,y,z);
                    }
                }
            }else if(game.YCoordi == 0)
            {
                for(int y=0; y<yLength; y++)
                {
                    stone.Inform(turn,game.XCoordi-1,y,game.ZCoordi-1);
                }
            }else
            {
                stone.Inform(turn,game.XCoordi-1,game.YCoordi-1,game.ZCoordi-1);
            }
        }
      }

      public void OnStoneSizeSlide(float value) //石のサイズのスライダーの値を取得
      {
        stone.StoneSize = stoneSizeSlider.GetComponent<Slider>().value / 20;
        PlayerPrefs.SetFloat("Value_of_StoneSize", stone.StoneSize);
        PlayerPrefs.Save();
        stone.ChangeStoneSize();
      }

      public void OnBGMVolumeSlide() //BGMの音量のスライダーの値を取得
      {
        audioSource.volume = bgmVolumeSlider.GetComponent<Slider>().value / 10;
        PlayerPrefs.SetFloat("Value_of_BGMVolume", audioSource.volume);
        PlayerPrefs.Save();
      }

      public void OnInstructionClick() //操作方法ボタンを押した時操作方法ウィンドウを表示させる
      {
        instructionCanvas1.GetComponent<Canvas>().enabled = true;
        menuCanvas.GetComponent<Canvas>().enabled = false;
        if(swidth <= sheight){ game.KeyDetectable = false; game.CameraDetectable = false; }
      }

      public void OnInstructionCloseClick() //操作方法ウィンドウのバツボタンを押した時操作方法ウィンドウを消す
      {
        instructionCanvas1.GetComponent<Canvas>().enabled = false;
        instructionCanvas2.GetComponent<Canvas>().enabled = false;
        if(swidth <= sheight){ game.KeyDetectable = true; game.CameraDetectable = true; }
      }

      public void OnInstructionNextClick() //操作方法ボタンの次ページへを押した時次のページを表示させる
      {
        instructionCanvas1.GetComponent<Canvas>().enabled = false;
        instructionCanvas2.GetComponent<Canvas>().enabled = true;
      }

      public void OnInstructionPrevClick() //操作方法ボタンの前ページへを押した時前のページを表示させる
      {
        instructionCanvas2.GetComponent<Canvas>().enabled = false;
        instructionCanvas1.GetComponent<Canvas>().enabled = true;
      }

      public void OnLoadTitleClick()
      {
        quitConfirmCanvas.GetComponent<Canvas>().enabled = true;
      }

      public void OnSaveYesClick()
      {
        PlayerPrefs.SetInt("Record_of_finished_gamemode", Choose.InitialSetting.gameMode);
        PlayerPrefs.SetString("Record_of_finished_game", game.Recordstr);
        saveConfirmCanvas.GetComponent<Canvas>().enabled = false;
      }

      public void OnSaveNoClick()
      {
        saveConfirmCanvas.GetComponent<Canvas>().enabled = false;
      }

      public void OnQuitYesClick()
      {
        quitConfirmCanvas.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene("Choose");
        if(game.GameSetFlug == true){ PlayerPrefs.DeleteKey(recordOfSuspendedKeyName); }
      }

      public void OnQuitNoClick()
      {
        quitConfirmCanvas.GetComponent<Canvas>().enabled = false;
      }

      public void OnPlayAgainClick()
      {
        SceneManager.LoadScene("PvC");
      }
  }
}
