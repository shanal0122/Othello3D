using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvP444
{
  public class MouseDetector : MonoBehaviour
  {
      public GameObject stones;
      public GameObject master;
      public GameObject menuCanvas;
      public GameObject cameraSensiSlider;
      public GameObject mainCamera;
      public GameObject putableSlider;
      public Text putableOnOffText;
      public GameObject instructionCanvas;


      public void OnCancelClick() //待ったを押した時の処理。CameraMover.csのsquareListにリプレイ情報を格納している
      {
        if(Game.totalTurn > 0 && master.GetComponent<Game>().KeyDetectable)
        {
          stones.GetComponent<Stone>().PutAllStoneAsList();
          master.GetComponent<Game>().Turn *= -1;
          Game.totalTurn--;
        }
      }

      public void OnMenuClick() //Menuボタンを押した時メニューウィンドウを表示させる
      {
        menuCanvas.GetComponent<Canvas>().enabled = true;
        master.GetComponent<Game>().KeyDetectable = false;
      }

      public void OnMenuCloseClick() //メニューウィンドウのバツボタンを押した時メニューウィンドウを消す
      {
        menuCanvas.GetComponent<Canvas>().enabled = false;
        master.GetComponent<Game>().KeyDetectable = true;
      }

      public void OnCameraSensiSlide() //カメラ感度のスライダーの値を取得
      {
        mainCamera.GetComponent<CameraMover>().MovingSpeed = 5 * cameraSensiSlider.GetComponent<Slider>().value / 3;
      }

      public void OnPutableSlide() //お助け機能のスライダーの値を取得
      {
        float s = putableSlider.GetComponent<Slider>().value;
        if(s == 0)
        {
          master.GetComponent<Game>().PutableInform = false;
          putableOnOffText.text = "オフ";
        }
        if(s == 1)
        {
          master.GetComponent<Game>().PutableInform = true;
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
