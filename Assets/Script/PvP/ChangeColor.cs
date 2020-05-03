using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP
{
  public class ChangeColor : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      public Transform shineBoard;
      public Transform informShinyBoard;
      public GameObject shineBoardPrefab;
      public GameObject informShinyBoardPrefab;
      private GameObject[,,] sb; //[x,y,z]にあるshineBoardを格納
      private GameObject[,,] isb; //[x,y,z]にあるinformShinyBoardを格納


      void Start()
      {
        sb = new GameObject[xLength,yLength,zLength];
        isb = new GameObject[xLength,yLength,zLength];
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              sb[x,y,z] = Instantiate(shineBoardPrefab, shineBoard);
              sb[x,y,z].transform.position = new Vector3(x,y,z);
              sb[x,y,z].SetActive(false);
              isb[x,y,z] = Instantiate(informShinyBoardPrefab, informShinyBoard);
              isb[x,y,z].transform.position = new Vector3(x,y,z);
              isb[x,y,z].SetActive(false);
            }
          }
        }
      }


      public void UndoBoardColor(int x, int y, int z) //(x,y,z)にある盤の色を元に戻す
      {
        sb[x,y,z].SetActive(false);
        isb[x,y,z].SetActive(false);
      }

      public void ShineBoardColor(int x, int y, int z) //(x,y,z)にある盤の色を薄緑色にする
      {
        sb[x,y,z].SetActive(true);
      }

      public void InformShineBoardColor(int x, int y, int z) //(x,y,z)にある盤の色をオレンジにする
      {
        if(sb[x,y,z].activeSelf){ sb[x,y,z].SetActive(false); }
        isb[x,y,z].SetActive(true);
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
