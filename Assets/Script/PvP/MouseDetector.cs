using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PvP
{
  public class MouseDetector : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //オセロ盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      public Stone stone;
      public Game game;
      public InfoDisplay infoDisplay;
      public ChangeColor changeColor;
      public GameObject menuCanvas;
      public GameObject cameraSensiSlider;
      public CameraMover cameraMover;
      public GameObject putableSlider;
      public Text putableOnOffText;
      public GameObject stoneSizeSlider;
      public GameObject instructionCanvas;
      public GameObject saveConfirmCanvas;


      void Awake()
      {
          cameraSensiSlider.GetComponent<Slider>().value = 2 * PlayerPrefs.GetFloat("Value_of_MovingSpeed", 20f) / 5;
          putableSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Value_of_PutableInform", 1);
          stoneSizeSlider.GetComponent<Slider>().value = 20 * PlayerPrefs.GetFloat("Value_of_StoneSize", 0.6f);
          stoneSizeSlider.GetComponent<Slider>().onValueChanged.AddListener(OnStoneSizeSlide);
      }


      public void OnCancelClick() //待ったを押した時の処理。CameraMover.csのsquareListにリプレイ情報を格納している
      {
        if(game.TotalTurn > 0 && game.KeyDetectable)
        {
          game.TotalTurn--;
          stone.PutAllStoneAsList(); //game.Turnはこの先で変更している
          infoDisplay.TurnIndicate();
          infoDisplay.StoneNumIndicate();
        }
      }

      public void OnMenuClick() //Menuボタンを押した時メニューウィンドウを表示させる。
      {
        menuCanvas.GetComponent<Canvas>().enabled = true;
      }

      public void OnMenuCloseClick() //メニューウィンドウのバツボタンを押した時メニューウィンドウを消す
      {
        menuCanvas.GetComponent<Canvas>().enabled = false;
      }

      public void OnCameraSensiSlide() //カメラ感度のスライダーの値を取得
      {
        cameraMover.MovingSpeed = 5 * cameraSensiSlider.GetComponent<Slider>().value / 2;
        PlayerPrefs.SetFloat("Value_of_MovingSpeed", cameraMover.MovingSpeed);
        PlayerPrefs.Save();
      }

      public void OnPutableSlide() //お助け機能のスライダーの値を取得
      {
        float s = putableSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("Value_of_PutableInform", s);
        PlayerPrefs.Save();
        if(s == 0)
        {
            game.PutableInform = false;
            putableOnOffText.text = "オフ";
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
            putableOnOffText.text = "オン";
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

      public void OnInstructionClick() //Menuボタンを押した時メニューウィンドウを表示させる
      {
        instructionCanvas.GetComponent<Canvas>().enabled = true;
      }

      public void OnInstructionCloseClick() //メニューウィンドウのバツボタンを押した時メニューウィンドウを消す
      {
        instructionCanvas.GetComponent<Canvas>().enabled = false;
      }

      public void OnLoadTitleClick()
      {
        SceneManager.LoadScene("Choose");
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

      public void OnPlayAgainClick()
      {
        SceneManager.LoadScene("PvP");
      }
  }
}
