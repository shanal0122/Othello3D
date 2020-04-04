using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP
{
  public class CreateBoard : MonoBehaviour //全ての盤にタグ付けする
  {
      private int xLength = Choose.InitialSetting.xLength; //盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      [SerializeField,Range(0f,0.03f)] private float flameWidth = 0.01f;
      public GameObject boardPrefab;
      public GameObject flamePrefab;

      void Start()
      {
          CreateClearBoard();
          CreateFlame();
      }


      private void CreateClearBoard()
      {
        Transform ClearBoardTransform = this.transform.GetChild(0).gameObject.transform;
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              GameObject b = Instantiate(boardPrefab, ClearBoardTransform);
              b.transform.position = new Vector3(x,y,z);
              b.tag = "tagB" + x + y + z;
            }
          }
        }
      }

      private void CreateFlame()
      {
        float xCenter = (xLength-1f)/2f;
        float zCenter = (zLength-1f)/2f;
        float yCenter = (yLength-1f)/2f;
        Transform flameXTransform = this.transform.GetChild(1).gameObject.transform;
        Transform flameZTransform = this.transform.GetChild(2).gameObject.transform;
        Transform flameYTransform = this.transform.GetChild(3).gameObject.transform;

        flamePrefab.transform.localScale = new Vector3(xLength,flameWidth,flameWidth);
        for(int y=0; y<=yLength; y++)
        {
          for(int z=0; z<=zLength; z++)
          {
            GameObject f = Instantiate(flamePrefab, flameXTransform);
            f.transform.position = new Vector3(xCenter,y-0.5f,z-0.5f);
          }
        }

        flamePrefab.transform.localScale = new Vector3(zLength,flameWidth,flameWidth);
        flamePrefab.transform.eulerAngles = new Vector3(0,90,0);
        for(int y=0; y<=yLength; y++)
        {
          for(int x=0; x<=xLength; x++)
          {
            GameObject f = Instantiate(flamePrefab, flameZTransform);
            f.transform.position = new Vector3(x-0.5f,y-0.5f,zCenter);
          }
        }

        flamePrefab.transform.localScale = new Vector3(yLength,flameWidth,flameWidth);
        flamePrefab.transform.eulerAngles = new Vector3(0,0,90);
        for(int z=0; z<=zLength; z++)
        {
          for(int x=0; x<=xLength; x++)
          {
            GameObject f = Instantiate(flamePrefab, flameYTransform);
            f.transform.position = new Vector3(x-0.5f,yCenter,z-0.5f);
          }
        }
      }
  }

}
