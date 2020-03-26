using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Choose;

namespace PvP
{
  public class ChangeColor : MonoBehaviour
  {
      private int xLength = InitialSetting.xLength; //盤の一辺の長さ
      private int yLength = InitialSetting.yLength;
      private int zLength = InitialSetting.zLength;
      public Material clearBoard;
      public Material shinyBoard;
      public Material informShinyBoard;


      public void UndoBoardColor(int x, int y, int z) //(x,y,z)にある盤の色を元に戻す
      {
        GameObject.FindGameObjectWithTag("tagB" + x + y + z).GetComponent<Renderer>().sharedMaterial.color = clearBoard.color;
      }

      public void ShineBoardColor(int x, int y, int z) //(x,y,z)にある盤の色を薄緑色にする
      {
        GameObject.FindGameObjectWithTag("tagB" + x + y + z).GetComponent<Renderer>().material.color = shinyBoard.color;
      }

      public void InformShineBoardColor(int x, int y, int z) //(x,y,z)にある盤の色をオレンジにする
      {
        GameObject.FindGameObjectWithTag("tagB" + x + y + z).GetComponent<Renderer>().material.color = informShinyBoard.color;
      }

      public void UndoAllBoardColor() //全ての盤の色を元に戻す
      {
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              UndoBoardColor(x,y,z);
            }
          }
        }
      }
  }

}
