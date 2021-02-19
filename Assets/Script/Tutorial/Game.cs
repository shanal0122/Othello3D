using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tutorial
{
  public class Game : MonoBehaviour
  {
      private int xLength = 4; //オセロ盤の一辺の長さ
      private int yLength = 4;
      private int zLength = 4;
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      private Vector3 standard;
      private int degree = -1; //この値によって表示されるCanvasや受け付けるキーを制御する
      private int[] coordi; //大きさ3。degreeが6,7,8のときに入力された値を格納
      private bool doTutorialFlug = true; //trueの時だけDoTutorial()を実行する。従って一度のみ実行される
      public GameObject blackStone;
      public GameObject whiteStone;
      public GameObject shineBoardPrefab;
      public GameObject informShinyBoardPrefab;
      public GameObject lastPutSpherePrefab;
      public GameObject coordinateTextPrefab;
      public Transform stone;
      public Transform shineBoard;
      public Transform informShinyBoard;
      public Transform lastPutSphere;
      public CameraMover cameraMover;
      public GameObject coordinateCanvas;
      public GameObject centerCanvas;
      public Text claimText1;
      public Text claimText2;

      private Text claimText;

      public GameObject canvas_1_L;
      public GameObject canvas0_L;
      public GameObject canvas1_L;
      public GameObject canvas2_L;
      public GameObject canvas3_L;
      public GameObject canvas4_L;
      public GameObject canvas5_L;
      public GameObject canvas6to9_L;
      public GameObject canvas10_L;
      public GameObject canvas11_L;

      public GameObject canvas_1_P;
      public GameObject canvas0_P;
      public GameObject canvas1_P;
      public GameObject canvas2_P;
      public GameObject canvas3_P;
      public GameObject canvas4_P;
      public GameObject canvas5_P;
      public GameObject canvas6to9_P;
      public GameObject canvas10_P;
      public GameObject canvas11_P;

      private GameObject canvas_1;
      private GameObject canvas0;
      private GameObject canvas1;
      private GameObject canvas2;
      private GameObject canvas3;
      private GameObject canvas4;
      private GameObject canvas5;
      private GameObject canvas6to9;
      private GameObject canvas10;
      private GameObject canvas11;

      private GameObject[,,] bs; //[x,y,z]にあるblackStoneを格納
      private GameObject[,,] ws; //[x,y,z]にあるwhiteStoneを格納
      private GameObject[,,] sb; //[x,y,z]にあるshineBoardを格納
      private GameObject[,,] isb; //[x,y,z]にあるinformShinyBoardを格納
      private GameObject[,,] lpb; //[x,y,z]にあるlastPutBoardを格納


      void Start()
      {
          swidth = Screen.width; sheight = Screen.height;
          if(swidth > sheight)
          {
            canvas_1 = canvas_1_L;
            canvas0 = canvas0_L;
            canvas1 = canvas1_L;
            canvas2 = canvas2_L;
            canvas3 = canvas3_L;
            canvas4 = canvas4_L;
            canvas5 = canvas5_L;
            canvas6to9 = canvas6to9_L;
            canvas10 = canvas10_L;
            canvas11 = canvas11_L;
            claimText = claimText1;
          }
          if(swidth <= sheight)
          {
            canvas_1 = canvas_1_P;
            canvas0 = canvas0_P;
            canvas1 = canvas1_P;
            canvas2 = canvas2_P;
            canvas3 = canvas3_P;
            canvas4 = canvas4_P;
            canvas5 = canvas5_P;
            canvas6to9 = canvas6to9_P;
            canvas10 = canvas10_P;
            canvas11 = canvas11_P;
            claimText = claimText2;
          }
          standard = new Vector3 (xLength-1f, yLength-1f, zLength-1f);
          coordi = new int[3];
          bs = new GameObject[xLength,yLength,zLength];
          ws = new GameObject[xLength,yLength,zLength];
          sb = new GameObject[xLength,yLength,zLength];
          isb = new GameObject[xLength,yLength,zLength];
          lpb = new GameObject[xLength,yLength,zLength];
         for(int y=0; y<yLength; y++)
         {
           for(int z=0; z<zLength; z++)
           {
             for(int x=0; x<xLength; x++)
            {
               bs[x,y,z] = Instantiate(blackStone, stone);
               bs[x,y,z].transform.position = new Vector3(x,y,z);
               bs[x,y,z].SetActive(false);
               ws[x,y,z] = Instantiate(whiteStone, stone);
               ws[x,y,z].transform.position = new Vector3(x,y,z);
               ws[x,y,z].SetActive(false);
               sb[x,y,z] = Instantiate(shineBoardPrefab, shineBoard);
               sb[x,y,z].transform.position = new Vector3(x,y,z);
               sb[x,y,z].SetActive(false);
               isb[x,y,z] = Instantiate(informShinyBoardPrefab, informShinyBoard);
               isb[x,y,z].transform.position = new Vector3(x,y,z);
               isb[x,y,z].SetActive(false);
               lpb[x,y,z] = Instantiate(lastPutSpherePrefab, lastPutSphere);
               lpb[x,y,z].transform.position = new Vector3(x,y,z);
               lpb[x,y,z].SetActive(false);
             }
           }
         }
      }

      void Update()
      {
          if(doTutorialFlug){ DoTutorial(); }
          if(Input.GetKeyDown(KeyCode.Backspace)){ OnBackClick(); }
          OnKeyDetect();
          foreach(GameObject display in GameObject.FindGameObjectsWithTag("CoordinateDisplay")) //CoordinateDisplayクラスのテキストの向きを定める
          {
            display.transform.LookAt(standard - cameraMover.MainCameraTransformPosition,Vector3.up);
          }
      }

      private void DoTutorial()
      {
        if(degree == -1)
        {
          canvas_1.GetComponent<Canvas>().enabled = true;
          canvas0.GetComponent<Canvas>().enabled = false;
          BeforePressedIndicate();
          ws[1,1,0].SetActive(true);
          bs[2,1,0].SetActive(true);
          isb[0,1,0].SetActive(true);
        }
        if(degree == 0)
        {
          canvas_1.GetComponent<Canvas>().enabled = false;
          canvas0.GetComponent<Canvas>().enabled = true;
          canvas1.GetComponent<Canvas>().enabled = false;
          BeforePressedIndicate();
          ws[1,1,0].SetActive(true);
          bs[2,1,0].SetActive(true);
          isb[0,1,0].SetActive(true);
        }
        if(degree == 1)
        {
          canvas0.GetComponent<Canvas>().enabled = false;
          canvas1.GetComponent<Canvas>().enabled = true;
          canvas2.GetComponent<Canvas>().enabled = false;
          BeforePressedIndicate();
          for(int y=0; y<zLength; y++)
          {
            for(int z=0; z<zLength; z++)
           {
              sb[0,y,z].SetActive(false);
            }
          }
        }
        if(degree == 2)
        {
          canvas1.GetComponent<Canvas>().enabled = false;
          canvas2.GetComponent<Canvas>().enabled = true;
          canvas3.GetComponent<Canvas>().enabled = false;
          AfterXPressedIndicate();
          for(int y=0; y<zLength; y++)
          {
            for(int z=0; z<zLength; z++)
           {
              sb[0,y,z].SetActive(true);
            }
          }
          sb[0,1,0].SetActive(false);
        }
        if(degree == 3)
        {
          canvas2.GetComponent<Canvas>().enabled = false;
          canvas3.GetComponent<Canvas>().enabled = true;
          canvas4.GetComponent<Canvas>().enabled = false;
          AfterZPressedIndicate();
          for(int y=0; y<zLength; y++)
          {
            for(int z=0; z<zLength; z++)
           {
              sb[0,y,z].SetActive(false);
            }
          }
          for(int y=0; y<yLength; y++)
          {
            sb[0,y,0].SetActive(true);
          }
          sb[0,1,0].SetActive(false);
        }
        if(degree == 4)
        {
          canvas3.GetComponent<Canvas>().enabled = false;
          canvas4.GetComponent<Canvas>().enabled = true;
          canvas5.GetComponent<Canvas>().enabled = false;
          AfterYPressedDisplay();
          for(int y=0; y<yLength; y++)
          {
            sb[0,y,0].SetActive(false);
          }
          bs[0,1,0].SetActive(false);
          ws[1,1,0].SetActive(true);
          bs[1,1,0].SetActive(false);
          isb[0,1,0].SetActive(true);
          lpb[0,1,0].SetActive(false);
        }
        if(degree == 5)
        {
          canvas4.GetComponent<Canvas>().enabled = false;
          canvas5.GetComponent<Canvas>().enabled = true;
          canvas6to9.GetComponent<Canvas>().enabled = false;
          AfterYPressedDisplay();
          bs[0,1,0].SetActive(true);
          ws[1,1,0].SetActive(false);
          bs[1,1,0].SetActive(true);
          bs[2,1,0].SetActive(true);
          lpb[0,1,0].SetActive(true);
          bs[1,1,1].SetActive(false);
          bs[2,1,2].SetActive(false);
          ws[1,1,2].SetActive(false);
          ws[2,1,1].SetActive(false);
          bs[1,2,2].SetActive(false);
          bs[2,2,1].SetActive(false);
          ws[1,2,1].SetActive(false);
          ws[2,2,2].SetActive(false);
          isb[0,1,0].SetActive(false);
          isb[0,1,2].SetActive(false);
          isb[0,2,1].SetActive(false);
          isb[1,0,2].SetActive(false);
          isb[1,1,3].SetActive(false);
          isb[1,2,0].SetActive(false);
          isb[1,3,1].SetActive(false);
          isb[2,0,1].SetActive(false);
          isb[2,1,0].SetActive(false);
          isb[2,2,3].SetActive(false);
          isb[2,3,2].SetActive(false);
          isb[3,1,1].SetActive(false);
          isb[3,2,2].SetActive(false);
        }
        if(degree == 6)
        {
          canvas5.GetComponent<Canvas>().enabled = false;
          canvas6to9.GetComponent<Canvas>().enabled = true;
          BeforePressedIndicate();
          bs[0,1,0].SetActive(false);
          bs[1,1,0].SetActive(false);
          bs[2,1,0].SetActive(false);
          lpb[0,1,0].SetActive(false);
          bs[1,1,1].SetActive(true);
          bs[2,1,2].SetActive(true);
          ws[1,1,2].SetActive(true);
          ws[2,1,1].SetActive(true);
          bs[1,2,2].SetActive(true);
          bs[2,2,1].SetActive(true);
          ws[1,2,1].SetActive(true);
          ws[2,2,2].SetActive(true);
          for(int y=0; y<yLength; y++)
          {
            for(int z=0; z<zLength; z++)
            {
              for(int x=0; x<xLength; x++)
             {
                sb[x,y,z].SetActive(false);
              }
            }
          }
          isb[0,1,2].SetActive(true);
          isb[0,2,1].SetActive(true);
          isb[1,0,2].SetActive(true);
          isb[1,1,3].SetActive(true);
          isb[1,2,0].SetActive(true);
          isb[1,3,1].SetActive(true);
          isb[2,0,1].SetActive(true);
          isb[2,1,0].SetActive(true);
          isb[2,2,3].SetActive(true);
          isb[2,3,2].SetActive(true);
          isb[3,1,1].SetActive(true);
          isb[3,2,2].SetActive(true);
        }
        if(degree == 7)
        {
          AfterXPressedIndicate();
          isb[0,1,2].SetActive(false);
          isb[0,2,1].SetActive(false);
          isb[1,0,2].SetActive(false);
          isb[1,1,3].SetActive(false);
          isb[1,2,0].SetActive(false);
          isb[1,3,1].SetActive(false);
          isb[2,0,1].SetActive(false);
          isb[2,1,0].SetActive(false);
          isb[2,2,3].SetActive(false);
          isb[2,3,2].SetActive(false);
          isb[3,1,1].SetActive(false);
          isb[3,2,2].SetActive(false);
          if(coordi[0] == 0)
          {
            for(int y=0; y<yLength; y++)
            {
              for(int z=0; z<zLength; z++)
              {
                sb[0,y,z].SetActive(true);
              }
            }
            sb[0,1,2].SetActive(false); sb[0,2,1].SetActive(false); isb[0,1,2].SetActive(true); isb[0,2,1].SetActive(true);
          }
          if(coordi[0] == 1)
          {
            for(int y=0; y<yLength; y++)
            {
              for(int z=0; z<zLength; z++)
              {
                sb[1,y,z].SetActive(true);
              }
            }
            sb[1,0,2].SetActive(false); sb[1,1,3].SetActive(false); sb[1,2,0].SetActive(false); sb[1,3,1].SetActive(false);
            isb[1,0,2].SetActive(true); isb[1,1,3].SetActive(true); isb[1,2,0].SetActive(true); isb[1,3,1].SetActive(true);
          }
          if(coordi[0] == 2)
          {
            for(int y=0; y<yLength; y++)
            {
              for(int z=0; z<zLength; z++)
              {
                sb[2,y,z].SetActive(true);
              }
            }
            sb[2,0,1].SetActive(false); sb[2,1,0].SetActive(false); sb[2,2,3].SetActive(false); sb[2,3,2].SetActive(false);
            isb[2,0,1].SetActive(true); isb[2,1,0].SetActive(true); isb[2,2,3].SetActive(true); isb[2,3,2].SetActive(true);          }
          if(coordi[0] == 3)
          {
            for(int y=0; y<yLength; y++)
            {
              for(int z=0; z<zLength; z++)
              {
                sb[3,y,z].SetActive(true);
              }
            }
            sb[3,1,1].SetActive(false); sb[3,2,2].SetActive(false); isb[3,1,1].SetActive(true); isb[3,2,2].SetActive(true);
          }
        }
        if(degree == 8)
        {
          AfterZPressedIndicate();
          for(int y=0; y<yLength; y++)
          {
            for(int z=0; z<zLength; z++)
            {
              for(int x=0; x<xLength; x++)
             {
                sb[x,y,z].SetActive(false); isb[x,y,z].SetActive(false);
              }
            }
          }
          if(coordi[0] == 0)
          {
            if(coordi[1] == 0){ sb[0,0,0].SetActive(true); sb[0,1,0].SetActive(true); sb[0,2,0].SetActive(true); sb[0,3,0].SetActive(true); }
            if(coordi[1] == 1){ sb[0,0,1].SetActive(true); sb[0,1,1].SetActive(true); isb[0,2,1].SetActive(true); sb[0,3,1].SetActive(true); }
            if(coordi[1] == 2){ sb[0,0,2].SetActive(true); isb[0,1,2].SetActive(true); sb[0,2,2].SetActive(true); sb[0,3,2].SetActive(true); }
            if(coordi[1] == 3){ sb[0,0,3].SetActive(true); sb[0,1,3].SetActive(true); sb[0,2,3].SetActive(true); sb[0,3,3].SetActive(true); }
          }
          if(coordi[0] == 1)
          {
            if(coordi[1] == 0){ sb[1,0,0].SetActive(true); sb[1,1,0].SetActive(true); isb[1,2,0].SetActive(true); sb[1,3,0].SetActive(true); }
            if(coordi[1] == 1){ sb[1,0,1].SetActive(true); sb[1,1,1].SetActive(true); sb[1,2,1].SetActive(true); isb[1,3,1].SetActive(true); }
            if(coordi[1] == 2){ isb[1,0,2].SetActive(true); sb[1,1,2].SetActive(true); sb[1,2,2].SetActive(true); sb[1,3,2].SetActive(true); }
            if(coordi[1] == 3){ sb[1,0,3].SetActive(true); isb[1,1,3].SetActive(true); sb[1,2,3].SetActive(true); sb[1,3,3].SetActive(true); }
          }
          if(coordi[0] == 2)
          {
            if(coordi[1] == 0){ sb[2,0,0].SetActive(true); isb[2,1,0].SetActive(true); sb[2,2,0].SetActive(true); sb[2,3,0].SetActive(true); }
            if(coordi[1] == 1){ isb[2,0,1].SetActive(true); sb[2,1,1].SetActive(true); sb[2,2,1].SetActive(true); sb[2,3,1].SetActive(true); }
            if(coordi[1] == 2){ sb[2,0,2].SetActive(true); sb[2,1,2].SetActive(true); sb[2,2,2].SetActive(true); isb[2,3,2].SetActive(true); }
            if(coordi[1] == 3){ sb[2,0,3].SetActive(true); sb[2,1,3].SetActive(true); isb[2,2,3].SetActive(true); sb[2,3,3].SetActive(true); }
          }
          if(coordi[0] == 3)
          {
            if(coordi[1] == 0){ sb[3,0,0].SetActive(true); sb[3,1,0].SetActive(true); sb[3,2,0].SetActive(true); sb[3,3,0].SetActive(true); }
            if(coordi[1] == 1){ sb[3,0,1].SetActive(true); isb[3,1,1].SetActive(true); sb[3,2,1].SetActive(true); sb[3,3,1].SetActive(true); }
            if(coordi[1] == 2){ sb[3,0,2].SetActive(true); sb[3,1,2].SetActive(true); isb[3,2,2].SetActive(true); sb[3,3,2].SetActive(true); }
            if(coordi[1] == 3){ sb[3,0,3].SetActive(true); sb[3,1,3].SetActive(true); sb[3,2,3].SetActive(true); sb[3,3,3].SetActive(true); }
          }
        }
        if(degree == 9)
        {
          canvas6to9.GetComponent<Canvas>().enabled = true;
          canvas10.GetComponent<Canvas>().enabled = false;
          AfterYPressedDisplay();
          for(int y=0; y<yLength; y++)
          {
            for(int z=0; z<zLength; z++)
            {
              for(int x=0; x<xLength; x++)
             {
                sb[x,y,z].SetActive(false); isb[x,y,z].SetActive(false);
              }
            }
          }
          if(coordi[0] == 0 && coordi[1] == 1 && coordi[2] == 2){ isb[0,2,1].SetActive(true); bs[0,2,1].SetActive(false); ws[1,2,1].SetActive(true); bs[1,2,1].SetActive(false); }
          else if(coordi[0] == 0 && coordi[1] == 2 && coordi[2] == 1){ isb[0,1,2].SetActive(true); bs[0,1,2].SetActive(false); ws[1,1,2].SetActive(true); bs[1,1,2].SetActive(false); }
          else if(coordi[0] == 1 && coordi[1] == 0 && coordi[2] == 2){ isb[1,2,0].SetActive(true); bs[1,2,0].SetActive(false); ws[1,2,1].SetActive(true); bs[1,2,1].SetActive(false); }
          else if(coordi[0] == 1 && coordi[1] == 1 && coordi[2] == 3){ isb[1,3,1].SetActive(true); bs[1,3,1].SetActive(false); ws[1,2,1].SetActive(true); bs[1,2,1].SetActive(false); }
          else if(coordi[0] == 1 && coordi[1] == 2 && coordi[2] == 0){ isb[1,0,2].SetActive(true); bs[1,0,2].SetActive(false); ws[1,1,2].SetActive(true); bs[1,1,2].SetActive(false); }
          else if(coordi[0] == 1 && coordi[1] == 3 && coordi[2] == 1){ isb[1,1,3].SetActive(true); bs[1,1,3].SetActive(false); ws[1,1,2].SetActive(true); bs[1,1,2].SetActive(false); }
          else if(coordi[0] == 2 && coordi[1] == 0 && coordi[2] == 1){ isb[2,1,0].SetActive(true); bs[2,1,0].SetActive(false); ws[2,1,1].SetActive(true); bs[2,1,1].SetActive(false); }
          else if(coordi[0] == 2 && coordi[1] == 1 && coordi[2] == 0){ isb[2,0,1].SetActive(true); bs[2,0,1].SetActive(false); ws[2,1,1].SetActive(true); bs[2,1,1].SetActive(false); }
          else if(coordi[0] == 2 && coordi[1] == 2 && coordi[2] == 3){ isb[2,3,2].SetActive(true); bs[2,3,2].SetActive(false); ws[2,2,2].SetActive(true); bs[2,2,2].SetActive(false); }
          else if(coordi[0] == 2 && coordi[1] == 3 && coordi[2] == 2){ isb[2,2,3].SetActive(true); bs[2,2,3].SetActive(false); ws[2,2,2].SetActive(true); bs[2,2,2].SetActive(false); }
          else if(coordi[0] == 3 && coordi[1] == 1 && coordi[2] == 1){ isb[3,1,1].SetActive(true); bs[3,1,1].SetActive(false); ws[2,1,1].SetActive(true); bs[2,1,1].SetActive(false); }
          else if(coordi[0] == 3 && coordi[1] == 2 && coordi[2] == 2){ isb[3,2,2].SetActive(true); bs[3,2,2].SetActive(false); ws[2,2,2].SetActive(true); bs[2,2,2].SetActive(false); }
          else { sb[coordi[0],coordi[2],coordi[1]].SetActive(true); }
        }
        if(degree == 10)
        {
          BeforePressedIndicate();
          if(coordi[0] == 0 && coordi[1] == 1 && coordi[2] == 2){ isb[0,2,1].SetActive(false); bs[0,2,1].SetActive(true); ws[1,2,1].SetActive(false); bs[1,2,1].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 0 && coordi[1] == 2 && coordi[2] == 1){ isb[0,1,2].SetActive(false); bs[0,1,2].SetActive(true); ws[1,1,2].SetActive(false); bs[1,1,2].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 1 && coordi[1] == 0 && coordi[2] == 2){ isb[1,2,0].SetActive(false); bs[1,2,0].SetActive(true); ws[1,2,1].SetActive(false); bs[1,2,1].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 1 && coordi[1] == 1 && coordi[2] == 3){ isb[1,3,1].SetActive(false); bs[1,3,1].SetActive(true); ws[1,2,1].SetActive(false); bs[1,2,1].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 1 && coordi[1] == 2 && coordi[2] == 0){ isb[1,0,2].SetActive(false); bs[1,0,2].SetActive(true); ws[1,1,2].SetActive(false); bs[1,1,2].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 1 && coordi[1] == 3 && coordi[2] == 1){ isb[1,1,3].SetActive(false); bs[1,1,3].SetActive(true); ws[1,1,2].SetActive(false); bs[1,1,2].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 2 && coordi[1] == 0 && coordi[2] == 1){ isb[2,1,0].SetActive(false); bs[2,1,0].SetActive(true); ws[2,1,1].SetActive(false); bs[2,1,1].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 2 && coordi[1] == 1 && coordi[2] == 0){ isb[2,0,1].SetActive(false); bs[2,0,1].SetActive(true); ws[2,1,1].SetActive(false); bs[2,1,1].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 2 && coordi[1] == 2 && coordi[2] == 3){ isb[2,3,2].SetActive(false); bs[2,3,2].SetActive(true); ws[2,2,2].SetActive(false); bs[2,2,2].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 2 && coordi[1] == 3 && coordi[2] == 2){ isb[2,2,3].SetActive(false); bs[2,2,3].SetActive(true); ws[2,2,2].SetActive(false); bs[2,2,2].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 3 && coordi[1] == 1 && coordi[2] == 1){ isb[3,1,1].SetActive(false); bs[3,1,1].SetActive(true); ws[2,1,1].SetActive(false); bs[2,1,1].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else if(coordi[0] == 3 && coordi[1] == 2 && coordi[2] == 2){ isb[3,2,2].SetActive(false); bs[3,2,2].SetActive(true); ws[2,2,2].SetActive(false); bs[2,2,2].SetActive(true); canvas6to9.GetComponent<Canvas>().enabled = false; canvas10.GetComponent<Canvas>().enabled = true; centerCanvas.GetComponent<Canvas>().enabled = false; canvas11.GetComponent<Canvas>().enabled = false;}
          else
          {
            sb[coordi[0],coordi[2],coordi[1]].SetActive(false); CantPutIndicate(); degree = 6;
            isb[0,1,2].SetActive(true);
            isb[0,2,1].SetActive(true);
            isb[1,0,2].SetActive(true);
            isb[1,1,3].SetActive(true);
            isb[1,2,0].SetActive(true);
            isb[1,3,1].SetActive(true);
            isb[2,0,1].SetActive(true);
            isb[2,1,0].SetActive(true);
            isb[2,2,3].SetActive(true);
            isb[2,3,2].SetActive(true);
            isb[3,1,1].SetActive(true);
            isb[3,2,2].SetActive(true);
          }
        }
        if(degree == 11)
        {
          canvas10.GetComponent<Canvas>().enabled = false;
          centerCanvas.GetComponent<Canvas>().enabled = true;
          canvas11.GetComponent<Canvas>().enabled = true;
          PlayerPrefs.SetInt("Value_of_PlayerSkill", 1);
        }
        doTutorialFlug = false;
      }

      private void OnKeyDetect()
      {
        if(degree == -1 || degree == 0 || degree == 4 || degree == 5 || degree == 9 || degree == 10)
        {
          if(Input.GetKeyDown(KeyCode.Return))
          {
            degree++;
            doTutorialFlug = true;
          }
        }
        if(degree == 1 || degree == 2)
        {
          if(Input.GetKeyDown("1"))
          {
            degree++;
            doTutorialFlug = true;
          }
        }
        if(degree == 3)
        {
          if(Input.GetKeyDown("2"))
          {
            degree++;
            doTutorialFlug = true;
          }
        }
        if(degree == 6 || degree == 7 || degree == 8)
        {
          if(Input.GetKeyDown("1"))
          {
            coordi[degree-6] = 0;
            degree++;
            doTutorialFlug = true;
          }
          if(Input.GetKeyDown("2"))
          {
            coordi[degree-6] = 1;
            degree++;
            doTutorialFlug = true;
          }
          if(Input.GetKeyDown("3"))
          {
            coordi[degree-6] = 2;
            degree++;
            doTutorialFlug = true;
          }
          if(Input.GetKeyDown("4"))
          {
            coordi[degree-6] = 3;
            degree++;
            doTutorialFlug = true;
          }
        }
      }

      private void OnBackClick()
      {
        if(degree >= 0)
        {
          degree--;
          doTutorialFlug = true;
        }
      }

      public void KeyBackSpaceDetect() //スマホ版でbackspaceのボタンが押された時の挙動
      {
        if(degree >= 0)
        {
          degree--;
          doTutorialFlug = true;
        }
      }

      public void Key1Detect() //スマホ版で1のボタンが押された時の挙動
      {
        if(degree == 1 || degree == 2)
        {
            degree++;
            doTutorialFlug = true;

        }
        if(degree == 6 || degree == 7 || degree == 8)
        {
            coordi[degree-6] = 0;
            degree++;
            doTutorialFlug = true;
        }
      }

      public void Key2Detect() //スマホ版で2のボタンが押された時の挙動
      {
        if(degree == 3)
        {
            degree++;
            doTutorialFlug = true;
        }
        if(degree == 6 || degree == 7 || degree == 8)
        {
            coordi[degree-6] = 1;
            degree++;
            doTutorialFlug = true;
        }
      }

      public void Key3Detect() //スマホ版で3のボタンが押された時の挙動
      {
        if(degree == 6 || degree == 7 || degree == 8)
        {
            coordi[degree-6] = 2;
            degree++;
            doTutorialFlug = true;
        }
      }

      public void Key4Detect() //スマホ版で4のボタンが押された時の挙動
      {
        if(degree == 6 || degree == 7 || degree == 8)
        {
            coordi[degree-6] = 3;
            degree++;
            doTutorialFlug = true;
        }
      }

      public void KeyReturnDetect() //スマホ版でreturnのボタンが押された時の挙動
      {
        if(degree == -1 || degree == 0 || degree == 4 || degree == 5 || degree == 9 || degree == 10)
        {
            degree++;
            doTutorialFlug = true;
        }
      }


      private void RemoveCoordiIndicate()
      {
        GameObject[] displays = GameObject.FindGameObjectsWithTag("CoordinateDisplay");
        foreach(GameObject display in displays)
        {
          Destroy(display);
        }
      }

      private void BeforePressedIndicate()
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

      private void AfterXPressedIndicate()
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

      private void AfterZPressedIndicate()
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

      private void AfterYPressedDisplay()
      {
        RemoveCoordiIndicate();
      }

      public void CantPutIndicate() //石を置けないはずの場所に置いた時に怒る
      {
        claimText.text = "そこには\n置けません";
        Invoke("ClaimTextClear",1);
      }

      public void ClaimTextClear()
      {
        claimText.text = null;
      }


      public void OnLoadTitleClick()
      {
        SceneManager.LoadScene("Choose");
        PlayerPrefs.SetInt("Value_of_PlayerSkill", 1);
      }

  }
}
