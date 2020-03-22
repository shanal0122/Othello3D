using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvP444
{
  public class InfoDisplay444 : MonoBehaviour
  {
      public GameObject stones;
      public GameObject master;
      public Text blackTurnText;
      public Text whiteTurnText;
      public Text blackStoneNumText;
      public Text whiteStoneNumText;


      public void TurnIndicate() //テキストにターンを表示する
      {
        int turn = master.GetComponent<Game444>().Turn;
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
        int bl = stones.GetComponent<Stone444>().CountStone(1);
        blackStoneNumText.text = bl.ToString();
        int wh = stones.GetComponent<Stone444>().CountStone(-1);
        whiteStoneNumText.text = wh.ToString();
      }
  }
}
