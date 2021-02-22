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
      public GameObject cameras;
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

      private RectTransform blackCorkBoardImage;

      private RectTransform whiteCorkBoardImage;
      private RectTransform claimCorkBoardImage;

      private RectTransform menuButton;
      private RectTransform instructionButton;
      private RectTransform loadTitleButton;

      private RectTransform backButton1;
      private RectTransform aheadButton1;
      private RectTransform replaySlider;

      private RectTransform backButton2;
      private RectTransform aheadButton2;

      private RectTransform menuPanel;

      private RectTransform instructionPanel;

      void Start()
      {
          mainCamera = cameras.transform.GetChild(0).gameObject.GetComponent<Camera>();
          leftCamera = cameras.transform.GetChild(1).gameObject.GetComponent<Camera>();
          rightCamera = cameras.transform.GetChild(2).gameObject.GetComponent<Camera>();
          keyCamera = cameras.transform.GetChild(3).gameObject.GetComponent<Camera>();

          blackCorkBoardImage = leftCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          whiteCorkBoardImage = rightCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          claimCorkBoardImage = rightCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();

          menuButton = iconCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          instructionButton = iconCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          loadTitleButton = iconCanvas.transform.GetChild(2).gameObject.GetComponent<RectTransform>();

          backButton1 = keyCanvas1.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          aheadButton1 = keyCanvas1.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          replaySlider = keyCanvas1.transform.GetChild(2).gameObject.GetComponent<RectTransform>();

          backButton2 = keyCanvas2.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          aheadButton2 = keyCanvas2.transform.GetChild(1).gameObject.GetComponent<RectTransform>();

          menuPanel = menuCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          instructionPanel = instructionCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          SetuGUI();
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
  }
}
