using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP444
{
  public class Game444 : MonoBehaviour
  {
      private bool putableInform = true; //置く場所を光らせるならtrue。（Menu画面で変更可能）//////////////////////////////////////////////////////////////まだ未完成
      private Vector3 standard; //CoordinateDisplayクラスのテキストの向きを定めるために用いる
      private int turn = 1; //ターン入れ替えは"StoneXXX/FlipStone"で行っている
      private bool keyDetectable = true; //falseのときカメラ移動とキー入力を受け付けない
      public int XCoordi {get; set;}
      public int YCoordi {get; set;}
      public int ZCoordi {get; set;}
      private bool beforePressed,afterXPressed, afterZPressed, afterYPressed; //オセロ盤の状態を管理するための変数
      public bool EnterPressed {get; set;}
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

        stones.GetComponent<Stone444>().PutStone(1,1,1,1);
        stones.GetComponent<Stone444>().PutStone(1,2,1,2);
        stones.GetComponent<Stone444>().PutStone(-1,1,1,2);
        stones.GetComponent<Stone444>().PutStone(-1,2,1,1);
        stones.GetComponent<Stone444>().PutStone(1,1,2,2);
        stones.GetComponent<Stone444>().PutStone(1,2,2,1);
        stones.GetComponent<Stone444>().PutStone(-1,1,2,1);
        stones.GetComponent<Stone444>().PutStone(-1,2,2,2);
        infoDisplay.GetComponent<InfoDisplay444>().TurnIndicate();
        infoDisplay.GetComponent<InfoDisplay444>().StoneNumIndicate();
      }

      void Update()
      {
        if(keyDetectable)
        {
          keyDetector.GetComponent<KeyDetector444>().NumKeyDetect();
          keyDetector.GetComponent<KeyDetector444>().BackSpaceDetect();
          PlayGame();
          foreach(GameObject display in GameObject.FindGameObjectsWithTag("CoordinateDisplay")) //CoordinateDisplayクラスのテキストの向きを定める
          {
            display.transform.LookAt(standard - mainCamera.GetComponent<CameraMover444>().MainCameraTransformPosition,Vector3.up);
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
          }else if(EnterPressed == true)
          {
              AfterEnterPressed();
          }
      }

      private void BeforePressed()
      {
        colorManager.GetComponent<ChangeColor444>().UndoAllBoardColor();
        if(putableInform)
        {
          CanPutAndInform();
        }else { CanPut(); }
        coordiDisplay.GetComponent<CoordiDisplay444>().BeforePressedIndicate();
        beforePressed = true;
        afterXPressed = false;
      }

      private void AfterXPressed()
      {
        colorManager.GetComponent<ChangeColor444>().UndoAllBoardColor();
        for(int y=0; y<4; y++)
        {
            for(int z=0; z<4; z++)
            {
                colorManager.GetComponent<ChangeColor444>().ShineBoardColor(XCoordi-1,y,z);
                if(putableInform) {stones.GetComponent<Stone444>().Inform(turn,XCoordi-1,y,z);}
            }
        }
        coordiDisplay.GetComponent<CoordiDisplay444>().AfterXPressedIndicate();
        beforePressed = false;
        afterXPressed = true;
        afterZPressed = false;
      }

      private void AfterZPressed()
      {
        colorManager.GetComponent<ChangeColor444>().UndoAllBoardColor();
        for(int y=0; y<4; y++)
        {
            colorManager.GetComponent<ChangeColor444>().ShineBoardColor(XCoordi-1,y,ZCoordi-1);
            if(putableInform) {stones.GetComponent<Stone444>().Inform(turn,XCoordi-1,y,ZCoordi-1);}
        }
        coordiDisplay.GetComponent<CoordiDisplay444>().AfterZPressedIndicate();
        afterXPressed = false;
        afterZPressed = true;
        afterYPressed = false;
      }

      private void AfterYPressed()
      {
        colorManager.GetComponent<ChangeColor444>().UndoAllBoardColor();
        colorManager.GetComponent<ChangeColor444>().ShineBoardColor(XCoordi-1,YCoordi-1,ZCoordi-1);
        if(putableInform) {stones.GetComponent<Stone444>().Inform(turn,XCoordi-1,YCoordi-1,ZCoordi-1);}
        coordiDisplay.GetComponent<CoordiDisplay444>().AfterYPressedDisplay();
        afterZPressed = false;
        afterYPressed = true;
      }

      private void AfterEnterPressed()
      {
        colorManager.GetComponent<ChangeColor444>().UndoAllBoardColor();
        stones.GetComponent<Stone444>().FlipStone(turn,XCoordi-1,YCoordi-1,ZCoordi-1); //ここでturnを変更している

        infoDisplay.GetComponent<InfoDisplay444>().TurnIndicate();
        infoDisplay.GetComponent<InfoDisplay444>().StoneNumIndicate();
        if(putableInform)
        {
          CanPutAndInform();
        }else { CanPut(); }

        afterYPressed= false;
        XCoordi = YCoordi = ZCoordi = 0;
        EnterPressed = false;
        Debug.Log(turn);///////////////////////////////////////////////////////////////////////////////
      }

      private void CanPut() //置く場所がなければパスしたりリザルト画面を表示したりする。putableInformがtrueなら置ける場所を光らせる
      {
        bool canPut = stones.GetComponent<Stone444>().CanPut(turn);
        if(!canPut)
        {
            canPut = stones.GetComponent<Stone444>().CanPut(-1*turn);
            if(canPut)
            {
              turn *= -1;
            }else
            {
              keyDetectable = false;
              centerCanvas.GetComponent<Canvas>().enabled = true;
            }
        }
      }

      private void CanPutAndInform() //置く場所がなければパスしたりリザルト画面を表示したりする。putableInformがtrueなら置ける場所を光らせる
      {
        bool canPut = stones.GetComponent<Stone444>().CanPutAndInform(turn);
        if(!canPut)
        {
            canPut = stones.GetComponent<Stone444>().CanPutAndInform(-1*turn);
            if(canPut)
            {
              turn *= -1;
            }else
            {
              keyDetectable = false;
              centerCanvas.GetComponent<Canvas>().enabled = true;
            }
        }
      }


      public int Turn
      {
        set {this.turn = value;}
        get {return turn;}
      }

      public bool KeyDetectable{ get {return keyDetectable;} }

      public bool PutableInform
      {
        set {this.putableInform = value;}
        get {return putableInform;}
      }
  }

}
