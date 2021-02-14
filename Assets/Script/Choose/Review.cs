using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Review : MonoBehaviour
{
    public static int reviewflug = 0; //0:未レビュー、PVP,PVC後にレビューサイトに飛ばされる
    public GameObject betaTestCanvas3;
    public Transform pvp444button;
    public Transform pvp464button;
    public Transform pvc444button;
    public Transform pvc464button;

    void Start()
    {
      reviewflug = PlayerPrefs.GetInt("Reviewed_Flug", 0);
      if(reviewflug == 0)
      {
        this.gameObject.GetComponent<Canvas>().enabled = false;
      }
      if(reviewflug == 1){ betaTestCanvas3.GetComponent<Canvas>().enabled = false; }
    }

    public void OpenReview()
    {
      Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSe8WEYdxBFFnxRkGotibx-VfGlPFrJ6Ik5VTWN3MRh90nscRQ/viewform?usp=sf_link");
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
