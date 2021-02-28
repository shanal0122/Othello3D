using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Replay
{
  public class UGUI : MonoBehaviour
  {
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private float pwidth; //CanvasScalerのReference Resolution。（幅）
      private float pheight = 600; //CanvasScalerのReference Resolution。Heightで合わせているたためこれが高さの基準になる（高さ）
      private int language;
      public GameObject cameras;
      public GameObject quitConfirmCanvas;
      public GameObject leftCanvas;
      public GameObject rightCanvas;
      public GameObject iconCanvas;
      public GameObject keyCanvas1;
      public GameObject keyCanvas2;
      public GameObject menuCanvas;
      public GameObject instructionCanvas;

      private Camera mainCamera;
      private Camera leftCamera;
      private Camera rightCamera;
      private Camera keyCamera;

      private RectTransform quitConfirmPanel;
      private Text quitConfirmText;
      private Text quitConfirmYesText;
      private Text quitConfirmNoText;

      private RectTransform blackCorkBoardImage;

      private RectTransform whiteCorkBoardImage;
      private RectTransform claimCorkBoardImage;

      private RectTransform menuButton;
      private Text menuButtonText;
      private RectTransform instructionButton;
      private Text instructionButtonText1;
      private RectTransform loadTitleButton;
      private Text loadTitleButtonText;

      private RectTransform backButton1;
      private Text backButton1Text;
      private RectTransform aheadButton1;
      private Text aheadButton1Text;
      private RectTransform replaySlider;
      private Text replaySliderText;

      private RectTransform backButton2;
      private Text backButton2Text;
      private RectTransform aheadButton2;
      private Text aheadButton2Text;

      private RectTransform menuPanel;
      private Text menuIndicateText;
      private Text cameraSensiSliderText;
      private Text stoneSizeSliderText;
      private Text bgmVolumeSliderText;
      private Text instructionButtonText2;
      private Text instructionButtonOpenText;

      private RectTransform instructionPanel;

      void Start()
      {
          mainCamera = cameras.transform.GetChild(0).gameObject.GetComponent<Camera>();
          leftCamera = cameras.transform.GetChild(1).gameObject.GetComponent<Camera>();
          rightCamera = cameras.transform.GetChild(2).gameObject.GetComponent<Camera>();
          keyCamera = cameras.transform.GetChild(3).gameObject.GetComponent<Camera>();

          quitConfirmPanel = quitConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          quitConfirmText = quitConfirmCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          quitConfirmYesText = quitConfirmCanvas.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
          quitConfirmNoText = quitConfirmCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();

          blackCorkBoardImage = leftCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          whiteCorkBoardImage = rightCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          claimCorkBoardImage = rightCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();

          menuButton = iconCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          menuButtonText = iconCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          instructionButton = iconCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          instructionButtonText1 = iconCanvas.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
          loadTitleButton = iconCanvas.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
          loadTitleButtonText = iconCanvas.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>();

          backButton1 = keyCanvas1.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          backButton1Text = keyCanvas1.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          aheadButton1 = keyCanvas1.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          aheadButton1Text = keyCanvas1.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
          replaySlider = keyCanvas1.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
          replaySliderText = keyCanvas1.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>();

          backButton2 = keyCanvas2.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          backButton2Text = keyCanvas2.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          aheadButton2 = keyCanvas2.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          aheadButton2Text = keyCanvas2.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();

          menuPanel = menuCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          menuIndicateText = menuCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          cameraSensiSliderText = menuCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();
          stoneSizeSliderText = menuCanvas.transform.GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<Text>();
          bgmVolumeSliderText = menuCanvas.transform.GetChild(0).GetChild(4).GetChild(0).gameObject.GetComponent<Text>();
          instructionButtonText2 = menuCanvas.transform.GetChild(0).GetChild(5).GetChild(0).gameObject.GetComponent<Text>();
          instructionButtonOpenText = menuCanvas.transform.GetChild(0).GetChild(5).GetChild(1).gameObject.GetComponent<Text>();

          instructionPanel = instructionCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          SetuGUI();
          SetLanguage();
      }

      private void SetuGUI()
      {
        swidth = Screen.width; sheight = Screen.height;
        pwidth = pheight * swidth / sheight;
        //Debug.Log(swidth + " " + sheight + " " + pwidth + " " + pheight);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if(swidth > sheight)
        {
          mainCamera.rect = new Rect(0.25f,0f,0.5f,1f);
          leftCamera.rect = new Rect(0f,0f,0.25f,1f);
          rightCamera.rect = new Rect(0.75f,0f,0.25f,1f);
          cameras.transform.GetChild(3).gameObject.gameObject.SetActive(false);

          quitConfirmPanel.localScale = new Vector3(0.35f,0.35f,1f); quitConfirmPanel.localPosition = new Vector3(0f,-180f,0f);

          leftCanvas.layer = LayerMask.NameToLayer("LeftScreen");
          leftCanvas.GetComponent<Canvas>().worldCamera = leftCamera;
          blackCorkBoardImage.localScale = new Vector3(1f,1f,1f); blackCorkBoardImage.localPosition = new Vector3(0f,-205f,0f);

          whiteCorkBoardImage.localScale = new Vector3(1f,1f,1f); whiteCorkBoardImage.localPosition = new Vector3(0f,-205f,0f);
          claimCorkBoardImage.localScale = new Vector3(1f,1f,1f); claimCorkBoardImage.localPosition = new Vector3(0f,-45f,0f);

          menuButton.localScale = new Vector3(0.5f,0.5f,1f); menuButton.localPosition = new Vector3(0f,240f,0f);
          instructionButton.localScale = new Vector3(0.5f,0.5f,1f); instructionButton.localPosition = new Vector3(0f,170f,0f);
          loadTitleButton.localScale = new Vector3(0.5f,0.5f,1f); loadTitleButton.localPosition = new Vector3(0f,90f,0f);

          keyCanvas1.layer = LayerMask.NameToLayer("LeftScreen");
          keyCanvas1.GetComponent<Canvas>().worldCamera = leftCamera;

          backButton1.localScale = new Vector3(1f,1f,1f); backButton1.localPosition = new Vector3(-50f,-10f,0f);
          aheadButton1.localScale = new Vector3(1f,1f,1f); aheadButton1.localPosition = new Vector3(50f,-10f,0f);
          replaySlider.localScale = new Vector3(1f,1f,1f); replaySlider.localPosition = new Vector3(29f,-85f,0f);

          keyCanvas2.GetComponent<Canvas>().enabled = false;

          menuCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
          menuPanel.localScale = new Vector3(1f,1f,1f); menuPanel.localPosition = new Vector3(0f,95f,0f);

          instructionCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
          instructionPanel.localScale = new Vector3(1f,1f,1f); instructionPanel.localPosition = new Vector3(0f,95f,0f);
        }

        if(swidth <= sheight)
        {
          float aspect = sheight / swidth;

          float magni = Mathf.Min(1.4f/aspect,1f);
          mainCamera.rect = new Rect(0f,0.12f*magni,1f,1f-0.39f*magni);
          leftCamera.rect = new Rect(0f,1f-0.07f*magni,1f,0.07f*magni);
          rightCamera.rect = new Rect(0f,1f-0.27f*magni,1f,0.2f*magni);
          keyCamera.rect = new Rect(0f,0f,1f,0.12f*magni);

          mainCamera.fieldOfView = Mathf.Max(30.74f+18.45f*aspect,55f);

          quitConfirmPanel.localScale = new Vector3(0.25f,0.25f,1f); quitConfirmPanel.localPosition = new Vector3(0f,-160f,0f);

          leftCanvas.layer = LayerMask.NameToLayer("RightScreen");
          leftCanvas.GetComponent<Canvas>().worldCamera = rightCamera;
          blackCorkBoardImage.localScale = new Vector3(magni*0.7f,magni*0.7f,1f); blackCorkBoardImage.localPosition = new Vector3(-140f*magni,0f,0f);

          whiteCorkBoardImage.localScale = new Vector3(magni*0.7f,magni*0.7f,1f); whiteCorkBoardImage.localPosition = new Vector3(140f*magni,0f,0f);
          claimCorkBoardImage.localScale = new Vector3(magni*0.6f,magni*0.65f,1f); claimCorkBoardImage.localPosition = new Vector3(0f,0f,0f);

          menuButton.localScale = new Vector3(magni*0.3f,magni*0.3f,1f); menuButton.localPosition = new Vector3(0f,0f,0f);
          instructionButton.gameObject.SetActive(false);
          loadTitleButton.localScale = new Vector3(magni*0.3f,magni*0.3f,1f); loadTitleButton.localPosition = new Vector3(160f*magni,0f,0f);

          keyCanvas1.layer = LayerMask.NameToLayer("KeyScreen");
          keyCanvas1.GetComponent<Canvas>().worldCamera = keyCamera;

          backButton1.gameObject.SetActive(false);
          aheadButton1.gameObject.SetActive(false);
          replaySlider.localScale = new Vector3(magni,magni,1f);
          replaySlider.sizeDelta = new Vector2(0.8f*pwidth/magni-0.9f*replaySlider.transform.GetChild(0).gameObject.GetComponent<Text>().preferredWidth,20f); replaySlider.localPosition = new Vector3(37f*magni,0f,0f);

          backButton2.localScale = new Vector3(magni,magni,1f); backButton2.localPosition = new Vector3(-167.5f*magni,(233f*magni-pheight)/2f,0f);
          aheadButton2.localScale = new Vector3(magni,magni,1f); aheadButton2.localPosition = new Vector3(167.5f*magni,(233f*magni-pheight)/2f,0f);

          magni = Mathf.Min(0.9f*pwidth/220f,0.9f*pheight/380f);
          float pos = (0.9f*pheight-magni*380f)/2f;
          menuCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
          menuPanel.localScale = new Vector3(magni,magni,1f); menuPanel.localPosition = new Vector3(0f,pos,0f);

          instructionCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
          instructionPanel.localScale = new Vector3(magni,magni,1f); instructionPanel.localPosition = new Vector3(0f,pos,0f);
        }
      }

      public void SetLanguage()
      {
        language = PlayerPrefs.GetInt("Value_of_Language", 0);

        if(language == 0)
        {
          quitConfirmText.text = "リプレイを終了しますか？";
          quitConfirmYesText.text = "はい";
          quitConfirmNoText.text = "いいえ";

          menuButtonText.text = "メニュー";
          instructionButtonText1.text = "操作説明";
          loadTitleButtonText.text = "タイトルに戻る";

          backButton1Text.text = "１手戻る";
          aheadButton1Text.text = "１手進む";
          replaySliderText.text = "手番を\n進める";

          backButton2Text.text = "１手戻る";
          aheadButton2Text.text = "１手進む";

          menuIndicateText.text = "設定";
          cameraSensiSliderText.text = "カメラ感度\n(９段階)";
          stoneSizeSliderText.text = "石の大きさ\n(９段階)";
          bgmVolumeSliderText.text = "BGM音量";
          instructionButtonText2.text = "操作説明";
          instructionButtonOpenText.text = "ひらく";
        }

        if(language == 1)
        {
          quitConfirmText.text = "Quit Replay?";
          quitConfirmYesText.text = "Yes";
          quitConfirmNoText.text = "No";

          menuButtonText.text = "Menu";
          instructionButtonText1.text = "Instruction";
          loadTitleButtonText.text = "Back to Title.";

          backButton1Text.text = "Back";
          aheadButton1Text.text = "Forward";
          replaySliderText.text = "Move\nsteps.";

          backButton2Text.text = "Back";
          aheadButton2Text.text = "Forward";

          menuIndicateText.text = "Settings";
          cameraSensiSliderText.text = "Sensitivity\n(9 levels)";
          stoneSizeSliderText.text = "Stone size\n(9 levels)";
          bgmVolumeSliderText.text = "BGM";
          instructionButtonText2.text = "Instructions";
          instructionButtonOpenText.text = "Open";
        }
      }
  }
}
