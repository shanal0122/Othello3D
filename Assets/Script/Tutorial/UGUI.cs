using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
  public class UGUI : MonoBehaviour
  {
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private float pwidth; //CanvasScalerのReference Resolution。（幅）
      private float pheight = 600; //CanvasScalerのReference Resolution。Heightで合わせているたためこれが高さの基準になる（高さ）
      private int language;
      public GameObject cameras;
      public GameObject centerCanvas;
      public GameObject quitConfirmCanvas;
      public GameObject iconCanvas;
      public GameObject keyCanvas;
      public GameObject canvas_1_L;
      public GameObject canvas0_L;
      public GameObject canvas1_L;
      public GameObject canvas2_L;
      public GameObject canvas3_L;
      public GameObject canvas4_L;
      public GameObject canvas5_L;
      public GameObject canvas6to9_L;
      public GameObject canvas10_L;
      public GameObject canvas11_L;

      public GameObject canvas_1_P;
      public GameObject canvas0_P;
      public GameObject canvas1_P;
      public GameObject canvas2_P;
      public GameObject canvas3_P;
      public GameObject canvas4_P;
      public GameObject canvas5_P;
      public GameObject canvas6to9_P;
      public GameObject canvas10_P;
      public GameObject canvas11_P;

      private Camera mainCamera;
      private Camera leftCamera;
      private Camera rightCamera;
      private Camera keyCamera;

      private RectTransform loadTitleBigButton;
      private Text loadTitleBigButtonText;

      private RectTransform quitConfirmPanel;
      private Text quitConfirmText;
      private Text quitConfirmYesText;
      private Text quitConfirmNoText;

      private RectTransform tutorialText;
      private Text tutorialTextText;
      private RectTransform loadTitleButton;
      private Text loadTitleButtonText;

      private RectTransform keyBackspaceButton;
      private Text keyBackspaceButtonText;
      private RectTransform key1Button;
      private RectTransform key2Button;
      private RectTransform key3Button;
      private RectTransform key4Button;
      private RectTransform keyReturnButton;
      private Text keyReturnButtonText;

      private RectTransform canvas_1_PPanel;
      private RectTransform canvas0_PPanel;
      private RectTransform canvas1_PPanel;
      private RectTransform canvas2_PPanel;
      private RectTransform canvas3_PPanel;
      private RectTransform canvas4_PPanel;
      private RectTransform canvas5_PPanel;
      private RectTransform canvas6to9_PPanel;
      private RectTransform canvas10_PPanel;
      private RectTransform canvas11_PPanel;

      private Text text_1_L_0;
      private Text text_1_L_2;
      private Text text_1_L_3;
      private Text text0_L_0;
      private Text text0_L_2;
      private RectTransform text0_L_3Rect;
      private Text text0_L_3;
      private Text text0_L_4;
      private Text text1_L_0;
      private Text text1_L_2;
      private Text text1_L_4;
      private Text text2_L_0;
      private Text text2_L_2;
      private Text text2_L_4;
      private Text text3_L_0;
      private Text text3_L_2;
      private Text text3_L_4;
      private Text text4_L_0;
      private Text text4_L_2;
      private Text text4_L_4;
      private Text text5_L_0;
      private Text text5_L_1;
      private Text text5_L_2;
      private Text text6to9_L_0;
      private Text text6to9_L_1;
      private Text text6to9_L_2;
      private Text text10_L_0;
      private Text text10_L_1;
      private Text text10_L_2;
      private Text text10_L_3;
      private Text text11_L_0;
      private Text text11_L_1;
      private Text text11_L_4;
      private Text text11_L_6;

      private Text text_1_P_0;
      private Text text_1_P_1;
      private Text text0_P_0;
      private RectTransform text0_P_1Rect;
      private Text text0_P_1;
      private Text text0_P_2;
      private Text text0_P_3;
      private Text text1_P_0;
      private Text text1_P_2;
      private Text text1_P_3;
      private Text text2_P_0;
      private Text text2_P_2;
      private Text text2_P_3;
      private Text text3_P_0;
      private Text text3_P_2;
      private Text text3_P_3;
      private Text text4_P_0;
      private Text text4_P_2;
      private Text text4_P_3;
      private Text text5_P_0;
      private Text text5_P_1;
      private Text text5_P_2;
      private Text text6to9_P_0;
      private Text text6to9_P_2;
      private Text text6to9_P_3;
      private Text text10_P_0;
      private Text text10_P_1;
      private Text text10_P_2;
      private Text text10_P_3;
      private Text text11_P_0;
      private Text text11_P_1;
      private Text text11_P_4;
      private Text text11_P_6;

      void Start()
      {
          mainCamera = cameras.transform.GetChild(0).gameObject.GetComponent<Camera>();
          leftCamera = cameras.transform.GetChild(1).gameObject.GetComponent<Camera>();
          rightCamera = cameras.transform.GetChild(2).gameObject.GetComponent<Camera>();
          keyCamera = cameras.transform.GetChild(3).gameObject.GetComponent<Camera>();

          loadTitleBigButton = centerCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          loadTitleBigButtonText = centerCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();

          quitConfirmPanel = quitConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          quitConfirmText = quitConfirmCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          quitConfirmYesText = quitConfirmCanvas.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
          quitConfirmNoText = quitConfirmCanvas.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>();

          tutorialText = iconCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          tutorialTextText = iconCanvas.transform.GetChild(0).gameObject.GetComponent<Text>();
          loadTitleButton = iconCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          loadTitleButtonText = iconCanvas.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();

          keyBackspaceButton = keyCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          keyBackspaceButtonText = keyCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          key1Button = keyCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          key2Button = keyCanvas.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
          key3Button = keyCanvas.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
          key4Button = keyCanvas.transform.GetChild(4).gameObject.GetComponent<RectTransform>();
          keyReturnButton = keyCanvas.transform.GetChild(5).gameObject.GetComponent<RectTransform>();
          keyReturnButtonText = keyCanvas.transform.GetChild(5).GetChild(0).gameObject.GetComponent<Text>();

          canvas_1_PPanel = canvas_1_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas0_PPanel = canvas0_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas1_PPanel = canvas1_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas2_PPanel = canvas2_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas3_PPanel = canvas3_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas4_PPanel = canvas4_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas5_PPanel = canvas5_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas6to9_PPanel = canvas6to9_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas10_PPanel = canvas10_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          canvas11_PPanel = canvas11_P.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          text_1_L_0 = canvas_1_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text_1_L_2 = canvas_1_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text_1_L_3 = canvas_1_L.transform.GetChild(3).gameObject.GetComponent<Text>();
          text0_L_0 = canvas0_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text0_L_2 = canvas0_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text0_L_3Rect = canvas0_L.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
          text0_L_3 = canvas0_L.transform.GetChild(3).gameObject.GetComponent<Text>();
          text0_L_4 = canvas0_L.transform.GetChild(4).gameObject.GetComponent<Text>();
          text1_L_0 = canvas1_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text1_L_2 = canvas1_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text1_L_4 = canvas1_L.transform.GetChild(4).gameObject.GetComponent<Text>();
          text2_L_0 = canvas2_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text2_L_2 = canvas2_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text2_L_4 = canvas2_L.transform.GetChild(4).gameObject.GetComponent<Text>();
          text3_L_0 = canvas3_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text3_L_2 = canvas3_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text3_L_4 = canvas3_L.transform.GetChild(4).gameObject.GetComponent<Text>();
          text4_L_0 = canvas4_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text4_L_2 = canvas4_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text4_L_4 = canvas4_L.transform.GetChild(4).gameObject.GetComponent<Text>();
          text5_L_0 = canvas5_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text5_L_1 = canvas5_L.transform.GetChild(1).gameObject.GetComponent<Text>();
          text5_L_2 = canvas5_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text6to9_L_0 = canvas6to9_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text6to9_L_1 = canvas6to9_L.transform.GetChild(1).gameObject.GetComponent<Text>();
          text6to9_L_2 = canvas6to9_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text10_L_0 = canvas10_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text10_L_1 = canvas10_L.transform.GetChild(1).gameObject.GetComponent<Text>();
          text10_L_2 = canvas10_L.transform.GetChild(2).gameObject.GetComponent<Text>();
          text10_L_3 = canvas10_L.transform.GetChild(3).gameObject.GetComponent<Text>();
          text11_L_0 = canvas11_L.transform.GetChild(0).gameObject.GetComponent<Text>();
          text11_L_1 = canvas11_L.transform.GetChild(1).gameObject.GetComponent<Text>();
          text11_L_4 = canvas11_L.transform.GetChild(4).gameObject.GetComponent<Text>();
          text11_L_6 = canvas11_L.transform.GetChild(6).gameObject.GetComponent<Text>();

          text_1_P_0 = canvas_1_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text_1_P_1 = canvas_1_P.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          text0_P_0 = canvas0_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text0_P_1Rect = canvas0_P.transform.GetChild(0).GetChild(1).gameObject.GetComponent<RectTransform>();
          text0_P_1 = canvas0_P.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          text0_P_2 = canvas0_P.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
          text0_P_3 = canvas0_P.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
          text1_P_0 = canvas1_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text1_P_2 = canvas1_P.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
          text1_P_3 = canvas1_P.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
          text2_P_0 = canvas2_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text2_P_2 = canvas2_P.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
          text2_P_3 = canvas2_P.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
          text3_P_0 = canvas3_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text3_P_2 = canvas3_P.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
          text3_P_3 = canvas3_P.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
          text4_P_0 = canvas4_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text4_P_2 = canvas4_P.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
          text4_P_3 = canvas4_P.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
          text5_P_0 = canvas5_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text5_P_1 = canvas5_P.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          text5_P_2 = canvas5_P.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
          text6to9_P_0 = canvas6to9_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text6to9_P_2 = canvas6to9_P.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
          text6to9_P_3 = canvas6to9_P.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
          text10_P_0 = canvas10_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text10_P_1 = canvas10_P.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          text10_P_2 = canvas10_P.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
          text10_P_3 = canvas10_P.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
          text11_P_0 = canvas11_P.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
          text11_P_1 = canvas11_P.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
          text11_P_4 = canvas11_P.transform.GetChild(0).GetChild(4).gameObject.GetComponent<Text>();
          text11_P_6 = canvas11_P.transform.GetChild(0).GetChild(6).gameObject.GetComponent<Text>();

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

          loadTitleBigButton.localScale = new Vector3(1f,1f,1f); loadTitleBigButton.localPosition = new Vector3(0f,-190f,0f);

          quitConfirmPanel.localScale = new Vector3(0.7f,0.7f,1f); quitConfirmPanel.localPosition = new Vector3(0f,-180f,0f);

          tutorialText.localScale = new Vector3(0.8f,1f,1f); tutorialText.localPosition = new Vector3(0f,250f,0f);
          loadTitleButton.localScale = new Vector3(0.52f,0.52f,1f); loadTitleButton.localPosition = new Vector3(0f,0f,0f);

          keyCanvas.SetActive(false);
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

          loadTitleBigButton.localScale = new Vector3(0.6f*magni,0.6f*magni,1f); loadTitleBigButton.localPosition = new Vector3(0f,(0.205f*pheight+36f)*magni-pheight/2f,0f);

          quitConfirmPanel.localScale = new Vector3(0.5f,0.5f,1f); quitConfirmPanel.localPosition = new Vector3(0f,-160f,0f);

          tutorialText.localScale = new Vector3(magni*0.8f,magni,1f); tutorialText.localPosition = new Vector3(0f,0f,0f);
          loadTitleButton.localScale = new Vector3(magni*0.32f,magni*0.32f,1f); loadTitleButton.localPosition = new Vector3(160f*magni,0f,0f);


          keyBackspaceButton.localScale = new Vector3(magni,magni,1f); keyBackspaceButton.localPosition = new Vector3(-177.5f*magni,0f,0f);
          key1Button.localScale = new Vector3(magni,magni,1f); key1Button.localPosition = new Vector3(-106.5f*magni,0f,0f);
          key2Button.localScale = new Vector3(magni,magni,1f); key2Button.localPosition = new Vector3(-35.5f*magni,0f,0f);
          key3Button.localScale = new Vector3(magni,magni,1f); key3Button.localPosition = new Vector3(35.5f*magni,0f,0f);
          key4Button.localScale = new Vector3(magni,magni,1f); key4Button.localPosition = new Vector3(106.5f*magni,0f,0f);
          keyReturnButton.localScale = new Vector3(magni,magni,1f); keyReturnButton.localPosition = new Vector3(177.5f*magni,0f,0f);

          canvas_1_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas0_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas1_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas2_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas3_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas4_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas5_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas6to9_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas10_PPanel.localScale = new Vector3(magni,magni,1f);
          canvas11_PPanel.localScale = new Vector3(Mathf.Min((pheight-(0.22f*pheight+72f)*magni)/380f,0.9f*pwidth/220f),Mathf.Min((pheight-(0.22f*pheight+72f)*magni)/380f,0.9f*pwidth/220f),1f); canvas11_PPanel.localPosition = new Vector3(0f,(36f+0.03f*pheight)*magni,0f);
        }
      }

      public void SetLanguage()
      {
        language = PlayerPrefs.GetInt("Value_of_Language", 0);

        if(language == 0)
        {
          loadTitleBigButtonText.text = "タイトルに戻る";

          quitConfirmText.text = "チュートリアルを終了しますか？";
          quitConfirmYesText.text = "はい";
          quitConfirmNoText.text = "いいえ";

          tutorialTextText.text = "チュートリアル";
          loadTitleButtonText.text = "タイトルに戻る";

          keyBackspaceButtonText.text = "戻る";
          keyReturnButtonText.text = "決定";

          text_1_L_0.text = "チュートリアルを\n始めるよ！！";
          text_1_L_2.text = "まずは十字キーを操作して\n視点を移動させてみよう";
          text_1_L_3.text = "Enterで次に進む";
          text0_L_0.text = "あなたの石は黒色！\n石を挟んで裏返そう！";
          text0_L_2.text = "石を置ける場所は　　　　　　\nで表示されているよ\n石を置きたいと思ったら...";
          text0_L_3Rect.localPosition = new Vector3(74f,-52f,0f);
          text0_L_3.text = "オレンジ色";
          text0_L_4.text = "Enterで次に進む";
          text1_L_0.text = "盤の周りの番号通りに！";
          text1_L_2.text = "まずキーボードの 1 \nを押して";
          text1_L_4.text = "deleteで戻る";
          text2_L_0.text = "盤の周りの番号通りに！";
          text2_L_2.text = "次にキーボードの 1 \nを再び押して";
          text2_L_4.text = "deleteで戻る";
          text3_L_0.text = "盤の周りの番号通りに！";
          text3_L_2.text = "次にキーボードの 2 \nを押して";
          text3_L_4.text = "deleteで戻る";
          text4_L_0.text = "盤の周りの番号通りに！";
          text4_L_2.text = "最後に Enter\nを押せばOK！";
          text4_L_4.text = "deleteで戻る";
          text5_L_0.text = "これで石が置けました。\n\n\n\n次は実際の盤面で\n\nプレイしてみよう！";
          text5_L_1.text = "deleteで戻る";
          text5_L_2.text = "Enterで次に進む";
          text6to9_L_0.text = "少しだけ実戦練習";
          text6to9_L_1.text = "色がついているところに\n石を置こう。\n\n盤の周りに書かれている\n番号をヒントに\n１〜４の数字を\n3回押した後 Enter！\n（間違えたときはDelete）";
          text6to9_L_2.text = "deleteで戻る";
          text10_L_0.text = "チュートリアル終了！";
          text10_L_1.text = "対戦では 視点移動 を\n使いこなして\n勝利を目指せ！\n\n慣れてきたら Menu の\n難易度変更から\n強いCPUと戦おう！";
          text10_L_2.text = "deleteで戻る";
          text10_L_3.text = "Enterで次に進む";
          text11_L_0.text = "最後に注意！";
          text11_L_1.text = "ここには置けますが";
          text11_L_4.text = "下のように対角線上に\n置くことはできません！";
          text11_L_6.text = "deleteで戻る";

          text_1_P_0.text = "まずは画面をフリックして\n視点を移動させてみよう!";
          text_1_P_1.text = "「 決定 」で次に進む";
          text0_P_0.text = "あなたの石は黒色！\n　　　　　のところに石を置こう.";
          text0_P_1Rect.localPosition = new Vector3(-95f,-10.5f,0f);
          text0_P_1.text = "オレンジ色";
          text0_P_2.text = "「 戻る 」で前へ戻る";
          text0_P_3.text = "「 決定 」で次に進む";
          text1_P_0.text = "盤の周りの番号通りに！";
          text1_P_2.text = "まず「 1 」を押して";
          text1_P_3.text = "「 戻る 」で前へ戻る";
          text2_P_0.text = "盤の周りの番号通りに！";
          text2_P_2.text = "次に「 1 」を押して";
          text2_P_3.text = "「 戻る 」で前へ戻る";
          text3_P_0.text = "盤の周りの番号通りに！";
          text3_P_2.text = "次に「 2 」を押して";
          text3_P_3.text = "「 戻る 」で前へ戻る";
          text4_P_0.text = "盤の周りの番号通りに！";
          text4_P_2.text = "最後に「 決定 」を押せばOK！";
          text4_P_3.text = "「 戻る 」で前へ戻る";
          text5_P_0.text = "これで石が置けました。\n次は実際の盤面でプレイしてみよう！";
          text5_P_1.text = "「 戻る 」で前へ戻る";
          text5_P_2.text = "「 決定 」で次に進む";
          text6to9_P_0.text = "少しだけ実戦練習";
          text6to9_P_2.text = "１〜４の数字を3回押した後「 決定 」！\n（間違えたときは「 戻る 」）";
          text6to9_P_3.text = "「 戻る 」で前へ戻る";
          text10_P_0.text = "チュートリアル終了！";
          text10_P_1.text = "慣れてきたら Menu の難易度変更から\n強いCPUと戦おう！";
          text10_P_2.text = "「 戻る 」で前へ戻る";
          text10_P_3.text = "「 決定 」で次に進む";
          text11_P_0.text = "最後に注意！";
          text11_P_1.text = "このようには置けますが";
          text11_P_4.text = "下のように対角線上に\n置くことはできません！";
          text11_P_6 .text = "「 戻る 」で前へ戻る";
        }

        if(language == 1)
        {
          loadTitleBigButtonText.text = "Back to Title.";

          quitConfirmText.text = "Quit Tutorial?";
          quitConfirmYesText.text = "Yes";
          quitConfirmNoText.text = "No";

          tutorialTextText.text = "Tutorial";
          loadTitleButtonText.text = "Back to Title.";

          keyBackspaceButtonText.text = "Back";
          keyReturnButtonText.text = "Enter";

          text_1_L_0.text = "Let's play\nthe Tutorial！";
          text_1_L_2.text = "First, use the cross-key\nto move the viewpoint.";
          text_1_L_3.text = "Press Enter →";
          text0_L_0.text = "Your stone is black!\nLet's flip stones over!";
          text0_L_2.text = "Places where you can put\nare shown in  　　　 .\nIf you want to put...";
          text0_L_3Rect.localPosition = new Vector3(54f,-94.5f,0f);
          text0_L_3.text = "Orange";
          text0_L_4.text = "Press Enter →";
          text1_L_0.text = "Follow the numbers\naround the board!";
          text1_L_2.text = "First, press 1\non the keyboard.";
          text1_L_4.text = "← Press Delete";
          text2_L_0.text = "Follow the numbers\naround the board!";
          text2_L_2.text = "Then, press 1\non the keyboard";
          text2_L_4.text = "← Press Delete";
          text3_L_0.text = "Follow the numbers\naround the board!";
          text3_L_2.text = "Then, press 2\non the keyboard";
          text3_L_4.text = "← Press Delete";
          text4_L_0.text = "Follow the numbers\naround the board!";
          text4_L_2.text = "Finally, press Enter\nand you're done!";
          text4_L_4.text = "← Press Delete";
          text5_L_0.text = "Well done!\n\n\n\nThen, let's play\n\non a real board!";
          text5_L_1.text = "← Press Delete";
          text5_L_2.text = "Press Enter →";
          text6to9_L_0.text = "Practice";
          text6to9_L_1.text = "Place the stones\non the colored areas.\n\nUse the numbers\naround the board.\nPress 1-4 three times,\nthen Enter!\n(Delete if you miss.)";
          text6to9_L_2.text = "← Press Delete";
          text10_L_0.text = "Tutorial is over!";
          text10_L_1.text = "Move the viewpoint\nto win the game!\n\nWhen you get used to,\nyou can change\nthe difficulty\nin the menu to fight\nthe strong CPU!";
          text10_L_2.text = "← Press Delete";
          text10_L_3.text = "Press Enter →";
          text11_L_0.text = "Attention!";
          text11_L_1.text = "You can put like this, but";
          text11_L_4.text = "You can't put\non a diagonal as follows!";
          text11_L_6.text = "← Press Delete";

          text_1_P_0.text = "First, flick the screen\nto move the viewpoint!";
          text_1_P_1.text = "Press 'Enter' →";
          text0_P_0.text = "Your stone is black!\nLet's put a stone in the  　　　  place!";
          text0_P_1Rect.localPosition = new Vector3(72f,-10.5f,0f);
          text0_P_1.text = "Orange";
          text0_P_2.text = "← Press 'Back'";
          text0_P_3.text = "Press 'Enter' →";
          text1_P_0.text = "Follow numbers around the board!";
          text1_P_2.text = "First, press '1'.";
          text1_P_3.text = "← Press 'Back'";
          text2_P_0.text = "Follow numbers around the board!";
          text2_P_2.text = "Then, press '1'.";
          text2_P_3.text = "← Press 'Back'";
          text3_P_0.text = "Follow numbers around the board!";
          text3_P_2.text = "Then, press '2'.";
          text3_P_3.text = "← Press 'Back'";
          text4_P_0.text = "Follow numbers around the board!";
          text4_P_2.text = "Finally, press Enter!";
          text4_P_3.text = "← Press 'Back'";
          text5_P_0.text = "Well done!\nThen, let's play on a real board!";
          text5_P_1.text = "← Press 'Back'";
          text5_P_2.text = "Press 'Enter' →";
          text6to9_P_0.text = "Practice";
          text6to9_P_2.text = "Press '1'-'4' three times, then 'Enter'!\n(Press 'Back' if you miss.)";
          text6to9_P_3.text = "← Press 'Back'";
          text10_P_0.text = "Tutorial is over!";
          text10_P_1.text = "When you get used to, you can change the difficulty\nin the menu to fight the strong CPU!";
          text10_P_2.text = "← Press 'Back'";
          text10_P_3.text = "Press 'Enter' →";
          text11_P_0.text = "Attention!";
          text11_P_1.text = "You can put like this, but";
          text11_P_4.text = "You can't put\non a diagonal as follows!";
          text11_P_6 .text = "← Press 'Back'";
        }
      }
  }
}
