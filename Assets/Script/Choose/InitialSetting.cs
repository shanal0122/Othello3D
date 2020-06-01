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
      public static int gameMode = 3; //ゲームモードを表す。PlayerPrefsにセーブする時に使う。PvP444:1,PvP464:2,PvC444:3,PvC464:4（中断後再開機能（、リプレイ機能））
      [SerializeField] int playerTurnDef = 1; //プレイヤーの担当するターンをインスペクターから代入可能/////////////////////////////////////////////////////////////
      public static int playerTurn = 1; //PvCで用いる。プレイヤーの担当するターンを表す。0のときはCvC
      [SerializeField] int CPUBlackDef = 2; //黒CPUの難易度を表す。インスペクターから代入可能。PvC.Computer.CPUX()に対応////////////////////////////////////////////////////////////
      public static int CPUBlack = 2;
      [SerializeField] int CPUWhiteDef = 2; //白CPUの難易度を表す。インスペクターから代入可能。PvC.Computer.CPUX()に対応////////////////////////////////////////////////////////////
      public static int CPUWhite = 2;
      public static bool continuation = false; //続きからプレイする時はtrue
      public GameObject suspendedConfirmCanvas;

      /*void Awake() ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      {
        PlayerPrefs.DeleteAll();
      }*/

      void Start()
      {
        playerTurn = playerTurnDef;
        CPUBlack = CPUBlackDef;
        CPUWhite = CPUWhiteDef;
        if(CPUBlack != 1 && CPUBlack != 2 && CPUBlack != 3){ Debug.Log("Error : InitialSetting.CPUBlackの値"); }
        if(CPUWhite != 1 && CPUWhite != 2 && CPUWhite != 3){ Debug.Log("Error : InitialSetting.CPUWhiteの値"); }
      }

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

      public void ChoosePvC444()
      {
        xLength = 4;
        yLength = 4;
        zLength = 4;
        gameMode = 3;
        if(PlayerPrefs.HasKey("Record_of_supended_game_3"))
        {
          suspendedConfirmCanvas.GetComponent<Canvas>().enabled = true;
        }else{SceneManager.LoadScene("PvC");}
      }

      public void ChoosePvC464()
      {
        xLength = 4;
        yLength = 6;
        zLength = 4;
        gameMode = 4;
        if(PlayerPrefs.HasKey("Record_of_supended_game_4"))
        {
          suspendedConfirmCanvas.GetComponent<Canvas>().enabled = true;
        }else{SceneManager.LoadScene("PvC");}
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
        if(gameMode == 1 || gameMode == 2)
        {
          continuation = true;
          SceneManager.LoadScene("PvP");
        }
        if(gameMode == 3 || gameMode == 4)
        {
          continuation = true;
          SceneManager.LoadScene("PvC");
        }
      }

      public void OnSuspendedNoClick()
      {
        if(gameMode == 1 || gameMode == 2){ SceneManager.LoadScene("PvP"); }
        if(gameMode == 3 || gameMode == 4){ SceneManager.LoadScene("PvC"); }
      }

      public void OnSuspendedCloseClick()
      {
        suspendedConfirmCanvas.GetComponent<Canvas>().enabled = false;
      }
  }

}
