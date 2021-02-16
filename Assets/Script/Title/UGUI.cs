using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Title
{
  public class UGUI : MonoBehaviour
  {
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private float pwidth; //CanvasScalerのReference Resolution。（幅）
      private float pheight = 600; //CanvasScalerのReference Resolution。Heightで合わせているたためこれが高さの基準になる（高さ）
      public GameObject MainCanvas;
      public GameObject FlashingCanvas;

      private RectTransform mainText;
      private Text mainTextText;
      private RectTransform loadChooseButton;

      private RectTransform flashingText;
      private Text flashingTextText;

      void Start()
      {
          mainText = MainCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          mainTextText = MainCanvas.transform.GetChild(0).gameObject.GetComponent<Text>();
          loadChooseButton = MainCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();

          flashingText = FlashingCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          flashingTextText = FlashingCanvas.transform.GetChild(0).gameObject.GetComponent<Text>();

          SetuGUI();
      }

      private void SetuGUI()
      {
        swidth = Screen.width; sheight = Screen.height;
        pwidth = pheight * swidth / sheight;
        Debug.Log(swidth + " " + sheight + " " + pwidth + " " + pheight);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if(swidth > sheight)
        {
          mainText.localScale = new Vector3(0.8f,1f,1f); mainText.localPosition = new Vector3(0f,235f,0f);
          loadChooseButton.sizeDelta = new Vector2(pwidth+10f,pheight+10f);

          flashingText.localScale = new Vector3(1.2f,1.5f,1f); flashingText.localPosition = new Vector3(0f,-245f,0f);
          flashingTextText.text = "Press Enter or Click";
        }

        if(swidth <= sheight)
        {
          float magni = Mathf.Min(0.8f*pwidth/mainTextText.preferredWidth/0.6f,1f);Debug.Log(mainTextText.preferredWidth);
          mainText.localScale = new Vector3(0.6f*magni,1f*magni,1f); mainText.localPosition = new Vector3(0f,235f,0f);
          loadChooseButton.sizeDelta = new Vector2(pwidth+10f,pheight+10f);

          flashingText.localScale = new Vector3(0.8f*magni,1.2f*magni,1f); flashingText.localPosition = new Vector3(0f,-235f,0f);
          flashingTextText.text = "Please Tap !";
        }
      }
  }
}
