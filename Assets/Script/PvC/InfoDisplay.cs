using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvC
{
  public class InfoDisplay : MonoBehaviour
  {
      private int playerTurn = Choose.InitialSetting.playerTurn; //プレイヤーの手番
      private int turn; //PassIndicate用
      private int language;
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
        language = PlayerPrefs.GetInt("Value_of_Language", 0);

        if(language == 0)
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
        if(language == 1)
        {
          if(playerTurn == 1)
          {
            blackTurnText.text = "You";
            whiteTurnText.text = "CPU";
          }
          else if(playerTurn == -1)
          {
            blackTurnText.text = "CPU";
            whiteTurnText.text = "You";
          }
          else
          {
            blackTurnText.text = "CPU";
            whiteTurnText.text = "CPU";
          }
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
        if(language == 0)
        {
          if(bl > wh) {resultText.text = "ゲームセット\n\nあなたの勝ち";}
          if(bl == wh) {resultText.text = "ゲームセット\n\n引き分け";}
          if(bl < wh) {resultText.text = "ゲームセット\n\nCPUの勝ち";}
        }
        if(language == 1)
        {
          if(bl > wh) {resultText.text = "Game Set.\n\nYou win!";}
          if(bl == wh) {resultText.text = "Game Set.\n\nDraw!";}
          if(bl < wh) {resultText.text = "Game Set.\n\nYou lose...";}
        }
      }

      public void CantPutIndicate() //石を置けないはずの場所に置いた時に怒る
      {
        if(language == 0){ claimText.text = "そこには\n置けません"; }
        if(language == 1){ claimText.text = "You can't\nput there"; }
        Invoke("ClaimTextClear",1);
      }

      public void PassedIndicate(int t) //turnの人をパスしたことを知らせる
      {
        ClaimTextClear();
        turn = t;
        Invoke("PassIn",0.1f);
      }

      public void ClaimTextClear()
      {
        claimText.text = null;
      }

      public void PassIn()
      {
        if(turn == 1)
        {
          if(language == 0){ claimText.text = "黒をパス\nしました"; }
          if(language == 1){ claimText.text = "Black\nis passed."; }
          Invoke("ClaimTextClear",3);
        }
        if(turn == -1)
        {
          if(language == 0){ claimText.text = "白をパス\nしました"; }
          if(language == 1){ claimText.text = "White\nis passed."; }
          Invoke("ClaimTextClear",3);
        }
      }
  }
}
