using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP444
{
  public class Game : MonoBehaviour
  {
      private bool putableInform = true; //置く場所を光らせるならtrue。（Menu画面で変更可能）//////////////////////////////////////////////////////////////まだ未完成
      public static List<int[]> squareList = new List<int[]>(); //待った機能のためにマスの情報を格納する
      public static int totalTurn = 0; //待った機能のための情報の格納に用いる。現在の累計ターン数を表す
      private Vector3 standard; //CoordinateDisplayクラスのテキストの向きを定めるために用いる
      private int turn = 1; //ターン入れ替えは"StoneXXX/FlipStone"で行っている
      private bool keyDetectable = true; //falseのときカメラ移動とキー入力を受け付けない
      public int XCoordi {get; set;}
      public int YCoordi {get; set;}
      public int ZCoordi {get; set;}
      private bool beforePressed,afterXPressed, afterZPressed, afterYPressed, enterPressed; //オセロ盤の状態を管理するための変数
      public GameObject mainCamera;
      public GameObject stones;
      public GameObject colorManager;
      public GameObject keyDetector;
      public GameObject coordiDisplay;
      public GameObject infoDisplay;
      public GameObject centerCanvas;


      void Start()
      {
        standard = new Vector3 (3,3,3);
        stones.GetComponent<Stone>().PutStone(1,1,1,1);
        stones.GetComponent<Stone>().PutStone(1,2,1,2);
        stones.GetComponent<Stone>().PutStone(-1,1,1,2);
        stones.GetComponent<Stone>().PutStone(-1,2,1,1);
        stones.GetComponent<Stone>().PutStone(1,1,2,2);
        stones.GetComponent<Stone>().PutStone(1,2,2,1);
        stones.GetComponent<Stone>().PutStone(-1,1,2,1);
        stones.GetComponent<Stone>().PutStone(-1,2,2,2);

        int[] temp = new int[64]; //待った機能のための情報の格納
        for(int _y=0; _y<4; _y++)
        {
          for(int _z=0; _z<4; _z++)
          {
            for(int _x=0; _x<4; _x++)
            {
              temp[16*_y+4*_z+_x] = stones.GetComponent<Stone>().Square[_x,_y,_z];
            }
          }
        }
        squareList.Add(temp);
      }

      void Update()
      {
        if(keyDetectable)
        {
          keyDetector.GetComponent<KeyDetector>().NumKeyDetect();
          keyDetector.GetComponent<KeyDetector>().BackSpaceDetect();
          PlayGame();
          foreach(GameObject display in GameObject.FindGameObjectsWithTag("CoordinateDisplay")) //CoordinateDisplayクラスのテキストの向きを定める
          {
            display.transform.LookAt(standard - mainCamera.GetComponent<CameraMover>().MainCameraTransformPosition,Vector3.up);
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
        colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
        if(putableInform)
        {
          CanPutAndInform();
        }else { CanPut(); }
        coordiDisplay.GetComponent<CoordiDisplay>().BeforePressedIndicate();
        infoDisplay.GetComponent<InfoDisplay>().TurnIndicate();
        infoDisplay.GetComponent<InfoDisplay>().StoneNumIndicate();
        beforePressed = true;
        afterXPressed = false;
      }

      private void AfterXPressed() //x座標を確定した後に一度だけ実行される
      {
        colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
        for(int y=0; y<4; y++)
        {
            for(int z=0; z<4; z++)
            {
                colorManager.GetComponent<ChangeColor>().ShineBoardColor(XCoordi-1,y,z);
                if(putableInform) {stones.GetComponent<Stone>().Inform(turn,XCoordi-1,y,z);}
            }
        }
        coordiDisplay.GetComponent<CoordiDisplay>().AfterXPressedIndicate();
        beforePressed = false;
        afterXPressed = true;
        afterZPressed = false;
      }

      private void AfterZPressed() //z座標を確定した後に一度だけ実行される
      {
        colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
        for(int y=0; y<4; y++)
        {
            colorManager.GetComponent<ChangeColor>().ShineBoardColor(XCoordi-1,y,ZCoordi-1);
            if(putableInform) {stones.GetComponent<Stone>().Inform(turn,XCoordi-1,y,ZCoordi-1);}
        }
        coordiDisplay.GetComponent<CoordiDisplay>().AfterZPressedIndicate();
        afterXPressed = false;
        afterZPressed = true;
        afterYPressed = false;
      }

      private void AfterYPressed() //y座標を確定した後に一度だけ実行される
      {
        colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
        colorManager.GetComponent<ChangeColor>().ShineBoardColor(XCoordi-1,YCoordi-1,ZCoordi-1);
        if(putableInform) {stones.GetComponent<Stone>().Inform(turn,XCoordi-1,YCoordi-1,ZCoordi-1);}
        coordiDisplay.GetComponent<CoordiDisplay>().AfterYPressedDisplay();
        afterZPressed = false;
        afterYPressed = true;
      }

      private void AfterEnterPressed() //エンターキーを押した後に一度だけ実行される
      {
        stones.GetComponent<Stone>().FlipStone(turn,XCoordi-1,YCoordi-1,ZCoordi-1); //ここでturnを変更している
        CanPut();
        afterYPressed= false;
        XCoordi = YCoordi = ZCoordi = 0;
        enterPressed = false;
      }


      private void CanPut() //置く場所がなければパスしたりリザルト画面を表示したりする。putableInformがtrueなら置ける場所を光らせる
      {
        bool canPut = stones.GetComponent<Stone>().CanPut(turn);
        if(!canPut)
        {
            canPut = stones.GetComponent<Stone>().CanPut(-1*turn);
            if(canPut)
            {
              infoDisplay.GetComponent<InfoDisplay>().PassedIndicate(turn);
              turn *= -1;
            }else
            {
              GameSet();
            }
        }
      }

      private void CanPutAndInform() //置く場所がなければパスしたりリザルト画面を表示したりする。putableInformがtrueなら置ける場所を光らせる
      {
        bool canPut = stones.GetComponent<Stone>().CanPutAndInform(turn);
        if(!canPut)
        {
            canPut = stones.GetComponent<Stone>().CanPutAndInform(-1*turn);
            if(canPut)
            {
              infoDisplay.GetComponent<InfoDisplay>().PassedIndicate(turn);
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
        infoDisplay.GetComponent<InfoDisplay>().ResultIndicate();

      }


      public int Turn{ get {return turn;} set {this.turn = value;} }

      public bool KeyDetectable{ get {return keyDetectable;} }

      public bool SetBeforePressed{ get {return beforePressed;} set {beforePressed = value;} }

      public bool SetAfterXPressed{ get {return afterXPressed;} set {afterXPressed = value;} }

      public bool SetAfterYPressed{ get {return afterYPressed;} set {afterYPressed = value;} }

      public bool SetAfterZPressed{ get {return afterZPressed;} set {afterZPressed = value;} }

      public bool SetEnterPressed{ get {return enterPressed;} set {enterPressed = value;} }

      public bool PutableInform{ get {return putableInform;} set {this.putableInform = value;} }
  }

}
