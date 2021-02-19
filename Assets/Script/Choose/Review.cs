using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Review : MonoBehaviour
{
    public static int reviewflug = 0; //0:未レビュー、PVP,PVC後にレビューサイトに飛ばされる
    private float swidth; //画面サイズ（幅）
    private float sheight; //画面サイズ（高さ）
    private float pwidth; //CanvasScalerのReference Resolution。（幅）
    private float pheight = 600; //CanvasScalerのReference Resolution。Heightで合わせているたためこれが高さの基準になる（高さ）
    public GameObject chooseCanvas;
    public GameObject betaTestCanvas;
    public GameObject betaTestCanvas2;
    private RectTransform betaText;
    private RectTransform reviewButton;

    private RectTransform chooseText;
    private Text chooseTextText;

    void Start()
    {
      betaText = betaTestCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
      reviewButton = betaTestCanvas2.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

      chooseText = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
      chooseTextText = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

      SetuGUI();

      reviewflug = PlayerPrefs.GetInt("Reviewed_Flug", 0);
      if(reviewflug == 0)
      {
        this.gameObject.GetComponent<Canvas>().enabled = false;
      }
    }

    public void OpenReview()
    {
      Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSe8WEYdxBFFnxRkGotibx-VfGlPFrJ6Ik5VTWN3MRh90nscRQ/viewform?usp=sf_link");
    }

    public void SetuGUI()
    {
      swidth = Screen.width; sheight = Screen.height;
      pwidth = pheight * swidth / sheight;

      if(swidth > sheight)
      {
        betaText.localScale = new Vector3(1f,1f,1f); betaText.localPosition = new Vector3(-350f,200f,0);
        reviewButton.localScale = new Vector3(0.5f,0.5f,1f); reviewButton.localPosition = new Vector3(180f,230f,0f);
      }
      if(swidth <= sheight)
      {
        betaText.localScale = new Vector3(Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f)/6f*5f,Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f)/6f*5f,1f); betaText.localPosition = new Vector3(-1*Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f)*chooseTextText.preferredWidth/2f,160f,0);
        reviewButton.localScale = new Vector3(0.3f,0.3f,1f); reviewButton.localPosition = new Vector3(pwidth/2f-10f-340f*0.3f-5f-340f*0.3f/2f,pheight/2-40f,0f);
      }
    }
}

/*
レビュー用の機能
Script.Review.cs
Choose.BetaTestCanvas
Choose.BetaTestCanvas2
Choose.betaTestCanvas3
Script.PvP.Game.cs.GameSetの一部
Script.PvC.Game.cs.GameSetの一部
*/
