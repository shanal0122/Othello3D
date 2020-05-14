using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Choose
{
  public class InitialSetting : MonoBehaviour
  {
      public static int xLength = 4; //オセロ版の一辺の長さ、yを最大に
      public static int yLength = 4;
      public static int zLength = 4;
      public static int gameMode = 1; //ゲームモードを表す。PlayerPrefsにセーブする時に使う。PvP444:1,PvP464:2,PvC444:3,PvC464:4（中断後再開機能（、リプレイ機能））
      public static bool continuation = false; //続きからプレイする時はtrue
      public GameObject suspendedConfirmCanvas;

      /*void Awake() ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      {
        PlayerPrefs.DeleteAll();
      }*/

      public void ChoosePvP444()
      {
        xLength = 4;
        yLength = 4;
        zLength = 4;
        gameMode = 1;
        if(PlayerPrefs.HasKey("Record_of_supended_game_1"))
        {
          suspendedConfirmCanvas.GetComponent<Canvas>().enabled = true;
        }else{SceneManager.LoadScene("PvP");}
      }

      public void ChoosePvP464()
      {
        xLength = 4;
        yLength = 6;
        zLength = 4;
        gameMode = 2;
        if(PlayerPrefs.HasKey("Record_of_supended_game_2"))
        {
          suspendedConfirmCanvas.GetComponent<Canvas>().enabled = true;
        }else{SceneManager.LoadScene("PvP");}
      }

      public void ChooseReplay()
      {
        if(PlayerPrefs.HasKey("Record_of_finished_gamemode"))
        {
          gameMode = PlayerPrefs.GetInt("Record_of_finished_gamemode");
          if(gameMode == 1)
          {
            xLength = 4;
            yLength = 4;
            zLength = 4;
          }
          if(gameMode == 2)
          {
            xLength = 4;
            yLength = 6;
            zLength = 4;
          }
          SceneManager.LoadScene("Replay");
        }
      }

      public void OnSuspendedYesClick()
      {
        SceneManager.LoadScene("PvP");
        continuation = true;
      }

      public void OnSuspendedNoClick()
      {
        SceneManager.LoadScene("PvP");
      }

      public void OnSuspendedCloseClick()
      {
        suspendedConfirmCanvas.GetComponent<Canvas>().enabled = false;
      }
  }

}
