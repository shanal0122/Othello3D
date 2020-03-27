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
      public GameObject boardPrefab;

      void Start()
      {
          for(int y=0; y<yLength; y++)
          {
            for(int z=0; z<zLength; z++)
            {
              for(int x=0; x<xLength; x++)
              {
                GameObject b = Instantiate(boardPrefab, this.transform);
                b.transform.position = new Vector3(x,y,z);
                b.tag = "tagB" + x + y + z;
              }
            }
          }
      }
  }

}
