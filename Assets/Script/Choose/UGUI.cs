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
      public GameObject optionCanvas;
      public GameObject chooseCanvas;
      public GameObject pvcCanvas;
      public GameObject pvpCanvas;
      public GameObject suspendConfirmCanvas;
      public GameObject tutorialConfirmCanvas;
      public GameObject menuCanvas;
      public GameObject creditCanvas;

      private RectTransform menuButton;

      private RectTransform choosePanel;
      private RectTransform chooseText;
      private Text chooseTextText;
      private RectTransform pvcButton;
      private RectTransform pvpButton;
      private RectTransform replayButton;

      private RectTransform pvcPanel;
      private RectTransform pvcText;
      private Text pvcTextText;
      private RectTransform pvc444Button;
      private RectTransform pvc464Button;
      private RectTransform pvcBackButton;

      private RectTransform pvpPanel;
      private RectTransform pvpText;
      private Text pvpTextText;
      private RectTransform pvp444Button;
      private RectTransform pvp464Button;
      private RectTransform pvpBackButton;

      private RectTransform suspendConfirmPanel;

      private RectTransform tutorialConfirmPanel;

      private RectTransform menuPanel;
      private RectTransform menuCloseButton;
      private RectTransform menuText;
      private Text menuTextText;
      private RectTransform bgmDropdown;
      private RectTransform bgmDropdownText;
      private RectTransform bgmVolumeSlide;
      private RectTransform bgmVolumeSlideText;
      private RectTransform playerTurnDropdown;
      private RectTransform playerTurnDropdownText;
      private RectTransform levelDropdown;
      private RectTransform levelDropdownText;
      private RectTransform tutorialButton;
      private RectTransform tutorialButtonText;
      private RectTransform creditButton;
      private RectTransform creditButtonText;
      private RectTransform loadTitleButton;
      private RectTransform loadTitleButtonText;

      private RectTransform creditPanel;
      private RectTransform creditCloseButton;
      private RectTransform creditText;
      private Text creditTextText;
      private RectTransform creditScrollView;
      private RectTransform creditContent;
      private RectTransform creditIndexText;
      private RectTransform creditNameText;
      private RectTransform LicenseText1;
      private RectTransform creditImage;
      private RectTransform creditReturnMenuButton;

      void Start()
      {
        menuButton = optionCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

        choosePanel = chooseCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        chooseText = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        chooseTextText = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        pvcButton = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        pvpButton = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        replayButton = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();

        pvcPanel = pvcCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        pvcText = pvcCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        pvcTextText = pvcCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        pvc444Button = pvcCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        pvc464Button = pvcCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        pvcBackButton = pvcCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();

        pvpPanel = pvpCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        pvpText = pvpCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        pvpTextText = pvpCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        pvp444Button = pvpCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        pvp464Button = pvpCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        pvpBackButton = pvpCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();

        suspendConfirmPanel = suspendConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

        tutorialConfirmPanel = tutorialConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

        menuPanel = menuCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        menuCloseButton = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        menuText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        menuTextText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        bgmDropdown = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        bgmDropdownText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        bgmVolumeSlide = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
        bgmVolumeSlideText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        playerTurnDropdown = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.GetComponent<RectTransform>();
        playerTurnDropdownText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        levelDropdown = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.GetComponent<RectTransform>();
        levelDropdownText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        tutorialButton = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject.GetComponent<RectTransform>();
        tutorialButtonText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        creditButton = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(7).gameObject.GetComponent<RectTransform>();
        creditButtonText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        loadTitleButton = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(8).gameObject.GetComponent<RectTransform>();
        loadTitleButtonText = menuCanvas.transform.GetChild(0).gameObject.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

        creditPanel = creditCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        creditCloseButton = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        creditText = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        creditTextText = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        creditScrollView = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        creditContent = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        creditIndexText = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        creditNameText = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        LicenseText1 = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        creditImage = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
        creditReturnMenuButton = creditCanvas.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.GetComponent<RectTransform>();

        SetuGUI();
      }

      public void SetuGUI()
      {
        swidth = Screen.width; sheight = Screen.height;
        pwidth = pheight * swidth / sheight;
        //Debug.Log(swidth + " " + sheight + " " + pwidth + " " + pheight);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if(swidth > sheight)
        {
          menuButton.localScale = new Vector3(0.5f,0.5f,1f); menuButton.localPosition = new Vector3(360f,230f,0f);

          choosePanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          chooseText.localScale = new Vector3(1.2f,1.4f,1f); chooseText.localPosition = new Vector3(0f,100f,0);
          pvcButton.sizeDelta = new Vector2(750f,500f); pvcButton.localScale = new Vector3(0.5f,0.5f,1f); pvcButton.localPosition = new Vector3(-250f,-120f,0f);
          pvpButton.sizeDelta = new Vector2(750f,500f); pvpButton.localScale = new Vector3(0.5f,0.5f,1f); pvpButton.localPosition = new Vector3(130f,-120f,0f);
          replayButton.sizeDelta = new Vector2(240f,180f); replayButton.localScale = new Vector3(0.5f,0.5f,1f); replayButton.localPosition = new Vector3(380f,-200f,0f);

          pvcPanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          pvcText.localScale = new Vector3(1.2f,1.4f,1f); pvcText.localPosition = new Vector3(0f,100f,0);
          pvc444Button.sizeDelta = new Vector2(750f,500f); pvc444Button.localScale = new Vector3(0.5f,0.5f,1f); pvc444Button.localPosition = new Vector3(-250f,-120f,0f);
          pvc464Button.sizeDelta = new Vector2(750f,500f); pvc464Button.localScale = new Vector3(0.5f,0.5f,1f); pvc464Button.localPosition = new Vector3(130f,-120f,0f);
          pvcBackButton.sizeDelta = new Vector2(240f,120f); pvcBackButton.localScale = new Vector3(0.5f,0.5f,1f); pvcBackButton.localPosition = new Vector3(390f,-200f,0f);

          pvpPanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          pvpText.localScale = new Vector3(1.2f,1.4f,1f); pvpText.localPosition = new Vector3(0f,100f,0);
          pvp444Button.sizeDelta = new Vector2(750f,500f); pvp444Button.localScale = new Vector3(0.5f,0.5f,1f); pvp444Button.localPosition = new Vector3(-250f,-120f,0f);
          pvp464Button.sizeDelta = new Vector2(750f,500f); pvp464Button.localScale = new Vector3(0.5f,0.5f,1f); pvp464Button.localPosition = new Vector3(130f,-120f,0f);
          pvpBackButton.sizeDelta = new Vector2(240f,120f); pvpBackButton.localScale = new Vector3(0.5f,0.5f,1f); pvpBackButton.localPosition = new Vector3(390f,-200f,0f);

          suspendConfirmPanel.localScale = new Vector3(0.3f,0.3f,1f); suspendConfirmPanel.localPosition = new Vector3(0f,0f,0f);

          tutorialConfirmPanel.localScale = new Vector3(0.3f,0.3f,1f); tutorialConfirmPanel.localPosition = new Vector3(0f,0f,0f);

          menuPanel.sizeDelta = new Vector2(640f,540f); menuPanel.localScale = new Vector3(1f,1f,1f); menuPanel.localPosition = new Vector3(0f,0f,0f);
          menuCloseButton.localScale = new Vector3(1f,1f,1f); menuCloseButton.localPosition = new Vector3(275f,255f,0f);
          menuText.localScale = new Vector3(0.6f,0.6f,1f); menuText.localPosition = new Vector3(0f,230f,0f);
          bgmDropdown.sizeDelta = new Vector2(200f,40f); bgmDropdown.localScale = new Vector3(1f,1f,1f); bgmDropdown.localPosition = new Vector3(130f,160f,0f);
          bgmDropdownText.localPosition = new Vector3(-330f,0f,0f);
          bgmVolumeSlide.sizeDelta = new Vector2(360f,24f); bgmVolumeSlide.localScale = new Vector3(1f,1f,1f); bgmVolumeSlide.localPosition = new Vector3(110f,95f,0f);
          bgmVolumeSlideText.localPosition = new Vector3(-310f,0f,0f);
          playerTurnDropdown.sizeDelta = new Vector2(200f,40f); playerTurnDropdown.localScale = new Vector3(1f,1f,1f); playerTurnDropdown.localPosition = new Vector3(130f,30f,0f);
          playerTurnDropdownText.localPosition = new Vector3(-275f,0f,0f);
          levelDropdown.sizeDelta = new Vector2(200f,40f); levelDropdown.localScale = new Vector3(1f,1f,1f); levelDropdown.localPosition = new Vector3(130f,-35f,0f);
          levelDropdownText.localPosition = new Vector3(-300f,0f,0f);
          tutorialButton.sizeDelta = new Vector2(120f,45f); tutorialButton.localScale = new Vector3(1f,1f,1f); tutorialButton.localPosition = new Vector3(145f,-100f,0f);
          tutorialButtonText.localPosition = new Vector3(-270f,0f,0f);
          creditButton.sizeDelta = new Vector2(120f,45f); creditButton.localScale = new Vector3(1f,1f,1f); creditButton.localPosition = new Vector3(145f,-165f,0f);
          creditButtonText.localPosition = new Vector3(-260f,0f,0f);
          loadTitleButton.sizeDelta = new Vector2(120f,45f); loadTitleButton.localScale = new Vector3(1f,1f,1f); loadTitleButton.localPosition = new Vector3(145f,-230f,0f);
          loadTitleButtonText.localPosition = new Vector3(-297f,0f,0f);

          creditPanel.sizeDelta = new Vector2(640f,540f); creditPanel.localScale = new Vector3(1f,1f,1f); creditPanel.localPosition = new Vector3(0f,0f,0f);
          creditCloseButton.localScale = new Vector3(1f,1f,1f); creditCloseButton.localPosition = new Vector3(275f,255f,0f);
          creditText.localScale = new Vector3(0.6f,0.6f,1f); creditText.localPosition = new Vector3(0f,230f,0f);
          creditScrollView.sizeDelta = new Vector2(600f,320f); creditScrollView.localScale = new Vector3(1f,1f,1f); creditScrollView.localPosition = new Vector3(0f,30f,0f);
          creditContent.sizeDelta = new Vector2(0f,2400f);
          creditIndexText.localScale = new Vector3(0.72f,0.72f,1f); creditIndexText.localPosition = new Vector3(-2f,-160f,0f);
          creditNameText.localScale = new Vector3(0.72f,0.72f,1f); creditNameText.localPosition = new Vector3(17f,-160f,0f);
          LicenseText1.localScale = new Vector3(0.7f,0.7f,1f); LicenseText1.localPosition = new Vector3(-220f,-400f,0f);
          creditImage.localScale = new Vector3(1f,1f,1f); creditImage.localPosition = new Vector3(-160f,-200f,0f);
          creditReturnMenuButton.sizeDelta = new Vector2(200f,50f); creditReturnMenuButton.localScale = new Vector3(1f,1.2f,1f); creditReturnMenuButton.localPosition = new Vector3(120f,-230f,0f);
        }

        if(swidth <= sheight)
        {
          menuButton.localScale = new Vector3(0.3f,0.3f,1f); menuButton.localPosition = new Vector3(pwidth/2f-10f-menuButton.sizeDelta.x*menuButton.localScale.x/2f,pheight/2f-40f,0f);

          choosePanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          chooseText.localScale = new Vector3(Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f),Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f)/0.6f,1f); chooseText.localPosition = new Vector3(0f,100f,0);
          pvcButton.localScale = new Vector3(0.4f,0.5f,1f); pvcButton.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvcButton.localScale.x,750f),200f); pvcButton.localPosition = new Vector3(0f,-30f,0f);
          pvpButton.localScale = new Vector3(0.4f,0.5f,1f); pvpButton.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvpButton.localScale.x,750f),200f); pvpButton.localPosition = new Vector3(0f,-140f,0f);
          replayButton.sizeDelta = new Vector2(240f,180f); replayButton.localScale = new Vector3(0.3f,0.3f,1f); replayButton.localPosition = new Vector3(Mathf.Min(pwidth/2f-30f-replayButton.sizeDelta.x*replayButton.localScale.x/2f,80f),-230f,0f);

          pvcPanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          pvcText.localScale = new Vector3(Mathf.Min(0.8f*pwidth/pvcTextText.preferredWidth,0.6f),Mathf.Min(0.8f*pwidth/pvcTextText.preferredWidth,0.6f)/0.6f,1f); pvcText.localPosition = new Vector3(0f,100f,0);
          pvc444Button.localScale = new Vector3(0.4f,0.5f,1f); pvc444Button.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvc444Button.localScale.x,750f),200f); pvc444Button.localPosition = new Vector3(0f,-30f,0f);
          pvc464Button.localScale = new Vector3(0.4f,0.5f,1f); pvc464Button.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvc464Button.localScale.x,750f),200f); pvc464Button.localPosition = new Vector3(0f,-140f,0f);
          pvcBackButton.sizeDelta = new Vector2(240f,120f); pvcBackButton.localScale = new Vector3(0.3f,0.3f,1f); pvcBackButton.localPosition = new Vector3(Mathf.Min(pwidth/2f-30f-pvcBackButton.sizeDelta.x*pvcBackButton.localScale.x/2f,80f),-220f,0f);

          pvpPanel.sizeDelta = new Vector2(pwidth+10f,pheight+10f);
          pvpText.localScale = new Vector3(Mathf.Min(0.8f*pwidth/pvpTextText.preferredWidth,0.6f),Mathf.Min(0.8f*pwidth/pvpTextText.preferredWidth,0.6f)/0.6f,1f); pvpText.localPosition = new Vector3(0f,100f,0);
          pvp444Button.localScale = new Vector3(0.4f,0.5f,1f); pvp444Button.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvp444Button.localScale.x,750f),200f); pvp444Button.localPosition = new Vector3(0f,-30f,0f);
          pvp464Button.localScale = new Vector3(0.4f,0.5f,1f); pvp464Button.sizeDelta = new Vector2(Mathf.Min(0.94f*pwidth/pvp464Button.localScale.x,750f),200f); pvp464Button.localPosition = new Vector3(0f,-140f,0f);
          pvpBackButton.sizeDelta = new Vector2(240f,120f); pvpBackButton.localScale = new Vector3(0.3f,0.3f,1f); pvpBackButton.localPosition = new Vector3(Mathf.Min(pwidth/2f-30f-pvpBackButton.sizeDelta.x*pvpBackButton.localScale.x/2f,80f),-220f,0f);

          suspendConfirmPanel.localScale = new Vector3(0.2f,0.2f,1f); suspendConfirmPanel.localPosition = new Vector3(0f,-20f,0f);

          tutorialConfirmPanel.localScale = new Vector3(0.2f,0.2f,1f); tutorialConfirmPanel.localPosition = new Vector3(0f,-20f,0f);

          menuPanel.sizeDelta = new Vector2(420f,570f);
          if(pheight/pwidth >= menuPanel.sizeDelta.y/menuPanel.sizeDelta.x){ menuPanel.localScale = new Vector3((pwidth-30f)/menuPanel.sizeDelta.x,(pwidth-30f)/menuPanel.sizeDelta.x,1f); menuPanel.localPosition = new Vector3(0f,pheight/2f-(25f+menuPanel.sizeDelta.y/2f)*menuPanel.localScale.y,0f); }
          else{ menuPanel.localScale = new Vector3((pheight-30f)/menuPanel.sizeDelta.y,(pheight-30f)/menuPanel.sizeDelta.y,1f); menuPanel.localPosition = new Vector3(0f,0f,0f); }
          menuCloseButton.localScale = new Vector3(0.8f,0.8f,1f); menuCloseButton.localPosition = new Vector3(175f,275f,0f);
          menuText.localScale = new Vector3(1.2f,1.2f,1f); menuText.localPosition = new Vector3(0f,230f,0f);
          bgmDropdown.sizeDelta = new Vector2(200f,40f); bgmDropdown.localScale = new Vector3(0.8f,0.8f,1f); bgmDropdown.localPosition = new Vector3(100f,160f,0f);
          bgmDropdownText.localPosition = new Vector3(-300f,0f,0f);
          bgmVolumeSlide.sizeDelta = new Vector2(300f,24f); bgmVolumeSlide.localScale = new Vector3(0.8f,0.8f,1f); bgmVolumeSlide.localPosition = new Vector3(70f,95f,0f);
          bgmVolumeSlideText.localPosition = new Vector3(-265f,0f,0f);
          playerTurnDropdown.sizeDelta = new Vector2(200f,40f); playerTurnDropdown.localScale = new Vector3(0.8f,0.8f,1f); playerTurnDropdown.localPosition = new Vector3(100f,30f,0f);
          playerTurnDropdownText.localPosition = new Vector3(-243f,0f,0f);
          levelDropdown.sizeDelta = new Vector2(200f,40f); levelDropdown.localScale = new Vector3(0.8f,0.8f,1f); levelDropdown.localPosition = new Vector3(100f,-35f,0f);
          levelDropdownText.localPosition = new Vector3(-270f,0f,0f);
          tutorialButton.sizeDelta = new Vector2(125f,50f); tutorialButton.localScale = new Vector3(0.8f,0.8f,1f); tutorialButton.localPosition = new Vector3(120f,-100f,0f);
          tutorialButtonText.localPosition = new Vector3(-247f,0f,0f);
          creditButton.sizeDelta = new Vector2(125f,50f); creditButton.localScale = new Vector3(0.8f,0.8f,1f); creditButton.localPosition = new Vector3(120f,-165f,0f);
          creditButtonText.localPosition = new Vector3(-238f,0f,0f);
          loadTitleButton.sizeDelta = new Vector2(125f,50f); loadTitleButton.localScale = new Vector3(0.8f,0.8f,1f); loadTitleButton.localPosition = new Vector3(120f,-230f,0f);
          loadTitleButtonText.localPosition = new Vector3(-277f,0f,0f);

          creditPanel.sizeDelta = new Vector2(420f,570f);
          if(pheight/pwidth >= creditPanel.sizeDelta.y/creditPanel.sizeDelta.x){ creditPanel.localScale = new Vector3((pwidth-30f)/creditPanel.sizeDelta.x,(pwidth-30f)/creditPanel.sizeDelta.x,1f); creditPanel.localPosition = new Vector3(0f,pheight/2f-(25f+creditPanel.sizeDelta.y/2f)*creditPanel.localScale.y,0f); }
          else{ creditPanel.localScale = new Vector3((pheight-30f)/creditPanel.sizeDelta.y,(pheight-30f)/creditPanel.sizeDelta.y,1f); creditPanel.localPosition = new Vector3(0f,0f,0f); }
          creditCloseButton.localScale = new Vector3(0.8f,0.8f,1f); creditCloseButton.localPosition = new Vector3(175f,275f,0f);
          creditText.localScale = new Vector3(1.2f,1.2f,1f); creditText.localPosition = new Vector3(0f,230f,0f);
          creditScrollView.sizeDelta = new Vector2(380f,320f); creditScrollView.localScale = new Vector3(1f,1f,1f); creditScrollView.localPosition = new Vector3(0f,30f,0f);
          creditContent.sizeDelta = new Vector2(0f,1500f);
          creditIndexText.localScale = new Vector3(0.4f,0.4f,1f); creditIndexText.localPosition = new Vector3(-10f,-150f,0f);
          creditNameText.localScale = new Vector3(0.4f,0.4f,1f); creditNameText.localPosition = new Vector3(0f,-150f,0f);
          LicenseText1.localScale = new Vector3(0.4f,0.4f,1f); LicenseText1.localPosition = new Vector3(-120f,-330f,0f);
          creditImage.localScale = new Vector3(0.9f,0.9f,1f); creditImage.localPosition = new Vector3(-85f,-200f,0f);
          creditReturnMenuButton.sizeDelta = new Vector2(200f,60f); creditReturnMenuButton.localScale = new Vector3(0.8f,0.8f,1f); creditReturnMenuButton.localPosition = new Vector3(120f,-230f,0f);
        }
      }
  }
}
