using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choose
{
  public class UGUI : MonoBehaviour
  {
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private float pwidth; //CanvasScalerのReference Resolution。（幅）
      private float pheight = 600; //CanvasScalerのReference Resolution。Heightで合わせているたためこれが高さの基準になる（高さ）
      public GameObject chooseCanvas;
      public GameObject suspendConfirmCanvas;
      public GameObject tutorialConfirmCanvas;
      public GameObject menuCanvas;
      public GameObject creditCanvas;
      public GameObject betaTestCanvas;
      public GameObject betaTestCanvas2;
      public GameObject betaTestCanvas3;

      private RectTransform pvp444Button;
      private RectTransform pvp464Button;
      private RectTransform pvc444Button;
      private RectTransform pvc464Button;
      private RectTransform replayButton;
      private RectTransform menuButton;
      private RectTransform chooseText;

      private RectTransform suspendConfirmPanel;

      private RectTransform tutorialConfirmPanel;

      private RectTransform menuPanel;
      private RectTransform menuCloseButton;
      private RectTransform menuText;
      private RectTransform bgmDropdown;
      private RectTransform bgmVolumeSlide;
      private RectTransform playerTurnDropdown;
      private RectTransform levelDropdown;
      private RectTransform tutorialButton;
      private RectTransform creditButton;
      private RectTransform loadTitleButton;

      private RectTransform creditPanel;
      private RectTransform creditCloseButton;
      private RectTransform creditText;
      private RectTransform creditScrollView;
      private RectTransform creditImage;
      private RectTransform creditReturnMenuButton;

      void Start()
      {
        pvp444Button = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        pvp464Button = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        pvc444Button = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        pvc464Button = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
        replayButton = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.GetComponent<RectTransform>();
        menuButton = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.GetComponent<RectTransform>();
        chooseText = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject.GetComponent<RectTransform>();

        suspendConfirmPanel = suspendConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

        tutorialConfirmPanel = tutorialConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

        menuPanel = menuCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        menuCloseButton = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        menuText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        bgmDropdown = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        bgmVolumeSlide = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
        playerTurnDropdown = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.GetComponent<RectTransform>();
        levelDropdown = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.GetComponent<RectTransform>();
        tutorialButton = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject.GetComponent<RectTransform>();
        creditButton = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(7).gameObject.GetComponent<RectTransform>();
        loadTitleButton = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(8).gameObject.GetComponent<RectTransform>();

        creditPanel = creditCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        creditCloseButton = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        creditText = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        creditScrollView = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        creditImage = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
        creditReturnMenuButton = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.GetComponent<RectTransform>();

        SetuGUI();
      }

      public void SetuGUI()
      {
        swidth = Screen.width; sheight = Screen.height;
        pwidth = pheight * swidth / sheight;
        Debug.Log(swidth + " " + sheight + " " + pwidth + " " + pheight);

        if(swidth >= sheight)
        {
          pvp444Button.localScale = new Vector3(0.5f,0.5f,1f); pvp444Button.localPosition = new Vector3(-50f,187f,0f);
          pvp464Button.localScale = new Vector3(0.5f,0.5f,1f); pvp464Button.localPosition = new Vector3(250f,187f,0f);
          pvc444Button.localScale = new Vector3(0.5f,0.5f,1f); pvc444Button.localPosition = new Vector3(-50f,-43f,0f);
          pvc464Button.localScale = new Vector3(0.5f,0.5f,1f); pvc464Button.localPosition = new Vector3(250f,-43f,0f);
          replayButton.localScale = new Vector3(0.5f,0.5f,1f); replayButton.localPosition = new Vector3(256f,-208f,0f);
          menuButton.localScale = new Vector3(0.5f,0.5f,1f); menuButton.localPosition = new Vector3(37f,-189f,0f);
          chooseText.localScale = new Vector3(0.15f,0.2f,1f); chooseText.localPosition = new Vector3(47f,-237f,0);

          suspendConfirmPanel.localScale = new Vector3(0.3f,0.3f,1f); suspendConfirmPanel.localPosition = new Vector3(0f,0f,0f);

          tutorialConfirmPanel.localScale = new Vector3(0.3f,0.3f,1f); tutorialConfirmPanel.localPosition = new Vector3(0f,0f,0f);

          menuPanel.localScale = new Vector3(1f,1f,1f); menuPanel.localPosition = new Vector3(0f,0f,0f);
          menuCloseButton.localScale = new Vector3(1f,1f,1f); menuCloseButton.localPosition = new Vector3(275f,255f,0f);
          menuText.localScale = new Vector3(0.2f,0.2f,1f); menuText.localPosition = new Vector3(0f,230f,0f);
          bgmDropdown.sizeDelta = new Vector2(200f,40f); bgmDropdown.localScale = new Vector3(1f,1f,1f); bgmDropdown.localPosition = new Vector3(100f,160f,0f);
          bgmVolumeSlide.sizeDelta = new Vector2(360f,24f); bgmVolumeSlide.localScale = new Vector3(1f,1f,1f); bgmVolumeSlide.localPosition = new Vector3(80f,95f,0f);
          playerTurnDropdown.sizeDelta = new Vector2(200f,40f); playerTurnDropdown.localScale = new Vector3(1f,1f,1f); playerTurnDropdown.localPosition = new Vector3(100f,30f,0f);
          levelDropdown.sizeDelta = new Vector2(200f,40f); levelDropdown.localScale = new Vector3(1f,1f,1f); levelDropdown.localPosition = new Vector3(100f,-35f,0f);
          tutorialButton.sizeDelta = new Vector2(200f,50f); tutorialButton.localScale = new Vector3(0.6f,0.9f,1f); tutorialButton.localPosition = new Vector3(85f,-100f,0f);
          creditButton.sizeDelta = new Vector2(200f,50f); creditButton.localScale = new Vector3(0.6f,0.9f,1f); creditButton.localPosition = new Vector3(85f,-165f,0f);
          loadTitleButton.sizeDelta = new Vector2(200f,50f); loadTitleButton.localScale = new Vector3(0.6f,0.9f,1f); loadTitleButton.localPosition = new Vector3(85f,-230f,0f);

          creditPanel.localScale = new Vector3(1f,1f,1f); creditPanel.localPosition = new Vector3(0f,0f,0f);
          creditCloseButton.localScale = new Vector3(1f,1f,1f); creditCloseButton.localPosition = new Vector3(275f,255f,0f);
          creditText.localScale = new Vector3(0.2f,0.2f,1f); creditText.localPosition = new Vector3(0f,230f,0f);
          creditScrollView.sizeDelta = new Vector2(600f,320f); creditScrollView.localScale = new Vector3(1f,1f,1f); creditScrollView.localPosition = new Vector3(0f,30f,0f);
          creditImage.localScale = new Vector3(0.5f,0.5f,1f); creditImage.localPosition = new Vector3(-160f,-200f,0f);
          creditReturnMenuButton.sizeDelta = new Vector2(200f,50f); creditReturnMenuButton.localScale = new Vector3(1f,1.2f,1f); creditReturnMenuButton.localPosition = new Vector3(120f,-200f,0f);
        }

        if(swidth >= sheight)
        {

        }
      }
  }
}
