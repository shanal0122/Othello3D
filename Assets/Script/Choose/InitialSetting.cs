using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Choose
{
  public class InitialSetting : MonoBehaviour
  {
      public static int xLength; //オセロ版の一辺の長さ、yを最大に
      public static int yLength;
      public static int zLength;


      public void ChoosePvP444()
      {
        xLength = 4;
        yLength = 4;
        zLength = 4;
        SceneManager.LoadScene("PvP");
      }

      public void ChoosePvP666()
      {
        xLength = 4;
        yLength = 6;
        zLength = 4;
        SceneManager.LoadScene("PvP");
      }
  }

}
