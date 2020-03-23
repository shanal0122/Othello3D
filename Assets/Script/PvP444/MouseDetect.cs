using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP444
{
  public class MouseDetect : MonoBehaviour
  {
      public GameObject stones;
      public GameObject master;


      public void OnCancelClick() //待ったを押した時の処理。CameraMover.csのsquareListにリプレイ情報を格納している
      {
        if(Game.totalTurn > 0 && master.GetComponent<Game>().KeyDetectable)
        {
          stones.GetComponent<Stone>().PutAllStoneAsList();
          master.GetComponent<Game>().Turn *= -1;
          Game.totalTurn--;
        }
      }
  }
}
