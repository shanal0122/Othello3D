using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvP
{
  public class UGUI : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //オセロ盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private float pwidth; //CanvasScalerのReference Resolution。（幅）
      private float pheight = 600; //CanvasScalerのReference Resolution。Heightで合わせているたためこれが高さの基準になる（高さ）
      private int language;
      public GameObject cameras;
      public GameObject centerCanvas;
      public GameObject saveConfirmCanvas;
      public GameObject quitConfirmCanvas;
      public GameObject leftCanvas;
      public GameObject rightCanvas;
      public GameObject iconCanvas;
      public GameObject keyCanvas1;
      public GameObject keyCanvas2;
      public GameObject menuCanvas;
      public GameObject instructionCanvas1;
      public GameObject instructionCanvas2;

      private Camera mainCamera;
      private Camera leftCamera;
      private Camera rightCamera;
      private Camera keyCamera;

      private RectTransform resultText;
      private Text resultTextText;
      private RectTransform playAgainButton;
      private Text playAgainButtonText;

      private RectTransform saveConfirmPanel;
      private Text saveConfirmText;
      private Text saveConfirmYesText;
      private Text saveConfirmNoText;

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
      private RectTransform cancelButton;
      private Text cancelButtonText;
      private RectTransform loadTitleButton;
      private Text loadTitleButtonText;

      private RectTransform keyBackspaceButton1;
      private Text keyBackspaceButton1Text;
      private RectTransform key1Button;
      private RectTransform key2Button;
      private RectTransform key3Button;
      private RectTransform key4Button;
      private RectTransform key5Button;
      private RectTransform key6Button;
      private RectTransform keyReturnButton1;
      private Text keyReturnButton1Text;

      private RectTransform keyBackspaceButton2;
      private Text keyBackspaceButton2Text;
      private RectTransform keyReturnButton2;
      private Text keyReturnButton2Text;

      private RectTransform menuPanel;
      private Text menuIndicateText;
      private Text cameraSensiSliderText;
      private Text putableButtonText;
      private Text stoneSizeSliderText;
      private Text bgmVolumeSliderText;
      private Text instructionButtonText2;
      private Text instructionButtonOpenText;

      private RectTransform instructionPanel1;
      private Text instructionText1;
      private Text nextButtonText1;

      private RectTransform instructionPanel2;
      private Text instructionText2_1;
      private Text instructionText2_2;
      private Text prevButtonText2;

      void Start()
      {
          mainCamera = cameras.transform.GetChild(0).gameObject.GetComponent<Camera>();
          leftCamera = cameras.transform.GetChild(1).gameObject.GetComponent<Camera>();
          rightCamera = cameras.transform.GetChild(2).gameObject.GetComponent<Camera>();
          keyCamera = cameras.transform.GetChild(3).gameObject.GetComponent<Camera>();

          resultText = centerCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          resultTextText = centerCanvas.transform.GetChild(0).gameObject.GetComponent<Text>();
          playAgainButton = centerCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          playAgainButtonText = centerCanvas.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();

          saveConfirmPanel = saveConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          saveConfirmText = saveConfirmCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          saveConfirmYesText = saveConfirmCanvas.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
          saveConfirmNoText = saveConfirmCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();

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
          cancelButton = iconCanvas.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
          cancelButtonText = iconCanvas.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>();
          loadTitleButton = iconCanvas.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
          loadTitleButtonText = iconCanvas.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Text>();

          keyBackspaceButton1 = keyCanvas1.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          keyBackspaceButton1Text = keyCanvas1.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          key1Button = keyCanvas1.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          key2Button = keyCanvas1.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
          key3Button = keyCanvas1.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
          key4Button = keyCanvas1.transform.GetChild(4).gameObject.GetComponent<RectTransform>();
          key5Button = keyCanvas1.transform.GetChild(5).gameObject.GetComponent<RectTransform>();
          key6Button = keyCanvas1.transform.GetChild(6).gameObject.GetComponent<RectTransform>();
          keyReturnButton1 = keyCanvas1.transform.GetChild(7).gameObject.GetComponent<RectTransform>();
          keyReturnButton1Text = keyCanvas1.transform.GetChild(7).GetChild(0).gameObject.GetComponent<Text>();

          keyBackspaceButton2 = keyCanvas2.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          keyBackspaceButton2Text = keyCanvas2.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          keyReturnButton2 = keyCanvas2.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          keyReturnButton2Text = keyCanvas2.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();

          menuPanel = menuCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          menuIndicateText = menuCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          cameraSensiSliderText = menuCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();
          putableButtonText = menuCanvas.transform.GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<Text>();
          stoneSizeSliderText = menuCanvas.transform.GetChild(0).GetChild(4).GetChild(0).gameObject.GetComponent<Text>();
          bgmVolumeSliderText = menuCanvas.transform.GetChild(0).GetChild(5).GetChild(0).gameObject.GetComponent<Text>();
          instructionButtonText2 = menuCanvas.transform.GetChild(0).GetChild(6).GetChild(0).gameObject.GetComponent<Text>();
          instructionButtonOpenText = menuCanvas.transform.GetChild(0).GetChild(6).GetChild(1).gameObject.GetComponent<Text>();

          instructionPanel1 = instructionCanvas1.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          instructionText1 = instructionCanvas1.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          nextButtonText1 = instructionCanvas1.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();

          instructionPanel2 = instructionCanvas2.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          instructionText2_1 = instructionCanvas2.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          instructionText2_2 = instructionCanvas2.transform.GetChild(0).GetChild(4).gameObject.GetComponent<Text>();
          prevButtonText2= instructionCanvas2.transform.GetChild(0).GetChild(6).GetChild(0).gameObject.GetComponent<Text>();

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

          resultText.localScale = new Vector3(1f,1f,1f); resultText.localPosition = new Vector3(0f,100f,0f);
          playAgainButton.localScale = new Vector3(1f,1f,1f); playAgainButton.localPosition = new Vector3(0f,-220f,0f);

          saveConfirmPanel.localScale = new Vector3(0.35f,0.35f,1f); saveConfirmPanel.localPosition = new Vector3(0f,-180f,0f);

          quitConfirmPanel.localScale = new Vector3(0.35f,0.35f,1f); quitConfirmPanel.localPosition = new Vector3(0f,-180f,0f);

          leftCanvas.layer = LayerMask.NameToLayer("LeftScreen");
          leftCanvas.GetComponent<Canvas>().worldCamera = leftCamera;
          blackCorkBoardImage.localScale = new Vector3(1f,1f,1f); blackCorkBoardImage.localPosition = new Vector3(0f,-205f,0f);

          whiteCorkBoardImage.localScale = new Vector3(1f,1f,1f); whiteCorkBoardImage.localPosition = new Vector3(0f,-205f,0f);
          claimCorkBoardImage.localScale = new Vector3(1f,1f,1f); claimCorkBoardImage.localPosition = new Vector3(0f,-45f,0f);

          menuButton.localScale = new Vector3(0.5f,0.5f,1f); menuButton.localPosition = new Vector3(0f,240f,0f);
          instructionButton.localScale = new Vector3(0.5f,0.5f,1f); instructionButton.localPosition = new Vector3(0f,170f,0f);
          cancelButton.localScale = new Vector3(0.5f,0.5f,1f); cancelButton.localPosition = new Vector3(0f,100f,0f);
          loadTitleButton.localScale = new Vector3(0.5f,0.5f,1f); loadTitleButton.localPosition = new Vector3(0f,0f,0f);

          keyCanvas1.SetActive(false);
          keyCanvas2.SetActive(false);

          menuCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
          menuPanel.localScale = new Vector3(1f,1f,1f); menuPanel.localPosition = new Vector3(0f,95f,0f);

          instructionCanvas1.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
          instructionPanel1.localScale = new Vector3(1f,1f,1f); instructionPanel1.localPosition = new Vector3(0f,95f,0f);

          instructionCanvas2.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
          instructionPanel2.localScale = new Vector3(1f,1f,1f); instructionPanel2.localPosition = new Vector3(0f,95f,0f);
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

          magni = Mathf.Min(0.8f*pwidth/0.6f/resultTextText.preferredWidth,1f);
          resultText.localScale = new Vector3(0.6f*magni,0.6f*magni,1f); resultText.localPosition = new Vector3(0f,70f,0f);
          playAgainButton.localScale = new Vector3(0.6f*magni,0.6f*magni,1f); playAgainButton.localPosition = new Vector3(0f,-140f,0f);

          saveConfirmPanel.localScale = new Vector3(0.25f,0.25f,1f); saveConfirmPanel.localPosition = new Vector3(0f,-160f,0f);

          quitConfirmPanel.localScale = new Vector3(0.25f,0.25f,1f); quitConfirmPanel.localPosition = new Vector3(0f,-160f,0f);

          magni = Mathf.Min(1.4f/aspect,1f);
          leftCanvas.layer = LayerMask.NameToLayer("RightScreen");
          leftCanvas.GetComponent<Canvas>().worldCamera = rightCamera;
          blackCorkBoardImage.localScale = new Vector3(magni*0.7f,magni*0.7f,1f); blackCorkBoardImage.localPosition = new Vector3(-140f*magni,0f,0f);

          whiteCorkBoardImage.localScale = new Vector3(magni*0.7f,magni*0.7f,1f); whiteCorkBoardImage.localPosition = new Vector3(140f*magni,0f,0f);
          claimCorkBoardImage.localScale = new Vector3(magni*0.6f,magni*0.65f,1f); claimCorkBoardImage.localPosition = new Vector3(0f,0f,0f);

          menuButton.localScale = new Vector3(magni*0.3f,magni*0.3f,1f); menuButton.localPosition = new Vector3(0f,0f,0f);
          instructionButton.gameObject.SetActive(false);
          cancelButton.localScale = new Vector3(magni*0.3f,magni*0.3f,1f); cancelButton.localPosition = new Vector3(-160f*magni,0f,0f);
          loadTitleButton.localScale = new Vector3(magni*0.3f,magni*0.3f,1f); loadTitleButton.localPosition = new Vector3(160f*magni,0f,0f);

          if(yLength == 4)
          {
            keyBackspaceButton1.localScale = new Vector3(magni,magni,1f); keyBackspaceButton1.localPosition = new Vector3(-177.5f*magni,0f,0f);
            key1Button.localScale = new Vector3(magni,magni,1f); key1Button.localPosition = new Vector3(-106.5f*magni,0f,0f);
            key2Button.localScale = new Vector3(magni,magni,1f); key2Button.localPosition = new Vector3(-35.5f*magni,0f,0f);
            key3Button.localScale = new Vector3(magni,magni,1f); key3Button.localPosition = new Vector3(35.5f*magni,0f,0f);
            key4Button.localScale = new Vector3(magni,magni,1f); key4Button.localPosition = new Vector3(106.5f*magni,0f,0f);
            key5Button.gameObject.SetActive(false);
            key6Button.gameObject.SetActive(false);
            keyReturnButton1.localScale = new Vector3(magni,magni,1f); keyReturnButton1.localPosition = new Vector3(177.5f*magni,0f,0f);
            keyCanvas2.SetActive(false);
          }
          if(yLength == 6)
          {
            keyBackspaceButton1.gameObject.SetActive(false);
            key1Button.localScale = new Vector3(magni,magni,1f); key1Button.localPosition = new Vector3(-177.5f*magni,0f,0f);
            key2Button.localScale = new Vector3(magni,magni,1f); key2Button.localPosition = new Vector3(-106.5f*magni,0f,0f);
            key3Button.localScale = new Vector3(magni,magni,1f); key3Button.localPosition = new Vector3(-35.5f*magni,0f,0f);
            key4Button.localScale = new Vector3(magni,magni,1f); key4Button.localPosition = new Vector3(35.5f*magni,0f,0f);
            key5Button.localScale = new Vector3(magni,magni,1f); key5Button.localPosition = new Vector3(106.5f*magni,0f,0f);
            key6Button.localScale = new Vector3(magni,magni,1f); key6Button.localPosition = new Vector3(177.5f*magni,0f,0f);
            keyReturnButton1.gameObject.SetActive(false);
            keyBackspaceButton2.localScale = new Vector3(magni,magni,1f); keyBackspaceButton2.localPosition = new Vector3(-177.5f*magni,(213f*magni-pheight)/2f,0f);
            keyReturnButton2.localScale = new Vector3(magni,magni,1f); keyReturnButton2.localPosition = new Vector3(177.5f*magni,(213f*magni-pheight)/2f,0f);
          }

          magni = Mathf.Min(0.9f*pwidth/220f,0.9f*pheight/380f);
          float pos = (0.9f*pheight-magni*380f)/2f;
          menuCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
          menuPanel.localScale = new Vector3(magni,magni,1f); menuPanel.localPosition = new Vector3(0f,pos,0f);

          instructionCanvas1.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
          instructionPanel1.localScale = new Vector3(magni,magni,1f); instructionPanel1.localPosition = new Vector3(0f,pos,0f);

          instructionCanvas2.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
          instructionPanel2.localScale = new Vector3(magni,magni,1f); instructionPanel2.localPosition = new Vector3(0f,pos,0f);
        }
      }

      public void SetLanguage()
      {
        language = PlayerPrefs.GetInt("Value_of_Language", 0);

        if(language == 0)
        {
          playAgainButtonText.text = "もう一度遊ぶ";

          saveConfirmText.text = "今の対局データを保存しますか？";
          saveConfirmYesText.text = "はい";
          saveConfirmNoText.text = "いいえ";

          quitConfirmText.text = "ゲームを終了しますか？";
          quitConfirmYesText.text = "はい";
          quitConfirmNoText.text = "いいえ";

          menuButtonText.text = "メニュー";
          instructionButtonText1.text = "操作説明";
          cancelButtonText.text = "まった";
          loadTitleButtonText.text = "タイトルに戻る";

          keyBackspaceButton1Text.text = "戻る";
          keyReturnButton1Text.text = "決定";

          keyBackspaceButton2Text.text = "戻る";
          keyReturnButton2Text.text = "決定";

          menuIndicateText.text = "設定";
          cameraSensiSliderText.text = "カメラ感度\n(９段階)";
          putableButtonText.text = "お助け機能";
          stoneSizeSliderText.text = "石の大きさ\n(９段階)";
          bgmVolumeSliderText.text = "BGM音量";
          instructionButtonText2.text = "操作説明";
          instructionButtonOpenText.text = "ひらく";

          if(swidth > sheight)
          {
            instructionText1.text = "〜　用いるキー 　〜\n1~4(または1~6)の数字キー\nEnterキー\nbackspaceキー\n十字キー\n\n\n\n\n2→3→1→Enter のような順番で\nキーを押すと石が置ける。\n\n\n十字キーでカメラ操作\n\n\ndelete : キー操作を一つ戻る\n\n\n待った : 一手戻る";
            nextButtonText1.text = "次ページへ ▶︎";
          }
          if(swidth <= sheight)
          {
            instructionText1.text = "下のキーを\n2→3→1→決定 のような順番で\n押すと石が置ける。\n\n\nフリックでカメラ操作\n\n\n戻る : キー操作を一つ戻る\n\n\n待った : 一手戻る";
            nextButtonText1.text = "次ページへ ▶︎";
          }

          instructionText2_1.text = "このようには置けますが";
          instructionText2_2.text = "下のように対角線上に\n置くことはできません！";
          prevButtonText2.text = "◀︎ 前ページへ";
        }

        if(language == 1)
        {
          playAgainButtonText.text = "Play again.";

          saveConfirmText.text = "Do you want to save\nthe current game data?";
          saveConfirmYesText.text = "Yes";
          saveConfirmNoText.text = "No";

          quitConfirmText.text = "Quit this game?";
          quitConfirmYesText.text = "Yes";
          quitConfirmNoText.text = "No";

          menuButtonText.text = "Menu";
          instructionButtonText1.text = "Instruction";
          cancelButtonText.text = "Wait";
          loadTitleButtonText.text = "Back to Title.";

          keyBackspaceButton1Text.text = "Back";
          keyReturnButton1Text.text = "Enter";

          keyBackspaceButton2Text.text = "Back";
          keyReturnButton2Text.text = "Enter";

          menuIndicateText.text = "Settings";
          cameraSensiSliderText.text = "Sensitivity\n(9 levels)";
          putableButtonText.text = "Help func.";
          stoneSizeSliderText.text = "Stone size\n(9 levels)";
          bgmVolumeSliderText.text = "BGM";
          instructionButtonText2.text = "Instructions";
          instructionButtonOpenText.text = "Open";

          if(swidth > sheight)
          {
            instructionText1.text = "〜　Keys to use　〜\n1~4 (or 1~6) numeric keys\nEnter key\nBackspace key\nCross key\n\n\n\nPress the keys in the order of\n2, 3, 1, and Enter\nto put a stone.\n\n\nCross key : Control the camera.\n\n\ndelete : Back one keystroke.\n\n\nWait : Back one move.";
            nextButtonText1.text = "Next Page ▶︎";
          }
          if(swidth <= sheight)
          {
            instructionText1.text = "Press the bottom keys in the order of\n2, 3, 1, and Enter\nto put a stone. \n\n\nFlick to control the camera.\n\n\nBack : Back one keystroke.\n\n\nWait : Back one move.";
            nextButtonText1.text = "Next Page ▶︎";
          }

          instructionText2_1.text = "You can put like this, but";
          instructionText2_2.text = "You can't put\non a diagonal as follows!";
          prevButtonText2.text = "◀︎ Prev Page";
        }
      }
  }
}
