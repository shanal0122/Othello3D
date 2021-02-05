using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor; //PlayerPrefs.DeleteAll()のためのもの

namespace Choose
{
  public class InitialSetting : MonoBehaviour
  {
      private int playerSkill = 0; //初めてのプレイなら0。2回目以降なら1。一番強いCPUに勝てたら称号を与える的なシステムを今後組むかも////////////////////////////////////////
      public static int xLength = 4; //オセロ版の一辺の長さ、yを最大に
      public static int yLength = 4;
      public static int zLength = 4;
      public static int gameMode = 3; //ゲームモードを表す。PlayerPrefsにセーブする時に使う。PvP444:1,PvP464:2,PvC444:3,PvC464:4（中断後再開機能（、リプレイ機能））
      [SerializeField] int playerTurnDef = 1; //CPUvs.CPUをしたいときはインスペクターに0を代入して再生/////////////////////////////////////////////////////////////
      public static int playerTurn = 1; //PvCで用いる。プレイヤーの担当するターンを表す。0のときはCvC
      public static int cpuLevel = 1;  //CPUの難易度を表す。よわいは0、ふつうは1、つよいは2、とても強いは3。
      public static bool continuation = false; //続きからプレイする時はtrue
      public GameObject suspendedConfirmCanvas;
      public GameObject tutorialConfirmCanvas;
      public GameObject menuCanvas;
      public GameObject creditCanvas;
      private bool detectable = true; //ポップアップを開いているときにボタンを押せないようにする

      void Awake()
      {
        //PlayerPrefs.DeleteAll(); EditorApplication.isPlaying = false;
        playerSkill = PlayerPrefs.GetInt("Value_of_PlayerSkill", 0); //tutorialConfirmCanvasでいいえを押すか、TutorialでCanvas11までやるか、タイトルに戻るを押すとフラグが消える
        if(playerSkill == 0){
          tutorialConfirmCanvas.GetComponent<Canvas>().enabled = true;
          detectable = false;
        }

        if(PlayerPrefs.GetInt("Value_of_PlayerTurn", 0) == 0)
        {
          playerTurn = 1;
        }
        if(PlayerPrefs.GetInt("Value_of_PlayerTurn", 0) == 1)
        {
          playerTurn = -1;
        }
        if(PlayerPrefs.GetInt("Value_of_CPULevel", 0) == 0)
        {
          cpuLevel = 0;
        }
        if(PlayerPrefs.GetInt("Value_of_CPULevel", 0) == 1)
        {
          cpuLevel = 1;
        }
        if(PlayerPrefs.GetInt("Value_of_CPULevel", 0) == 2)
        {
          cpuLevel = 2;
        }
        if(PlayerPrefs.GetInt("Value_of_CPULevel", 0) == 3)
        {
          cpuLevel = 3;
        }
      }

      void Start()
      {
        detectable = true;
        if(playerTurnDef == 0){ playerTurn = 0;} ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      }

      public void ChoosePvP444()
      {
        if(detectable)
        {
          xLength = 4;
          yLength = 4;
          zLength = 4;
          gameMode = 1;
          if(PlayerPrefs.HasKey("Record_of_supended_game_1"))
          {
            suspendedConfirmCanvas.GetComponent<Canvas>().enabled = true;
            detectable = false;
          }else{SceneManager.LoadScene("PvP");}
        }
      }

      public void ChoosePvP464()
      {
        if(detectable)
        {
          xLength = 4;
          yLength = 6;
          zLength = 4;
          gameMode = 2;
          if(PlayerPrefs.HasKey("Record_of_supended_game_2"))
          {
            suspendedConfirmCanvas.GetComponent<Canvas>().enabled = true;
            detectable = false;
          }else{SceneManager.LoadScene("PvP");}
        }
      }

      public void ChoosePvC444()
      {
        if(detectable)
        {
          xLength = 4;
          yLength = 4;
          zLength = 4;
          gameMode = 3;
          if(PlayerPrefs.HasKey("Record_of_supended_game_3"))
          {
            suspendedConfirmCanvas.GetComponent<Canvas>().enabled = true;
            detectable = false;
          }else{SceneManager.LoadScene("PvC");}
        }
      }

      public void ChoosePvC464()
      {
        if(detectable)
        {
          xLength = 4;
          yLength = 6;
          zLength = 4;
          gameMode = 4;
          if(PlayerPrefs.HasKey("Record_of_supended_game_4"))
          {
            suspendedConfirmCanvas.GetComponent<Canvas>().enabled = true;
            detectable = false;
          }else{SceneManager.LoadScene("PvC");}
        }
      }

      public void ChooseReplay()
      {
        if(detectable)
        {
          if(PlayerPrefs.HasKey("Record_of_finished_gamemode"))
          {
            gameMode = PlayerPrefs.GetInt("Record_of_finished_gamemode");
            if(gameMode == 1 || gameMode == 3)
            {
              xLength = 4;
              yLength = 4;
              zLength = 4;
            }
            if(gameMode == 2 || gameMode == 4)
            {
              xLength = 4;
              yLength = 6;
              zLength = 4;
            }
            SceneManager.LoadScene("Replay");
          }
        }
      }

      public void OnMenuClick()
      {
        if(detectable)
        {
          menuCanvas.GetComponent<Canvas>().enabled = true;
          detectable = false;
        }
      }

      public void OnMenuCloseClick()
      {
        menuCanvas.GetComponent<Canvas>().enabled = false;
        creditCanvas.GetComponent<Canvas>().enabled = false;
        detectable = true;
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
        detectable = true;
      }


      public void OnTutorialYesClick()
      {
        SceneManager.LoadScene("Tutorial");
      }

      public void OnTutorialNoClick()
      {
        tutorialConfirmCanvas.GetComponent<Canvas>().enabled = false;
        detectable = true;
        PlayerPrefs.SetInt("Value_of_PlayerSkill", 1);
      }
  }
}
