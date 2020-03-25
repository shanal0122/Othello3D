using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP666
{
  public class CreateBoard : MonoBehaviour //全ての盤にタグ付けする
  {
      public GameObject boardPrefab;

      void Start()
      {
          for(int y=0; y<6; y++)
          {
            for(int z=0; z<6; z++)
            {
              for(int x=0; x<6; x++)
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
