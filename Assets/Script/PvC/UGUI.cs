using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvC
{
  public class UGUI : MonoBehaviour
  {
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private float pwidth; //CanvasScalerのReference Resolution。（幅）
      private float pheight = 600; //CanvasScalerのReference Resolution。Heightで合わせているたためこれが高さの基準になる（高さ）
      public GameObject cameras;
      public GameObject centerCanvas;
      public GameObject saveConfirmCanvas;
      public GameObject leftCanvas;
      public GameObject rightCanvas;
      public GameObject iconCanvas;
      public GameObject menuCanvas;
      public GameObject instructionCanvas1;
      public GameObject instructionCanvas2;

      private Camera mainCamera;
      private Camera leftCamera;
      private Camera rightCamera;

      private RectTransform resultText;
      private Text resultTextText;
      private RectTransform playAgainButton;

      private RectTransform saveConfirmPanel;

      private RectTransform blackCorkBoardImage;

      private RectTransform whiteCorkBoardImage;
      private RectTransform claimCorkBoardImage;

      private RectTransform menuButton;
      private RectTransform instructionButton;
      private RectTransform cancelButton;
      private RectTransform loadTitleButton;

      private RectTransform menuPanel;

      private RectTransform instructionPanel1;

      private RectTransform instructionPanel2;

      void Start()
      {
          mainCamera = cameras.transform.GetChild(0).gameObject.GetComponent<Camera>();
          leftCamera = cameras.transform.GetChild(1).gameObject.GetComponent<Camera>();
          rightCamera = cameras.transform.GetChild(2).gameObject.GetComponent<Camera>();

          resultText = centerCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          resultTextText = centerCanvas.transform.GetChild(0).gameObject.GetComponent<Text>();
          playAgainButton = centerCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();

          saveConfirmPanel = saveConfirmCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          blackCorkBoardImage = leftCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          whiteCorkBoardImage = rightCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          claimCorkBoardImage = rightCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();

          menuButton = iconCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          instructionButton = iconCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          cancelButton = iconCanvas.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
          loadTitleButton = iconCanvas.transform.GetChild(3).gameObject.GetComponent<RectTransform>();

          menuPanel = menuCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          instructionPanel1 = instructionCanvas1.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          instructionPanel2 = instructionCanvas2.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          SetuGUI();
      }

      private void SetuGUI()
      {
        swidth = Screen.width; sheight = Screen.height;
        pwidth = pheight * swidth / sheight;
        Debug.Log(swidth + " " + sheight + " " + pwidth + " " + pheight);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if(swidth > sheight)
        {
          mainCamera.rect = new Rect(0.25f,0f,0.5f,1f);
          leftCamera.rect = new Rect(0f,0f,0.25f,1f);
          rightCamera.rect = new Rect(0.75f,0f,0.25f,1f);

          resultText.localScale = new Vector3(1f,1f,1f); resultText.localPosition = new Vector3(0f,100f,0f);
          playAgainButton.localScale = new Vector3(1f,1f,1f); playAgainButton.localPosition = new Vector3(0f,-220f,0f);

          saveConfirmPanel.localScale = new Vector3(0.35f,0.35f,1f); saveConfirmPanel.localPosition = new Vector3(0f,-180f,0f);

          leftCanvas.layer = LayerMask.NameToLayer("LeftScreen");
          leftCanvas.GetComponent<Canvas>().worldCamera = leftCamera;
          blackCorkBoardImage.localScale = new Vector3(1f,1f,1f); blackCorkBoardImage.localPosition = new Vector3(0f,-205f,0f);

          whiteCorkBoardImage.localScale = new Vector3(1f,1f,1f); whiteCorkBoardImage.localPosition = new Vector3(0f,-205f,0f);
          claimCorkBoardImage.localScale = new Vector3(1f,1f,1f); claimCorkBoardImage.localPosition = new Vector3(0f,-45f,0f);

          menuButton.localScale = new Vector3(0.5f,0.5f,1f); menuButton.localPosition = new Vector3(0f,240f,0f);
          instructionButton.localScale = new Vector3(0.5f,0.5f,1f); instructionButton.localPosition = new Vector3(0f,170f,0f);
          cancelButton.localScale = new Vector3(0.5f,0.5f,1f); cancelButton.localPosition = new Vector3(0f,100f,0f);
          loadTitleButton.localScale = new Vector3(0.5f,0.5f,1f); loadTitleButton.localPosition = new Vector3(0f,0f,0f);

          menuPanel.localScale = new Vector3(1f,1f,1f); menuPanel.localPosition = new Vector3(0f,95f,0f);

          instructionPanel1.localScale = new Vector3(1f,1f,1f); instructionPanel1.localPosition = new Vector3(0f,95f,0f);

          instructionPanel2.localScale = new Vector3(1f,1f,1f); instructionPanel2.localPosition = new Vector3(0f,95f,0f);
        }

        if(swidth <= sheight)
        {
          float aspect = sheight / swidth;

          float magni = Mathf.Min(1.4f/aspect,1f);
          mainCamera.rect = new Rect(0f,0.07f*magni,1f,1f-0.27f*magni);
          leftCamera.rect = new Rect(0f,0f,1f,0.07f*magni);
          rightCamera.rect = new Rect(0f,1f-0.2f*magni,1f,1f);

          magni = Mathf.Min(0.8f*pwidth/0.6f/resultTextText.preferredWidth,1f);
          resultText.localScale = new Vector3(0.6f*magni,0.6f*magni,1f); resultText.localPosition = new Vector3(0f,70f,0f);
          playAgainButton.localScale = new Vector3(0.6f*magni,0.6f*magni,1f); playAgainButton.localPosition = new Vector3(0f,-140f,0f);

          saveConfirmPanel.localScale = new Vector3(0.25f,0.25f,1f); saveConfirmPanel.localPosition = new Vector3(0f,-160f,0f);

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
/*
          menuPanel.localScale = new Vector3(1f,1f,1f); menuPanel.localPosition = new Vector3(0f,95f,0f);

          instructionPanel1.localScale = new Vector3(1f,1f,1f); instructionPanel1.localPosition = new Vector3(0f,95f,0f);

          instructionPanel2.localScale = new Vector3(1f,1f,1f); instructionPanel2.localPosition = new Vector3(0f,95f,0f);*/
        }
      }
  }
}
