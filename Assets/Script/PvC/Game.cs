using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvC
{
  public class Game : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //オセロ盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private bool putableInform; //置く場所を光らせるならtrue。（Menu画面で変更可能）
      private string recordstr; //PlayerPrefsにセーブするためのマスの情報（中断後再開機能、リプレイ機能）"totalTurn,squareList[0,0],squareList[0,1],...,squareList[0,63],0ターン目の後に打つ人のターン"
      private string recordOfSuspendedKeyName; //PlayerPrefsにセーブするためのマスの情報のキーの名前（中断後再開機能）
      private int totalTurn = 0; //現在の累計ターン数を表す（待った（、リプレイ機能））
      private Vector3 standard; //CoordinateDisplayクラスのテキストの向きを定めるために用いる
      private int turn = 1; //黒が1、白が-1。先行は黒
      private int playerTurn = Choose.InitialSetting.playerTurn; //プレイヤーの手番
      private bool keyDetectable = true; //falseのときカメラ移動とキー入力を受け付けない（ゲームセット時）
      private bool gameSetFlug = false; //CanPut()でどちらも置けないことがわかるとtrueになり、処理が終わるとゲームセット画面に移る
      public int XCoordi {get; set;}
      public int YCoordi {get; set;}
      public int ZCoordi {get; set;}
      private bool beforePressed,afterXPressed, afterZPressed, afterYPressed, enterPressed; //オセロ盤の状態を管理するための変数
      public CameraMover cameraMover;
      public Stone stone;
      public ChangeColor changeColor;
      public KeyDetector keyDetector;
      public CoordiDisplay coordiDisplay;
      public InfoDisplay infoDisplay;
      public Computer computer;
      public GameObject centerCanvas;
      public GameObject saveConfirmCanvas;


      void Awake()
      {
        putableInform = PlayerPrefs.GetFloat("Value_of_PutableInform", 1)==1 ? true: false;
        recordOfSuspendedKeyName = "Record_of_supended_game_" + Choose.InitialSetting.gameMode;
      }

      void Start()
      {
          standard = new Vector3 (xLength-1f, yLength-1f, zLength-1f);
          if(Choose.InitialSetting.continuation)
          {
            ContinueGame();
          }else{NewGame();}
      }

      void Update()
      {
        if(keyDetectable)
        {
          if(turn == playerTurn)
          {
            keyDetector.NumKeyDetect();
            keyDetector.BackSpaceDetect();
            PlayGame();
          }
          else
          {
            Invoke("CPUPlay", 0.1f);
            keyDetectable = false;
          }
        }
        foreach(GameObject display in GameObject.FindGameObjectsWithTag("CoordinateDisplay")) //CoordinateDisplayクラスのテキストの向きを定める
        {
          display.transform.LookAt(standard - cameraMover.MainCameraTransformPosition,Vector3.up);
        }
      }


      private void NewGame()
      {
        int a = xLength/2; int b = yLength/2; int c = zLength/2;
        stone.PutStone(1,a-1,b-1,c-1);
        stone.PutStone(1,a,b-1,c);
        stone.PutStone(-1,a-1,b-1,c);
        stone.PutStone(-1,a,b-1,c-1);
        stone.PutStone(1,a-1,b,c);
        stone.PutStone(1,a,b,c-1);
        stone.PutStone(-1,a-1,b,c-1);
        stone.PutStone(-1,a,b,c);
        CanPut();

　　　　　　recordstr = "0"; //"totalTurn"
        for(int _y=0; _y<yLength; _y++) //待った機能、セーブのための情報の格納
        {
          for(int _z=0; _z<zLength; _z++)
          {
            for(int _x=0; _x<xLength; _x++)
            {
              recordstr = recordstr + "," + stone.Square[_x,_y,_z];
            }
          }
        }
        recordstr = recordstr + "," + 1; //"0ターン目が終わった後に打つ人のターン（黒）"
        PlayerPrefs.SetString(recordOfSuspendedKeyName, recordstr);
        PlayerPrefs.Save();
        infoDisplay.StoneNumIndicate();
      }

      private void ContinueGame()
      {
        Choose.InitialSetting.continuation = false;
        recordstr = PlayerPrefs.GetString(recordOfSuspendedKeyName);
        string[] strArray = recordstr.Split(',');
        totalTurn = int.Parse(strArray[0]);
        turn = int.Parse(strArray[(totalTurn + 1) * (xLength * yLength * zLength + 1)]);
        for(int _y=0; _y<yLength; _y++)
        {
          for(int _z=0; _z<zLength; _z++)
          {
            for(int _x=0; _x<xLength; _x++)
            {
              stone.Square[_x, _y, _z] = int.Parse(strArray[1 + (xLength * yLength * zLength + 1) * totalTurn + xLength * zLength * _y + xLength * _z + _x]);
              if(stone.Square[_x,_y,_z] == 1 || stone.Square[_x,_y,_z] == -1)
              {
                stone.PutStone(stone.Square[_x,_y,_z],_x,_y,_z);
              }
            }
          }
        }
        infoDisplay.StoneNumIndicate();
      }

      private void PlayGame() //KeyDetectorクラスから1~4とbackspaceのキー操作情報を受け取り、UIを変更し石を置く
      {
          if(XCoordi == 0 && ZCoordi == 0 && YCoordi == 0 && beforePressed == false)
          {
              BeforePressed();
          }
          else if(XCoordi != 0 && ZCoordi == 0 && YCoordi == 0 && afterXPressed == false)
          {
              AfterXPressed();
          }else if(ZCoordi != 0 && YCoordi == 0 && afterZPressed == false)
          {
              AfterZPressed();
          }else if(YCoordi != 0 && afterYPressed == false)
          {
              AfterYPressed();
          }else if(enterPressed == true)
          {
              AfterEnterPressed();
          }
      }

      private void BeforePressed() //キーを押す前に一度だけ実行される
      {
        changeColor.UndoAllBoardColor();
        if(putableInform)
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
        coordiDisplay.BeforePressedIndicate();
        beforePressed = true;
        afterXPressed = false;
      }

      private void AfterXPressed() //x座標を確定した後に一度だけ実行される
      {
        changeColor.UndoAllBoardColor();
        for(int y=0; y<yLength; y++)
        {
            for(int z=0; z<zLength; z++)
            {
                changeColor.ShineBoardColor(XCoordi-1,y,z);
                if(putableInform) {stone.Inform(turn,XCoordi-1,y,z);}
            }
        }
        coordiDisplay.AfterXPressedIndicate();
        beforePressed = false;
        afterXPressed = true;
        afterZPressed = false;
      }

      private void AfterZPressed() //z座標を確定した後に一度だけ実行される
      {
        changeColor.UndoAllBoardColor();
        for(int y=0; y<yLength; y++)
        {
            changeColor.ShineBoardColor(XCoordi-1,y,ZCoordi-1);
            if(putableInform) {stone.Inform(turn,XCoordi-1,y,ZCoordi-1);}
        }
        coordiDisplay.AfterZPressedIndicate();
        infoDisplay.StonePlusNumClear(turn);
        afterXPressed = false;
        afterZPressed = true;
        afterYPressed = false;
      }

      private void AfterYPressed() //y座標を確定した後に一度だけ実行される
      {
        changeColor.UndoAllBoardColor();
        changeColor.ShineBoardColor(XCoordi-1,YCoordi-1,ZCoordi-1);
        if(putableInform) {stone.Inform(turn,XCoordi-1,YCoordi-1,ZCoordi-1);}
        coordiDisplay.AfterYPressedDisplay();
        infoDisplay.StonePlusNumIndicate(turn,XCoordi-1,YCoordi-1,ZCoordi-1);
        afterZPressed = false;
        afterYPressed = true;
      }

      private void AfterEnterPressed() //エンターキーを押した後に一度だけ実行される
      {
        keyDetectable = false;
        infoDisplay.StonePlusNumClear(turn);
        bool putted = stone.FlipStone(turn,XCoordi-1,YCoordi-1,ZCoordi-1); //石が置けたならtrue、置けなかったならfalseが返される
        if(putted)
        {
          turn *= -1;
          CanPut();
          totalTurn++; //待った機能、セーブのための情報の格納
          string[] strArray = recordstr.Split(',');
          strArray[0] = totalTurn.ToString();
          recordstr = strArray[0];
          for(int n=1; n<strArray.Length; n++)
          {
            recordstr = recordstr + "," + strArray[n];
          }
          for(int _y=0; _y<yLength; _y++)
          {
            for(int _z=0; _z<zLength; _z++)
            {
              for(int _x=0; _x<xLength; _x++)
              {
                recordstr = recordstr + "," + stone.Square[_x,_y,_z];
              }
            }
          }
          recordstr = recordstr + "," + turn;
          PlayerPrefs.SetString(recordOfSuspendedKeyName, recordstr);
          PlayerPrefs.Save();
          infoDisplay.StoneNumIndicate();
        }else{infoDisplay.CantPutIndicate();}
        afterYPressed = false;
        XCoordi = YCoordi = ZCoordi = 0;
        enterPressed = false;
        keyDetectable = true;
        if(gameSetFlug){ GameSet(); }
      }

      private void CPUPlay()
      {
        if(turn == 1) /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
          if(Choose.InitialSetting.CPUBlack == 1){ computer.CPU1(); }
          if(Choose.InitialSetting.CPUBlack == 2){ computer.CPU2(); }
        }else if(turn == -1)
        {
          if(Choose.InitialSetting.CPUWhite == 1){ computer.CPU1(); }
          if(Choose.InitialSetting.CPUWhite == 2){ computer.CPU2(); }
        }else{ Debug.Log("Error : Game.CPUPlay"); } //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        turn *= -1;
        CanPut();
        totalTurn++;
        string[] strArray = recordstr.Split(',');
        strArray[0] = totalTurn.ToString();
        recordstr = strArray[0];
        for(int n=1; n<strArray.Length; n++)
        {
          recordstr = recordstr + "," + strArray[n];
        }
        for(int _y=0; _y<yLength; _y++)
        {
          for(int _z=0; _z<zLength; _z++)
          {
            for(int _x=0; _x<xLength; _x++)
            {
              recordstr = recordstr + "," + stone.Square[_x,_y,_z];
            }
          }
        }
        recordstr = recordstr + "," + turn;
        PlayerPrefs.SetString(recordOfSuspendedKeyName, recordstr);
        PlayerPrefs.Save();
        infoDisplay.StoneNumIndicate();
        keyDetectable = true;
        if(gameSetFlug){ GameSet(); }
      }


      private void CanPut() //置く場所がなければパスしたりリザルト画面を表示したりする。putableInformがtrueなら置ける場所を光らせる
      {
        bool canPut = stone.CanPut(turn);
        if(!canPut)
        {
            canPut = stone.CanPut(-1*turn);
            if(canPut)
            {
              infoDisplay.PassedIndicate(turn);
              turn *= -1;
            }else
            {
              gameSetFlug = true;
            }
        }
      }

      private void GameSet()
      {
        keyDetectable = false;
        changeColor.UndoAllBoardColor();
        centerCanvas.GetComponent<Canvas>().enabled = true;
        saveConfirmCanvas.GetComponent<Canvas>().enabled = true;
        infoDisplay.ResultIndicate();
        PlayerPrefs.DeleteKey(recordOfSuspendedKeyName);
      }

      public string Recordstr{ get {return recordstr;} set {this.recordstr = value;} }

      public string RecordOfSuspendedKeyName{ get {return recordOfSuspendedKeyName;} set {this.recordOfSuspendedKeyName = value;} }

      public int TotalTurn{ get {return totalTurn;} set {this.totalTurn = value;} }

      public int Turn{ get {return turn;} set {this.turn = value;} }

      public bool KeyDetectable{ get {return keyDetectable;} set {keyDetectable = value;}}

      public bool SetBeforePressed{ get {return beforePressed;} set {beforePressed = value;} }

      public bool SetAfterXPressed{ get {return afterXPressed;} set {afterXPressed = value;} }

      public bool SetAfterYPressed{ get {return afterYPressed;} set {afterYPressed = value;} }

      public bool SetAfterZPressed{ get {return afterZPressed;} set {afterZPressed = value;} }

      public bool SetEnterPressed{ get {return enterPressed;} set {enterPressed = value;} }

      public bool PutableInform{ get {return putableInform;} set {this.putableInform = value;} }
  }

}
