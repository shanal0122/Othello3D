using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvP
{
  public class InfoDisplay : MonoBehaviour
  {
      public Stone stone;
      public Game game;
      public Text blackTurnText;
      public Text whiteTurnText;
      public Text blackStoneNumText;
      public Text whiteStoneNumText;
      public Text blackStonePlusNumText;
      public Text whiteStonePlusNumText;
      public Text resultText;
      public Text claimText;


      public void TurnIndicate() //テキストにターンを表示する
      {
        int turn = game.Turn;
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
        int bl = stone.CountStone(1);
        blackStoneNumText.text = bl.ToString();
        int wh = stone.CountStone(-1);
        whiteStoneNumText.text = wh.ToString();
      }

      public void StonePlusNumIndicate(int turn, int x, int y, int z)
      {
        int s = stone.CountStoneWillFlip(turn, x, y, z);
        if(turn == 1 && s > 0)
        {
          blackStonePlusNumText.text = "+" + (s+1).ToString();
          whiteStonePlusNumText.text = "-" + s.ToString();
        }
        if(turn == -1 && s > 0)
        {
          whiteStonePlusNumText.text = "+" + (s+1).ToString();
          blackStonePlusNumText.text = "-" + s.ToString();
        }
      }

      public void StonePlusNumClear(int turn)
      {
        blackStonePlusNumText.text = null;
        whiteStonePlusNumText.text = null;
      }

      public void ResultIndicate() //リザルト画面を表示する
      {
        int bl = stone.CountStone(1);
        blackStoneNumText.text = bl.ToString();
        int wh = stone.CountStone(-1);
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
        claimText.text = null;
      }
  }
}
