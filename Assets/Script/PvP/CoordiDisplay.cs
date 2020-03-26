using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Choose;

namespace PvP
{
  public class CoordiDisplay : MonoBehaviour //座標を表すテキストを配置
  {
      private int xLength = InitialSetting.xLength; //盤の一辺の長さ
      private int yLength = InitialSetting.yLength;
      private int zLength = InitialSetting.zLength;
      public GameObject coordinateCanvas;
      public GameObject coordinateTextPrefab;


      private void RemoveCoordiIndicate()
      {
        GameObject[] displays = GameObject.FindGameObjectsWithTag("CoordinateDisplay");
        foreach(GameObject display in displays)
        {
          Destroy(display);
        }
      }

      public void BeforePressedIndicate()
      {
        RemoveCoordiIndicate();
        for(int n=0; n<2; n++)
        {
          for(int x=0; x<xLength; x++)
          {
            GameObject d = Instantiate(coordinateTextPrefab,coordinateCanvas.transform);
            d.GetComponent<Text>().text = (x+1).ToString();
            d.transform.position = new Vector3 (1.1f*x-0.15f, (yLength+1f)*n-0.75f, (zLength - 1f)/2f);
            d.tag = "CoordinateDisplay";
          }
        }
      }

      public void AfterXPressedIndicate()
      {
        RemoveCoordiIndicate();
        for(int n=0; n<2; n++)
        {
          for(int z=0; z<zLength; z++)
          {
            GameObject d = Instantiate(coordinateTextPrefab,coordinateCanvas.transform);
            d.GetComponent<Text>().text = (z+1).ToString();
            d.transform.position = new Vector3 ((xLength - 1f)/2f, (yLength+1f)*n-0.75f, 1.1f*z-0.15f);
            d.tag = "CoordinateDisplay";
          }
        }
      }

      public void AfterZPressedIndicate()
      {
        RemoveCoordiIndicate();
        for(int n=0; n<2; n++)
        {
          for(int y=0; y<yLength; y++)
          {
            GameObject d = Instantiate(coordinateTextPrefab,coordinateCanvas.transform);
            d.GetComponent<Text>().text = (y+1).ToString();
            d.transform.position = new Vector3 ((xLength+1f)*n-0.75f, 1.1f*y-0.15f, (zLength - 1f)/2f);
            d.tag = "CoordinateDisplay";
          }
        }
      }

      public void AfterYPressedDisplay()
      {
        RemoveCoordiIndicate();
      }
  }

}
