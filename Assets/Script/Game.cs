using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int turn = 1;
    public int XCoordi {get; set;}
    public int YCoordi {get; set;}
    public int ZCoordi {get; set;}
    private bool notShined,surfaceShined, lineShined, pointShined; //オセロ盤を光らせるのを管理するための変数
    public bool EnterPressed {get; set;}
    public GameObject stones;
    public GameObject colorManager;
    public GameObject keyDetector;


    void Start()
    {
      stones.GetComponent<Stone>().PutStone(1,1,1,1);
      stones.GetComponent<Stone>().PutStone(1,2,1,2);
      stones.GetComponent<Stone>().PutStone(-1,1,1,2);
      stones.GetComponent<Stone>().PutStone(-1,2,1,1);
      stones.GetComponent<Stone>().PutStone(1,1,2,2);
      stones.GetComponent<Stone>().PutStone(1,2,2,1);
      stones.GetComponent<Stone>().PutStone(-1,1,2,1);
      stones.GetComponent<Stone>().PutStone(-1,2,2,2);
    }

    // Update is called once per frame
    void Update()
    {
      keyDetector.GetComponent<KeyDetector>().NumKeyDetect();
      keyDetector.GetComponent<KeyDetector>().BackSpaceDetect();
      PlayGame();
    }


    public void PlayGame() //KeyDetectorクラスから1~4とbackspaceのキー操作情報を受け取り、オセロ盤を光らせ石を置く
    {
        if(XCoordi == 0 && ZCoordi == 0 && YCoordi == 0 && notShined == false)
        {
            colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
            notShined = true;
            surfaceShined = false;
        }
        else if(XCoordi != 0 && ZCoordi == 0 && YCoordi == 0 && surfaceShined == false)
        {
            colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
            for(int y=0; y<4; y++)
            {
                for(int z=0; z<4; z++)
                {
                    colorManager.GetComponent<ChangeColor>().ShineBoardColor(XCoordi-1,y,z);
                }
            }
            notShined = false;
            surfaceShined = true;
            lineShined = false;
        }else if(ZCoordi != 0 && YCoordi == 0 && lineShined == false)
        {
            colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
            for(int y=0; y<4; y++)
            {
                colorManager.GetComponent<ChangeColor>().ShineBoardColor(XCoordi-1,y,ZCoordi-1);
            }
            surfaceShined = false;
            lineShined = true;
            pointShined = false;
        }else if(YCoordi != 0 && pointShined == false)
        {
            colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
            colorManager.GetComponent<ChangeColor>().ShineBoardColor(XCoordi-1,YCoordi-1,ZCoordi-1);
            lineShined = false;
            pointShined = true;
        }else if(EnterPressed == true)
        {
            colorManager.GetComponent<ChangeColor>().UndoAllBoardColor();
            stones.GetComponent<Stone>().FlipStone(turn,XCoordi-1,YCoordi-1,ZCoordi-1);
            pointShined = false;
            XCoordi = YCoordi = ZCoordi = 0;
            EnterPressed = false;
            Debug.Log(turn);///////////////////////////////////////////////////////////////////////////////
        }
    }

    public int Turn
    {
      set {this.turn = value;}
      get {return turn;}
    }
}
