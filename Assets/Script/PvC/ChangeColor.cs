using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvC
{
  public class ChangeColor : MonoBehaviour
  {
    private int xLength = Choose.InitialSetting.xLength; //盤の一辺の長さ
    private int yLength = Choose.InitialSetting.yLength;
    private int zLength = Choose.InitialSetting.zLength;
    public Transform shineBoard;
    public Transform informShinyBoard;
    public Transform lastPutSphere;
    public GameObject shineBoardPrefab;
    public GameObject informShinyBoardPrefab1;
    public GameObject informShinyBoardPrefab2;
    public GameObject informShinyBoardPrefab3;
    public GameObject informShinyBoardPrefab4;
    public GameObject lastPutSpherePrefab;
    private GameObject[,,] sb; //[x,y,z]にあるshineBoardを格納
    private GameObject[,,] isb; //[x,y,z]にあるinformShinyBoardを格納
    private GameObject[,,] lpb; //[x,y,z]にあるlastPutBoardを格納


    void Start()
    {
        sb = new GameObject[xLength,yLength,zLength];
        isb = new GameObject[xLength,yLength,zLength];
        lpb = new GameObject[xLength,yLength,zLength];
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              sb[x,y,z] = Instantiate(shineBoardPrefab, shineBoard);
              sb[x,y,z].transform.position = new Vector3(x,y,z);
              sb[x,y,z].SetActive(false);
              lpb[x,y,z] = Instantiate(lastPutSpherePrefab, lastPutSphere);
              lpb[x,y,z].transform.position = new Vector3(x,y,z);
              lpb[x,y,z].SetActive(false);
            }
          }
        }
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            isb[0,y,z] = Instantiate(informShinyBoardPrefab1, informShinyBoard);
            isb[0,y,z].transform.position = new Vector3(0,y,z);
            isb[0,y,z].SetActive(false);
            isb[1,y,z] = Instantiate(informShinyBoardPrefab2, informShinyBoard);
            isb[1,y,z].transform.position = new Vector3(1,y,z);
            isb[1,y,z].SetActive(false);
            isb[2,y,z] = Instantiate(informShinyBoardPrefab3, informShinyBoard);
            isb[2,y,z].transform.position = new Vector3(2,y,z);
            isb[2,y,z].SetActive(false);
            isb[3,y,z] = Instantiate(informShinyBoardPrefab4, informShinyBoard);
            isb[3,y,z].transform.position = new Vector3(3,y,z);
            isb[3,y,z].SetActive(false);
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

    public void LastPutSphereColor(int x, int y, int z) //(x,y,z)にあるを赤に光らせる
    {
      lpb[x,y,z].SetActive(true);
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

   public void UndoAllSphereColor() //全てのたまの色を元に戻す
    {
      for(int y=0; y<yLength; y++)
      {
        for(int z=0; z<zLength; z++)
        {
          for(int x=0; x<xLength; x++)
          {
            lpb[x,y,z].SetActive(false);
          }
        }
      }
   }
 }
}
