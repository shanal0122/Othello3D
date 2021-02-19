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
      public GameObject cameras;
      public GameObject centerCanvas;
      public GameObject iconCanvas;
      public GameObject keyCanvas;
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

      private RectTransform tutorialText;
      private RectTransform loadTitleButton;

      private RectTransform keyBackspaceButton;
      private RectTransform key1Button;
      private RectTransform key2Button;
      private RectTransform key3Button;
      private RectTransform key4Button;
      private RectTransform keyReturnButton;

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

      void Start()
      {
          mainCamera = cameras.transform.GetChild(0).gameObject.GetComponent<Camera>();
          leftCamera = cameras.transform.GetChild(1).gameObject.GetComponent<Camera>();
          rightCamera = cameras.transform.GetChild(2).gameObject.GetComponent<Camera>();
          keyCamera = cameras.transform.GetChild(3).gameObject.GetComponent<Camera>();

          loadTitleBigButton = centerCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

          tutorialText = iconCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          loadTitleButton = iconCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();

          keyBackspaceButton = keyCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
          key1Button = keyCanvas.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
          key2Button = keyCanvas.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
          key3Button = keyCanvas.transform.GetChild(3).gameObject.GetComponent<RectTransform>();
          key4Button = keyCanvas.transform.GetChild(4).gameObject.GetComponent<RectTransform>();
          keyReturnButton = keyCanvas.transform.GetChild(5).gameObject.GetComponent<RectTransform>();

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

          loadTitleBigButton.localScale = new Vector3(1f,1f,1f); loadTitleBigButton.localPosition = new Vector3(0f,-190f,0f);

          tutorialText.localScale = new Vector3(0.8f,1f,1f); tutorialText.localPosition = new Vector3(0f,250f,0f);
          loadTitleButton.localScale = new Vector3(0.5f,0.5f,1f); loadTitleButton.localPosition = new Vector3(0f,0f,0f);

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

          tutorialText.localScale = new Vector3(magni*0.8f,magni,1f); tutorialText.localPosition = new Vector3(0f,0f,0f);
          loadTitleButton.localScale = new Vector3(magni*0.3f,magni*0.3f,1f); loadTitleButton.localPosition = new Vector3(160f*magni,0f,0f);


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
  }
}
