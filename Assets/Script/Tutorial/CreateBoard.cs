using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
  public class CreateBoard : MonoBehaviour
  {
      private int xLength = 4; //盤の一辺の長さ
      private int yLength = 4;
      private int zLength = 4;
      [SerializeField,Range(0f,0.03f)] private float flameWidth = 0.01f;
      public GameObject flamePrefab;

      void Start()
      {
          CreateFlame();
      }


      private void CreateFlame()
      {
        float xCenter = (xLength-1f)/2f;
        float zCenter = (zLength-1f)/2f;
        float yCenter = (yLength-1f)/2f;
        Transform flameXTransform = this.transform.GetChild(0).gameObject.transform;
        Transform flameZTransform = this.transform.GetChild(1).gameObject.transform;
        Transform flameYTransform = this.transform.GetChild(2).gameObject.transform;

        flamePrefab.transform.localScale = new Vector3(xLength,flameWidth,flameWidth);
        for(int y=0; y<=yLength; y++)
        {
          for(int z=0; z<=zLength; z++)
          {
            GameObject f = Instantiate(flamePrefab, flameXTransform);
            f.transform.position = new Vector3(xCenter,y-0.5f,z-0.5f);
          }
        }

        flamePrefab.transform.localScale = new Vector3(flameWidth,flameWidth,zLength);
        for(int y=0; y<=yLength; y++)
        {
          for(int x=0; x<=xLength; x++)
          {
            GameObject f = Instantiate(flamePrefab, flameZTransform);
            f.transform.position = new Vector3(x-0.5f,y-0.5f,zCenter);
          }
        }

        flamePrefab.transform.localScale = new Vector3(flameWidth,yLength,flameWidth);
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
