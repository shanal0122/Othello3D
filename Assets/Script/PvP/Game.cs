using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP
{
  public class Game : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //オセロ盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private bool putableInform = true; //置く場所を光らせるならtrue。（Menu画面で変更可能）
      public static int[,] squareList; //待った機能のためにマスの情報を格納する。
      private int totalTurn = 0; //待った機能のための情報の格納に用いる。現在の累計ターン数を表す
      private Vector3 standard; //CoordinateDisplayクラスのテキストの向きを定めるために用いる
      private int turn = 1; //ターン入れ替えは"Stone/FlipStone"で行っている
      private bool keyDetectable = true; //falseのときカメラ移動とキー入力を受け付けない（ゲームセット時、Menuを開いた時）
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
      public GameObject centerCanvas;


      void Start()
      {
        squareList = new int[xLength*yLength*zLength-7,xLength*yLength*zLength];
        standard = new Vector3 (xLength-1f, yLength-1f, zLength-1f);
        int a = xLength/2; int b = yLength/2; int c = zLength/2;
        stone.PutStone(1,a-1,b-1,c-1);
        stone.PutStone(1,a,b-1,c);
        stone.PutStone(-1,a-1,b-1,c);
        stone.PutStone(-1,a,b-1,c-1);
        stone.PutStone(1,a-1,b,c);
        stone.PutStone(1,a,b,c-1);
        stone.PutStone(-1,a-1,b,c-1);
        stone.PutStone(-1,a,b,c);

        for(int _y=0; _y<yLength; _y++) //待った機能のための情報の格納
        {
          for(int _z=0; _z<zLength; _z++)
          {
            for(int _x=0; _x<xLength; _x++)
            {
              squareList[0, xLength * zLength * _y + xLength * _z + _x] = stone.Square[_x,_y,_z];
            }
          }
        }
      }

      void Update()
      {
        if(keyDetectable)
        {
          keyDetector.NumKeyDetect();
          keyDetector.BackSpaceDetect();
          PlayGame();
          foreach(GameObject display in GameObject.FindGameObjectsWithTag("CoordinateDisplay")) //CoordinateDisplayクラスのテキストの向きを定める
          {
            display.transform.LookAt(standard - cameraMover.MainCameraTransformPosition,Vector3.up);
          }
        }
      }


      private void PlayGame() //KeyDetectorクラスから1~4とbackspaceのキー操作情報を受け取り、UIを変更し石を置く
      {
          if(XCoordi == 0 && ZCoordi == 0 && YCoordi == 0 && beforePressed== false)
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
          CanPutAndInform();
        }else { CanPut(); }
        coordiDisplay.BeforePressedIndicate();
        infoDisplay.TurnIndicate();
        infoDisplay.StoneNumIndicate();
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
        afterZPressed = false;
        afterYPressed = true;
      }

      private void AfterEnterPressed() //エンターキーを押した後に一度だけ実行される
      {
        stone.FlipStone(turn,XCoordi-1,YCoordi-1,ZCoordi-1); //ここでturnを変更している
        CanPut();
        afterYPressed= false;
        XCoordi = YCoordi = ZCoordi = 0;
        enterPressed = false;
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
              GameSet();
            }
        }
      }

      private void CanPutAndInform() //置く場所がなければパスしたりリザルト画面を表示したりする。putableInformがtrueなら置ける場所を光らせる
      {
        bool canPut = stone.CanPutAndInform(turn);
        if(!canPut)
        {
            canPut = stone.CanPutAndInform(-1*turn);
            if(canPut)
            {
              infoDisplay.PassedIndicate(turn);
              turn *= -1;
            }else
            {
              GameSet();
            }
        }
      }

      public void GameSet()
      {
        keyDetectable = false;
        centerCanvas.GetComponent<Canvas>().enabled = true;
        infoDisplay.ResultIndicate();

      }

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
