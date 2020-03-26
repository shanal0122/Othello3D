using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Choose
{
  public class InitialSetting : MonoBehaviour
  {
      public static int xLength;
      public static int yLength;
      public static int zLength;


      public void ChoosePvP444()
      {
        xLength = 4;
        yLength = 4;
        zLength = 4;
        SceneManager.LoadScene("PvP444");
      }

      public void ChoosePvP666()
      {
        xLength = 6;
        yLength = 6;
        zLength = 6;
        SceneManager.LoadScene("PvP666");
      }
  }

}
