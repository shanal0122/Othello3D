using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvP
{
  public class MouseDetector : MonoBehaviour
  {
      public Stone stone;
      public Game game;
      public GameObject menuCanvas;
      public GameObject cameraSensiSlider;
      public CameraMover cameraMover;
      public GameObject putableSlider;
      public Text putableOnOffText;
      public GameObject instructionCanvas;


      public void OnCancelClick() //待ったを押した時の処理。CameraMover.csのsquareListにリプレイ情報を格納している
      {
        if(Game.totalTurn > 0 && game.KeyDetectable)
        {
          stone.PutAllStoneAsList();
          game.Turn *= -1;
          Game.totalTurn--;
        }
      }

      public void OnMenuClick() //Menuボタンを押した時メニューウィンドウを表示させる
      {
        menuCanvas.GetComponent<Canvas>().enabled = true;
        game.KeyDetectable = false;
      }

      public void OnMenuCloseClick() //メニューウィンドウのバツボタンを押した時メニューウィンドウを消す
      {
        menuCanvas.GetComponent<Canvas>().enabled = false;
        game.KeyDetectable = true;
      }

      public void OnCameraSensiSlide() //カメラ感度のスライダーの値を取得
      {
        cameraMover.MovingSpeed = 5 * cameraSensiSlider.GetComponent<Slider>().value / 3;
      }

      public void OnPutableSlide() //お助け機能のスライダーの値を取得
      {
        float s = putableSlider.GetComponent<Slider>().value;
        if(s == 0)
        {
          game.PutableInform = false;
          putableOnOffText.text = "オフ";
        }
        if(s == 1)
        {
          game.PutableInform = true;
          putableOnOffText.text = "オン";
        }
      }

      public void OnInstructionClick() //Menuボタンを押した時メニューウィンドウを表示させる
      {
        instructionCanvas.GetComponent<Canvas>().enabled = true;
      }

      public void OnInstructionCloseClick() //メニューウィンドウのバツボタンを押した時メニューウィンドウを消す
      {
        instructionCanvas.GetComponent<Canvas>().enabled = false;
      }
  }
}
