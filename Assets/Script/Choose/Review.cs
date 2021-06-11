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
    private RectTransform betaText;
    private Text chooseTextText;

    void Start()
    {
      betaText = betaTestCanvas.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
      chooseTextText = chooseCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

      SetuGUI();

      reviewflug = PlayerPrefs.GetInt("Reviewed_Flug", 0);
      if(reviewflug == 0)
      {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      }
    }

    public void SetuGUI()
    {
      swidth = Screen.width; sheight = Screen.height;
      pwidth = pheight * swidth / sheight;

      if(swidth > sheight)
      {
        betaText.localScale = new Vector3(1f,1f,1f); betaText.localPosition = new Vector3(-350f,220f,0);
      }
      if(swidth <= sheight)
      {
        betaText.localScale = new Vector3(Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f)/6f*5f,Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f)/6f*5f,1f); betaText.localPosition = new Vector3(-1*Mathf.Min(0.8f*pwidth/chooseTextText.preferredWidth,0.6f)*chooseTextText.preferredWidth/2f,180f,0);
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
