using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game444 : MonoBehaviour
{
    private Vector3 standard; //CoordinateDisplayクラスのテキストの向きを定めるために用いる
    private int turn = 1;
    public int XCoordi {get; set;}
    public int YCoordi {get; set;}
    public int ZCoordi {get; set;}
    private bool beforePressed,afterXPressed, afterZPressed, afterYPressed; //オセロ盤の状態を管理するための変数
    public bool EnterPressed {get; set;}
    public GameObject mainCamera;
    public GameObject stones;
    public GameObject colorManager;
    public GameObject keyDetector;
    public GameObject coordinateDisplay;


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
    }

    void Update()
    {
      keyDetector.GetComponent<KeyDetector444>().NumKeyDetect();
      keyDetector.GetComponent<KeyDetector444>().BackSpaceDetect();
      PlayGame();
      foreach(GameObject display in GameObject.FindGameObjectsWithTag("CoordinateDisplay")) //CoordinateDisplayクラスのテキストの向きを定める
      {
        display.transform.LookAt(standard - mainCamera.GetComponent<CameraMover444>().MainCameraTransformPosition,Vector3.up);
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
      coordinateDisplay.GetComponent<CoordinateDisplay444>().BeforePressedDisplay();
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
          }
      }
      coordinateDisplay.GetComponent<CoordinateDisplay444>().AfterXPressedDisplay();
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
      }
      coordinateDisplay.GetComponent<CoordinateDisplay444>().AfterZPressedDisplay();
      afterXPressed = false;
      afterZPressed = true;
      afterYPressed = false;
    }

    private void AfterYPressed()
    {
      colorManager.GetComponent<ChangeColor444>().UndoAllBoardColor();
      colorManager.GetComponent<ChangeColor444>().ShineBoardColor(XCoordi-1,YCoordi-1,ZCoordi-1);
      coordinateDisplay.GetComponent<CoordinateDisplay444>().AfterYPressedDisplay();
      afterZPressed = false;
      afterYPressed = true;
    }

    private void AfterEnterPressed()
    {
      colorManager.GetComponent<ChangeColor444>().UndoAllBoardColor();
      stones.GetComponent<Stone444>().FlipStone(turn,XCoordi-1,YCoordi-1,ZCoordi-1);
      afterZPressed= false;
      XCoordi = YCoordi = ZCoordi = 0;
      EnterPressed = false;
      Debug.Log(turn);///////////////////////////////////////////////////////////////////////////////
    }


    public int Turn
    {
      set {this.turn = value;}
      get {return turn;}
    }
}
