using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Choose
{
  public class UGUI : MonoBehaviour
  {
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private float pwidth; //CanvasScalerのReference Resolution。（幅）
      private float pheight = 600; //CanvasScalerのReference Resolution。Heightで合わせているたためこれが高さの基準になる（高さ）
      private int language;
      public GameObject optionCanvas;
      public GameObject chooseCanvas;
      public GameObject pvcCanvas;
      public GameObject pvpCanvas;
      public GameObject suspendConfirmCanvas;
      public GameObject tutorialConfirmCanvas;
      public GameObject menuCanvas;
      public GameObject creditCanvas;

      private RectTransform menuButton;
      private Text menuButtonText;
      private RectTransform reviewButton;

      private RectTransform choosePanel;
      private RectTransform chooseText;
      private Text chooseTextText;
      private RectTransform pvcButton;
      private Text pvcButtonText;
      private RectTransform pvpButton;
      private Text pvpButtonText;
      private RectTransform replayButton;
      private Text replayButtonText;

      private RectTransform pvcPanel;
      private RectTransform pvcText;
      private Text pvcTextText;
      private RectTransform pvc444Button;
      private RectTransform pvc464Button;
      private RectTransform pvcBackButton;
      private Text pvcBackButtonText;

      private RectTransform pvpPanel;
      private RectTransform pvpText;
      private Text pvpTextText;
      private RectTransform pvp444Button;
      private RectTransform pvp464Button;
      private RectTransform pvpBackButton;
      private Text pvpBackButtonText;

      private RectTransform suspendConfirmPanel;
      private Text suspendConfirmText;
      private Text suspendConfirmYesText;
      private Text suspendConfirmNoText;

      private RectTransform tutorialConfirmPanel;
      private Text tutorialConfirmText;
      private Text tutorialConfirmYesText;
      private Text tutorialConfirmNoText;

      private RectTransform menuPanel;
      private RectTransform menuCloseButton;
      private RectTransform menuText;
      private Text menuTextText;
      private RectTransform languageDropdown;
      private RectTransform languageDropdownText;
      private Text languageDropdownTextText;
      private RectTransform bgmDropdown;
      private RectTransform bgmDropdownText;
      private Text bgmDropdownTextText;
      private RectTransform bgmVolumeSlide;
      private RectTransform bgmVolumeSlideText;
      private Text bgmVolumeSlideTextText;
      private RectTransform playerTurnDropdown;
      private Dropdown playerTurnDropdownDropdown;
      private RectTransform playerTurnDropdownText;
      private Text playerTurnDropdownTextText;
      private Text playerTurnDropdownLabelText;
      private RectTransform levelDropdown;
      private Dropdown levelDropdownDropdown;
      private RectTransform levelDropdownText;
      private Text levelDropdownTextText;
      private Text levelDropdownLabelText;
      private RectTransform tutorialButton;
      private RectTransform tutorialButtonText;
      private Text tutorialButtonTextText;
      private Text tutorialButtonPlayText;
      private RectTransform creditButton;
      private RectTransform creditButtonText;
      private Text creditButtonTextText;
      private Text creditButtonDisplayText;
      private RectTransform loadTitleButton;
      private RectTransform loadTitleButtonText;
      private Text loadTitleButtonTextText;
      private Text loadTitleButtonPlayText;

      private RectTransform creditPanel;
      private RectTransform creditCloseButton;
      private RectTransform creditText;
      private Text creditTextText;
      private RectTransform creditScrollView;
      private RectTransform creditContent;
      private RectTransform creditIndexText;
      private Text creditIndexTextText;
      private RectTransform creditNameText;
      private Text creditNameTextText;
      private RectTransform LicenseText1;
      private RectTransform LicenseText2;
      private RectTransform creditImage;
      private RectTransform creditReturnMenuButton;
      private Text creditReturnMenuButtonText;

      void Start()
      {
        menuButton = optionCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        menuButtonText = optionCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        reviewButton = optionCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();

        choosePanel = chooseCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        chooseText = chooseCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
        chooseTextText = chooseCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        pvcButton = chooseCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<RectTransform>();
        pvcButtonText = chooseCanvas.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
        pvpButton = chooseCanvas.transform.GetChild(0).GetChild(2).gameObject.GetComponent<RectTransform>();
        pvpButtonText = chooseCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();
        replayButton = chooseCanvas.transform.GetChild(0).GetChild(3).gameObject.GetComponent<RectTransform>();
        replayButtonText = chooseCanvas.transform.GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<Text>();

        pvcPanel = pvcCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        pvcText = pvcCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
        pvcTextText = pvcCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        pvc444Button = pvcCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<RectTransform>();
        pvc464Button = pvcCanvas.transform.GetChild(0).GetChild(2).gameObject.GetComponent<RectTransform>();
        pvcBackButton = pvcCanvas.transform.GetChild(0).GetChild(3).gameObject.GetComponent<RectTransform>();
        pvcBackButtonText = pvcCanvas.transform.GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<Text>();

        pvpPanel = pvpCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        pvpText = pvpCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
        pvpTextText = pvpCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        pvp444Button = pvpCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<RectTransform>();
        pvp464Button = pvpCanvas.transform.GetChild(0).GetChild(2).gameObject.GetComponent<RectTransform>();
        pvpBackButton = pvpCanvas.transform.GetChild(0).GetChild(3).gameObject.GetComponent<RectTransform>();
        pvpBackButtonText = pvpCanvas.transform.GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<Text>();

        suspendConfirmPanel = suspendConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        suspendConfirmText = suspendConfirmCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        suspendConfirmYesText = suspendConfirmCanvas.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
        suspendConfirmNoText = suspendConfirmCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();

        tutorialConfirmPanel = tutorialConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        tutorialConfirmText = tutorialConfirmCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        tutorialConfirmYesText = tutorialConfirmCanvas.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
        tutorialConfirmNoText = tutorialConfirmCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();

        menuPanel = menuCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        menuCloseButton = menuCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
        menuText = menuCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<RectTransform>();
        menuTextText = menuCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
        languageDropdown = menuCanvas.transform.GetChild(0).GetChild(2).gameObject.GetComponent<RectTransform>();
        languageDropdownText = menuCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<RectTransform>();
        languageDropdownTextText = menuCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();
        bgmDropdown = menuCanvas.transform.GetChild(0).GetChild(3).gameObject.GetComponent<RectTransform>();
        bgmDropdownText = menuCanvas.transform.GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<RectTransform>();
        bgmDropdownTextText = menuCanvas.transform.GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<Text>();
        bgmVolumeSlide = menuCanvas.transform.GetChild(0).GetChild(4).gameObject.GetComponent<RectTransform>();
        bgmVolumeSlideText = menuCanvas.transform.GetChild(0).GetChild(4).GetChild(0).gameObject.GetComponent<RectTransform>();
        bgmVolumeSlideTextText = menuCanvas.transform.GetChild(0).GetChild(4).GetChild(0).gameObject.GetComponent<Text>();
        playerTurnDropdown = menuCanvas.transform.GetChild(0).GetChild(5).gameObject.GetComponent<RectTransform>();
        playerTurnDropdownDropdown = menuCanvas.transform.GetChild(0).GetChild(5).gameObject.GetComponent<Dropdown>();
        playerTurnDropdownText = menuCanvas.transform.GetChild(0).GetChild(5).GetChild(0).gameObject.GetComponent<RectTransform>();
        playerTurnDropdownTextText = menuCanvas.transform.GetChild(0).GetChild(5).GetChild(0).gameObject.GetComponent<Text>();
        playerTurnDropdownLabelText = menuCanvas.transform.GetChild(0).GetChild(5).GetChild(1).gameObject.GetComponent<Text>();
        levelDropdown = menuCanvas.transform.GetChild(0).GetChild(6).gameObject.GetComponent<RectTransform>();
        levelDropdownDropdown = menuCanvas.transform.GetChild(0).GetChild(6).gameObject.GetComponent<Dropdown>();
        levelDropdownText = menuCanvas.transform.GetChild(0).GetChild(6).GetChild(0).gameObject.GetComponent<RectTransform>();
        levelDropdownTextText = menuCanvas.transform.GetChild(0).GetChild(6).GetChild(0).gameObject.GetComponent<Text>();
        levelDropdownLabelText = menuCanvas.transform.GetChild(0).GetChild(6).GetChild(1).gameObject.GetComponent<Text>();
        tutorialButton = menuCanvas.transform.GetChild(0).GetChild(7).gameObject.GetComponent<RectTransform>();
        tutorialButtonText = menuCanvas.transform.GetChild(0).GetChild(7).GetChild(0).gameObject.GetComponent<RectTransform>();
        tutorialButtonTextText = menuCanvas.transform.GetChild(0).GetChild(7).GetChild(0).gameObject.GetComponent<Text>();
        tutorialButtonPlayText = menuCanvas.transform.GetChild(0).GetChild(7).GetChild(1).gameObject.GetComponent<Text>();
        creditButton = menuCanvas.transform.GetChild(0).GetChild(8).gameObject.GetComponent<RectTransform>();
        creditButtonText = menuCanvas.transform.GetChild(0).GetChild(8).GetChild(0).gameObject.GetComponent<RectTransform>();
        creditButtonTextText = menuCanvas.transform.GetChild(0).GetChild(8).GetChild(0).gameObject.GetComponent<Text>();
        creditButtonDisplayText = menuCanvas.transform.GetChild(0).GetChild(8).GetChild(1).gameObject.GetComponent<Text>();
        loadTitleButton = menuCanvas.transform.GetChild(0).GetChild(9).gameObject.GetComponent<RectTransform>();
        loadTitleButtonText = menuCanvas.transform.GetChild(0).GetChild(9).GetChild(0).gameObject.GetComponent<RectTransform>();
        loadTitleButtonTextText = menuCanvas.transform.GetChild(0).GetChild(9).GetChild(0).gameObject.GetComponent<Text>();
        loadTitleButtonPlayText = menuCanvas.transform.GetChild(0).GetChild(9).GetChild(1).gameObject.GetComponent<Text>();

        creditPanel = creditCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        creditCloseButton = creditCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
        creditText = creditCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<RectTransform>();
        creditTextText = creditCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
        creditScrollView = creditCanvas.transform.GetChild(0).GetChild(2).gameObject.GetComponent<RectTransform>();
        creditContent = creditCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
        creditIndexText = creditCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
        creditIndexTextText = creditCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        creditNameText = creditCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<RectTransform>();
        creditNameTextText = creditCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
        LicenseText1 = creditCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<RectTransform>();
        LicenseText2 = creditCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(3).gameObject.GetComponent<RectTransform>();
        creditImage = creditCanvas.transform.GetChild(0).GetChild(3).gameObject.GetComponent<RectTransform>();
        creditReturnMenuButton = creditCanvas.transform.GetChild(0).GetChild(4).gameObject.GetComponent<RectTransform>();
        creditReturnMenuButtonText = creditCanvas.transform.GetChild(0).GetChild(4).GetChild(0).gameObject.GetComponent<Text>();

        SetuGUI();
        SetLanguage();
      }

      public void SetuGUI()
      {
        swidth = Screen.width; sheight = Screen.height;
        pwidth = pheight * swidth / sheight;
        //Debug.Log(swidth + " " + sheight + " " + pwidth + " " + pheight); ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(swidth > sheight)
        {
          menuButton.localScale = new Vector3(0.52f,0.52f,1f); menuButton.localPosition = new Vector3(360f,230f,0f);
          reviewButton.localScale = new Vector3(0.52f,0.52f,1f); reviewButton.localPosition = new Vector3(180f,230f,0f);

          choosePanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          chooseText.localScale = new Vector3(1.2f,1.4f,1f); chooseText.localPosition = new Vector3(0f,100f,0);
          pvcButton.sizeDelta = new Vector2(750f,500f); pvcButton.localScale = new Vector3(0.5f,0.5f,1f); pvcButton.localPosition = new Vector3(-250f,-120f,0f);
          pvpButton.sizeDelta = new Vector2(750f,500f); pvpButton.localScale = new Vector3(0.5f,0.5f,1f); pvpButton.localPosition = new Vector3(130f,-120f,0f);
          replayButton.sizeDelta = new Vector2(240f,180f); replayButton.localScale = new Vector3(0.5f,0.5f,1f); replayButton.localPosition = new Vector3(380f,-200f,0f);

          pvcPanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          pvcText.localScale = new Vector3(1.2f,1.4f,1f); pvcText.localPosition = new Vector3(0f,100f,0);
          pvc444Button.sizeDelta = new Vector2(750f,500f); pvc444Button.localScale = new Vector3(0.5f,0.5f,1f); pvc444Button.localPosition = new Vector3(-250f,-120f,0f);
          pvc464Button.sizeDelta = new Vector2(750f,500f); pvc464Button.localScale = new Vector3(0.5f,0.5f,1f); pvc464Button.localPosition = new Vector3(130f,-120f,0f);
          pvcBackButton.sizeDelta = new Vector2(240f,120f); pvcBackButton.localScale = new Vector3(0.55f,0.55f,1f); pvcBackButton.localPosition = new Vector3(390f,-200f,0f);

          pvpPanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          pvpText.localScale = new Vector3(1.2f,1.4f,1f); pvpText.localPosition = new Vector3(0f,100f,0);
          pvp444Button.sizeDelta = new Vector2(750f,500f); pvp444Button.localScale = new Vector3(0.5f,0.5f,1f); pvp444Button.localPosition = new Vector3(-250f,-120f,0f);
          pvp464Button.sizeDelta = new Vector2(750f,500f); pvp464Button.localScale = new Vector3(0.5f,0.5f,1f); pvp464Button.localPosition = new Vector3(130f,-120f,0f);
          pvpBackButton.sizeDelta = new Vector2(240f,120f); pvpBackButton.localScale = new Vector3(0.55f,0.55f,1f); pvpBackButton.localPosition = new Vector3(390f,-200f,0f);

          suspendConfirmPanel.localScale = new Vector3(0.3f,0.3f,1f); suspendConfirmPanel.localPosition = new Vector3(0f,0f,0f);

          tutorialConfirmPanel.localScale = new Vector3(0.3f,0.3f,1f); tutorialConfirmPanel.localPosition = new Vector3(0f,0f,0f);

          menuPanel.sizeDelta = new Vector2(640f,540f); menuPanel.localScale = new Vector3(1f,1f,1f); menuPanel.localPosition = new Vector3(0f,0f,0f);
          menuCloseButton.localScale = new Vector3(1f,1f,1f); menuCloseButton.localPosition = new Vector3(275f,255f,0f);
          menuText.localScale = new Vector3(0.6f,0.6f,1f); menuText.localPosition = new Vector3(0f,230f,0f);
          languageDropdown.sizeDelta = new Vector2(200f,40f); languageDropdown.localScale = new Vector3(1f,1f,1f); languageDropdown.localPosition = new Vector3(130f,176f,0f);
          languageDropdownText.localPosition = new Vector3(-330f,0f,0f);
          bgmDropdown.sizeDelta = new Vector2(200f,40f); bgmDropdown.localScale = new Vector3(1f,1f,1f); bgmDropdown.localPosition = new Vector3(130f,118f,0f);
          bgmDropdownText.localPosition = new Vector3(-330f,0f,0f);
          bgmVolumeSlide.sizeDelta = new Vector2(360f,24f); bgmVolumeSlide.localScale = new Vector3(1f,1f,1f); bgmVolumeSlide.localPosition = new Vector3(110f,60f,0f);
          bgmVolumeSlideText.localPosition = new Vector3(-310f,0f,0f);
          playerTurnDropdown.sizeDelta = new Vector2(200f,40f); playerTurnDropdown.localScale = new Vector3(1f,1f,1f); playerTurnDropdown.localPosition = new Vector3(130f,2f,0f);
          playerTurnDropdownText.localPosition = new Vector3(-330f,0f,0f);
          levelDropdown.sizeDelta = new Vector2(200f,40f); levelDropdown.localScale = new Vector3(1f,1f,1f); levelDropdown.localPosition = new Vector3(130f,-56f,0f);
          levelDropdownText.localPosition = new Vector3(-330f,0f,0f);
          tutorialButton.sizeDelta = new Vector2(120f,45f); tutorialButton.localScale = new Vector3(1f,1f,1f); tutorialButton.localPosition = new Vector3(145f,-114f,0f);
          tutorialButtonText.localPosition = new Vector3(-345f,0f,0f);
          creditButton.sizeDelta = new Vector2(120f,45f); creditButton.localScale = new Vector3(1f,1f,1f); creditButton.localPosition = new Vector3(145f,-172f,0f);
          creditButtonText.localPosition = new Vector3(-345f,0f,0f);
          loadTitleButton.sizeDelta = new Vector2(120f,45f); loadTitleButton.localScale = new Vector3(1f,1f,1f); loadTitleButton.localPosition = new Vector3(145f,-230f,0f);
          loadTitleButtonText.localPosition = new Vector3(-345f,0f,0f);

          creditPanel.sizeDelta = new Vector2(640f,540f); creditPanel.localScale = new Vector3(1f,1f,1f); creditPanel.localPosition = new Vector3(0f,0f,0f);
          creditCloseButton.localScale = new Vector3(1f,1f,1f); creditCloseButton.localPosition = new Vector3(275f,255f,0f);
          creditText.localScale = new Vector3(0.6f,0.6f,1f); creditText.localPosition = new Vector3(0f,230f,0f);
          creditScrollView.sizeDelta = new Vector2(600f,320f); creditScrollView.localScale = new Vector3(1f,1f,1f); creditScrollView.localPosition = new Vector3(0f,30f,0f);
          creditContent.sizeDelta = new Vector2(0f,5000f);
          creditIndexText.localScale = new Vector3(0.72f,0.72f,1f); creditIndexText.localPosition = new Vector3(-2f,-160f,0f);
          creditNameText.localScale = new Vector3(0.72f,0.72f,1f); creditNameText.localPosition = new Vector3(17f,-160f,0f);
          LicenseText1.localScale = new Vector3(0.7f,0.7f,1f); LicenseText1.localPosition = new Vector3(-220f,-400f,0f);
          LicenseText2.localScale = new Vector3(0.7f,0.7f,1f); LicenseText2.localPosition = new Vector3(-220f,-2380f,0f);
          creditImage.localScale = new Vector3(1f,1f,1f); creditImage.localPosition = new Vector3(-160f,-200f,0f);
          creditReturnMenuButton.sizeDelta = new Vector2(200f,50f); creditReturnMenuButton.localScale = new Vector3(1f,1.2f,1f); creditReturnMenuButton.localPosition = new Vector3(120f,-230f,0f);
        }

        if(swidth <= sheight)
        {
          menuButton.localScale = new Vector3(0.32f,0.32f,1f); menuButton.localPosition = new Vector3(pwidth/2f-10f-menuButton.sizeDelta.x*menuButton.localScale.x/2f,pheight/2f-40f,0f);
          reviewButton.localScale = new Vector3(0.32f,0.32f,1f); reviewButton.localPosition = new Vector3(pwidth/2f-10f-340f*0.3f-10f-340f*0.3f/2f,pheight/2-40f,0f);

          choosePanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          chooseText.localScale = new Vector3(Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f),Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f)/0.6f,1f); chooseText.localPosition = new Vector3(0f,100f,0);
          pvcButton.localScale = new Vector3(0.4f,0.5f,1f); pvcButton.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvcButton.localScale.x,750f),200f); pvcButton.localPosition = new Vector3(0f,-30f,0f);
          pvpButton.localScale = new Vector3(0.4f,0.5f,1f); pvpButton.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvpButton.localScale.x,750f),200f); pvpButton.localPosition = new Vector3(0f,-140f,0f);
          replayButton.sizeDelta = new Vector2(240f,180f); replayButton.localScale = new Vector3(0.3f,0.3f,1f); replayButton.localPosition = new Vector3(Mathf.Min(pwidth/2f-30f-replayButton.sizeDelta.x*replayButton.localScale.x/2f,80f),-230f,0f);

          pvcPanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          pvcText.localScale = new Vector3(Mathf.Min(0.8f*pwidth/pvcTextText.preferredWidth,0.6f),Mathf.Min(0.8f*pwidth/pvcTextText.preferredWidth,0.6f)/0.6f,1f); pvcText.localPosition = new Vector3(0f,100f,0);
          pvc444Button.localScale = new Vector3(0.4f,0.5f,1f); pvc444Button.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvc444Button.localScale.x,750f),200f); pvc444Button.localPosition = new Vector3(0f,-30f,0f);
          pvc464Button.localScale = new Vector3(0.4f,0.5f,1f); pvc464Button.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvc464Button.localScale.x,750f),200f); pvc464Button.localPosition = new Vector3(0f,-140f,0f);
          pvcBackButton.sizeDelta = new Vector2(240f,120f); pvcBackButton.localScale = new Vector3(0.35f,0.35f,1f); pvcBackButton.localPosition = new Vector3(Mathf.Min(pwidth/2f-30f-pvcBackButton.sizeDelta.x*pvcBackButton.localScale.x/2f,80f),-220f,0f);

          pvpPanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          pvpText.localScale = new Vector3(Mathf.Min(0.8f*pwidth/pvpTextText.preferredWidth,0.6f),Mathf.Min(0.8f*pwidth/pvpTextText.preferredWidth,0.6f)/0.6f,1f); pvpText.localPosition = new Vector3(0f,100f,0);
          pvp444Button.localScale = new Vector3(0.4f,0.5f,1f); pvp444Button.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvp444Button.localScale.x,750f),200f); pvp444Button.localPosition = new Vector3(0f,-30f,0f);
          pvp464Button.localScale = new Vector3(0.4f,0.5f,1f); pvp464Button.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvp464Button.localScale.x,750f),200f); pvp464Button.localPosition = new Vector3(0f,-140f,0f);
          pvpBackButton.sizeDelta = new Vector2(240f,120f); pvpBackButton.localScale = new Vector3(0.35f,0.35f,1f); pvpBackButton.localPosition = new Vector3(Mathf.Min(pwidth/2f-30f-pvpBackButton.sizeDelta.x*pvpBackButton.localScale.x/2f,80f),-220f,0f);

          suspendConfirmPanel.localScale = new Vector3(0.2f,0.2f,1f); suspendConfirmPanel.localPosition = new Vector3(0f,-20f,0f);

          tutorialConfirmPanel.localScale = new Vector3(0.2f,0.2f,1f); tutorialConfirmPanel.localPosition = new Vector3(0f,-20f,0f);

          menuPanel.sizeDelta = new Vector2(420f,570f);
          if(pheight/pwidth >= menuPanel.sizeDelta.y/menuPanel.sizeDelta.x){ menuPanel.localScale = new Vector3((pwidth-30f)/menuPanel.sizeDelta.x,(pwidth-30f)/menuPanel.sizeDelta.x,1f); menuPanel.localPosition = new Vector3(0f,pheight/2f-(25f+menuPanel.sizeDelta.y/2f)*menuPanel.localScale.y,0f); }
          else{ menuPanel.localScale = new Vector3((pheight-30f)/menuPanel.sizeDelta.y,(pheight-30f)/menuPanel.sizeDelta.y,1f); menuPanel.localPosition = new Vector3(0f,0f,0f); }
          menuCloseButton.localScale = new Vector3(0.8f,0.8f,1f); menuCloseButton.localPosition = new Vector3(175f,275f,0f);
          menuText.localScale = new Vector3(1.2f,1.2f,1f); menuText.localPosition = new Vector3(0f,230f,0f);
          languageDropdown.sizeDelta = new Vector2(200f,40f); languageDropdown.localScale = new Vector3(0.8f,0.8f,1f); languageDropdown.localPosition = new Vector3(100f,166f,0f);
          languageDropdownText.localPosition = new Vector3(-305f,0f,0f);
          bgmDropdown.sizeDelta = new Vector2(200f,40f); bgmDropdown.localScale = new Vector3(0.8f,0.8f,1f); bgmDropdown.localPosition = new Vector3(100f,108f,0f);
          bgmDropdownText.localPosition = new Vector3(-305f,0f,0f);
          bgmVolumeSlide.sizeDelta = new Vector2(300f,24f); bgmVolumeSlide.localScale = new Vector3(0.8f,0.8f,1f); bgmVolumeSlide.localPosition = new Vector3(70f,50f,0f);
          bgmVolumeSlideText.localPosition = new Vector3(-265f,0f,0f);
          playerTurnDropdown.sizeDelta = new Vector2(200f,40f); playerTurnDropdown.localScale = new Vector3(0.8f,0.8f,1f); playerTurnDropdown.localPosition = new Vector3(100f,-8f,0f);
          playerTurnDropdownText.localPosition = new Vector3(-305f,0f,0f);
          levelDropdown.sizeDelta = new Vector2(200f,40f); levelDropdown.localScale = new Vector3(0.8f,0.8f,1f); levelDropdown.localPosition = new Vector3(100f,-66f,0f);
          levelDropdownText.localPosition = new Vector3(-305f,0f,0f);
          tutorialButton.sizeDelta = new Vector2(125f,50f); tutorialButton.localScale = new Vector3(0.8f,0.8f,1f); tutorialButton.localPosition = new Vector3(120f,-124f,0f);
          tutorialButtonText.localPosition = new Vector3(-335f,0f,0f);
          creditButton.sizeDelta = new Vector2(125f,50f); creditButton.localScale = new Vector3(0.8f,0.8f,1f); creditButton.localPosition = new Vector3(120f,-182f,0f);
          creditButtonText.localPosition = new Vector3(-335f,0f,0f);
          loadTitleButton.sizeDelta = new Vector2(125f,50f); loadTitleButton.localScale = new Vector3(0.8f,0.8f,1f); loadTitleButton.localPosition = new Vector3(120f,-240f,0f);
          loadTitleButtonText.localPosition = new Vector3(-335f,0f,0f);

          creditPanel.sizeDelta = new Vector2(420f,570f);
          if(pheight/pwidth >= creditPanel.sizeDelta.y/creditPanel.sizeDelta.x){ creditPanel.localScale = new Vector3((pwidth-30f)/creditPanel.sizeDelta.x,(pwidth-30f)/creditPanel.sizeDelta.x,1f); creditPanel.localPosition = new Vector3(0f,pheight/2f-(25f+creditPanel.sizeDelta.y/2f)*creditPanel.localScale.y,0f); }
          else{ creditPanel.localScale = new Vector3((pheight-30f)/creditPanel.sizeDelta.y,(pheight-30f)/creditPanel.sizeDelta.y,1f); creditPanel.localPosition = new Vector3(0f,0f,0f); }
          creditCloseButton.localScale = new Vector3(0.8f,0.8f,1f); creditCloseButton.localPosition = new Vector3(175f,275f,0f);
          creditText.localScale = new Vector3(1.2f,1.2f,1f); creditText.localPosition = new Vector3(0f,230f,0f);
          creditScrollView.sizeDelta = new Vector2(380f,320f); creditScrollView.localScale = new Vector3(1f,1f,1f); creditScrollView.localPosition = new Vector3(0f,30f,0f);
          creditContent.sizeDelta = new Vector2(0f,3000f);
          creditIndexText.localScale = new Vector3(0.4f,0.4f,1f); creditIndexText.localPosition = new Vector3(-10f,-150f,0f);
          creditNameText.localScale = new Vector3(0.4f,0.4f,1f); creditNameText.localPosition = new Vector3(0f,-150f,0f);
          LicenseText1.localScale = new Vector3(0.4f,0.4f,1f); LicenseText1.localPosition = new Vector3(-120f,-330f,0f);
          LicenseText2.localScale = new Vector3(0.4f,0.4f,1f); LicenseText2.localPosition = new Vector3(-120f,-1500f,0f);
          creditImage.localScale = new Vector3(0.9f,0.9f,1f); creditImage.localPosition = new Vector3(-85f,-200f,0f);
          creditReturnMenuButton.sizeDelta = new Vector2(200f,60f); creditReturnMenuButton.localScale = new Vector3(0.8f,0.8f,1f); creditReturnMenuButton.localPosition = new Vector3(120f,-230f,0f);
        }
      }

      public void SetLanguage()
      {
        language = PlayerPrefs.GetInt("Value_of_Language", 0);

        if(language == 0)
        {
          menuButtonText.text = "メニュー";

          chooseTextText.text = "3D オセロ";
          pvcButtonText.text = "CPU戦";
          pvpButtonText.text = "一人プレイ";
          replayButtonText.text = "最新の棋譜を\nリプレイ";

          pvcTextText.text = "CPU戦";
          pvcBackButtonText.text = "戻る";

          pvpTextText.text = "一人プレイ";
          pvpBackButtonText.text = "戻る";

          suspendConfirmText.text = "続きからプレイしますか？";
          suspendConfirmYesText.text = "はい";
          suspendConfirmNoText.text = "いいえ";

          tutorialConfirmText.text = "チュートリアルをプレイしますか？\n（Menu からでもプレイできます）";
          tutorialConfirmYesText.text = "はい";
          tutorialConfirmNoText.text = "いいえ";

          menuTextText.text = "メニュー";
          languageDropdownTextText.text = "言語";
          bgmDropdownTextText.text = "BGM選択";
          bgmVolumeSlideTextText.text = "BGM音量";
          playerTurnDropdownDropdown.options[0].text = "先手";
          playerTurnDropdownDropdown.options[1].text = "後手";
          playerTurnDropdownLabelText.text = playerTurnDropdownDropdown.options[PlayerPrefs.GetInt("Value_of_PlayerTurn", 0)].text;
          playerTurnDropdownTextText.text = "CPU戦における手番";
          levelDropdownDropdown.options[0].text = "よわい";
          levelDropdownDropdown.options[1].text = "ふつう";
          levelDropdownDropdown.options[2].text = "つよい";
          levelDropdownDropdown.options[3].text = "とてもつよい";
          levelDropdownLabelText.text = levelDropdownDropdown.options[PlayerPrefs.GetInt("Value_of_CPULevel", 0)].text;
          levelDropdownTextText.text = "CPUのつよさ";
          tutorialButtonTextText.text = "チュートリアルをプレイ";
          tutorialButtonPlayText.text = "プレイ";
          creditButtonTextText.text = "クレジットタイトルを表示";
          creditButtonDisplayText.text = "表示";
          loadTitleButtonTextText.text = "タイトル画面に戻る";
          loadTitleButtonPlayText.text = "戻る";

          creditTextText.text = "クレジット";
          creditIndexTextText.text = "グループ名\n企画\nメインプログラマー\nサブプログラマー\n音楽\nロゴデザイン";
          creditNameTextText.text = "/ D-imensions\n/ カフェラテ\n/ しゃなる\n/ はてぃーぽったー\n/ まっくす\n/ カフェラテ";
          creditReturnMenuButtonText.text = "メニューに戻る";
        }

        if(language == 1)
        {
          menuButtonText.text = "Menu";

          chooseTextText.text = "3D Othello";
          pvcButtonText.text = "PvC Battle";
          pvpButtonText.text = "PvP Battle";
          replayButtonText.text = "Replay";

          pvcTextText.text = "PvC Battle";
          pvcBackButtonText.text = "Back";

          pvpTextText.text = "PvP Battle";
          pvpBackButtonText.text = "Back";

          suspendConfirmText.text = "Do you want to play\nfrom the continuation?";
          suspendConfirmYesText.text = "Yes";
          suspendConfirmNoText.text = "No";

          tutorialConfirmText.text = "Do you want to play the tutorial?\n（You can play it from the Menu.）";
          tutorialConfirmYesText.text = "Yes";
          tutorialConfirmNoText.text = "No";

          menuTextText.text = "Menu";
          languageDropdownTextText.text = "Language";
          bgmDropdownTextText.text = "BGM selection";
          bgmVolumeSlideTextText.text = "BGM volume";
          playerTurnDropdownDropdown.options[0].text = "first move";
          playerTurnDropdownDropdown.options[1].text = "second move";
          playerTurnDropdownLabelText.text = playerTurnDropdownDropdown.options[PlayerPrefs.GetInt("Value_of_PlayerTurn", 0)].text;
          playerTurnDropdownTextText.text = "Turn in a CPU game";
          levelDropdownDropdown.options[0].text = "easy";
          levelDropdownDropdown.options[1].text = "normal";
          levelDropdownDropdown.options[2].text = "hard";
          levelDropdownDropdown.options[3].text = "very hard";
          levelDropdownLabelText.text = levelDropdownDropdown.options[PlayerPrefs.GetInt("Value_of_CPULevel", 0)].text;
          levelDropdownTextText.text = "Difficulty level";
          tutorialButtonTextText.text = "Play the tutorial.";
          tutorialButtonPlayText.text = "Play";
          creditButtonTextText.text = "Display the Credit.";
          creditButtonDisplayText.text = "Open";
          loadTitleButtonTextText.text = "Back to Title.";
          loadTitleButtonPlayText.text = "Back";

          creditTextText.text = "Credit Title";
          creditIndexTextText.text = "Group name\nPlanning\nMain programmer\nSub programmer\nMusic\nLogo design";
          creditNameTextText.text = "/ D-imensions\n/ カフェラテ\n/ しゃなる\n/ はてぃーぽったー\n/ まっくす\n/ カフェラテ";
          creditReturnMenuButtonText.text = "Back to Menu.";
        }
      }
  }
}
