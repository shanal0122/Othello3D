using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvP666
{
  public class InfoDisplay : MonoBehaviour
  {
      public GameObject stones;
      public GameObject master;
      public Text blackTurnText;
      public Text whiteTurnText;
      public Text blackStoneNumText;
      public Text whiteStoneNumText;
      public Text resultText;
      public Text claimText;


      public void TurnIndicate() //テキストにターンを表示する
      {
        int turn = master.GetComponent<Game>().Turn;
        if(turn == 1)
        {
          blackTurnText.text = "あなたの番です";
          whiteTurnText.text = "相手の番です";
        }
        if(turn == -1)
        {
          blackTurnText.text = "相手の番です";
          whiteTurnText.text = "あなたの番です";
        }
        if(turn != 1 && turn != -1)
        {
          Debug.Log("Error : InfoDisplay/TurnIndicate");//////////////////////////////////////////////////////////////////////////////////////
        }
      }

      public void StoneNumIndicate() //テキストに各色の石の数を表示する
      {
        int bl = stones.GetComponent<Stone>().CountStone(1);
        blackStoneNumText.text = bl.ToString();
        int wh = stones.GetComponent<Stone>().CountStone(-1);
        whiteStoneNumText.text = wh.ToString();
      }

      public void ResultIndicate() //リザルト画面を表示する
      {
        int bl = stones.GetComponent<Stone>().CountStone(1);
        blackStoneNumText.text = bl.ToString();
        int wh = stones.GetComponent<Stone>().CountStone(-1);
        whiteStoneNumText.text = wh.ToString();
        if(bl > wh) {resultText.text = "ゲームセット\n\n黒の勝ち";}
        if(bl == wh) {resultText.text = "ゲームセット\n\n引き分け";}
        if(bl < wh) {resultText.text = "ゲームセット\n\n白の勝ち";}
      }

      public void CantPutIndicate() //石を置けないはずの場所に置いた時に怒る
      {
        claimText.text = "そこには\n置けません";
        Invoke("ClaimTextClear",1);
      }

      public void PassedIndicate(int turn) //turnの人をパスしたことを知らせる
      {
        if(turn == 1)
        {
          claimText.text = "黒をパス\nしました";
          Invoke("ClaimTextClear",3);
        }
        if(turn == -1)
        {
          claimText.text = "白をパス\nしました";
          Invoke("ClaimTextClear",3);
        }
      }

      public void ClaimTextClear()
      {
        claimText.text = "";
      }
  }
}
