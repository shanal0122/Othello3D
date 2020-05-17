using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvC
{
  public class InfoDisplay : MonoBehaviour
  {
      private int playerTurn = Choose.InitialSetting.playerTurn; //プレイヤーの手番
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


      void Start() //テキストにターンを表示する
      {
        if(playerTurn == 1)
        {
          blackTurnText.text = "先攻：あなた";
          whiteTurnText.text = "後攻：CPU";
        }
        else if(playerTurn == -1)
        {
          blackTurnText.text = "先攻：CPU";
          whiteTurnText.text = "後攻：あなた";
        }
        else
        {
          blackTurnText.text = "先攻：CPU";
          whiteTurnText.text = "後攻：CPU";
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
        if(bl > wh) {resultText.text = "ゲームセット\n\nあなたの勝ち";}
        if(bl == wh) {resultText.text = "ゲームセット\n\n引き分け";}
        if(bl < wh) {resultText.text = "ゲームセット\n\nCPUの勝ち";}
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
