using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvC
{
  public class KeyDetector : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private string[] xKeys;
      private string[] yKeys;
      private string[] zKeys;
      public Game game;
      public Stone stone;


      void Start()//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      {
        if(xLength == 4){xKeys = new string[4]{"1", "2", "3", "4"};}
        if(xLength == 6){xKeys = new string[6]{"1", "2", "3", "4", "5", "6"};}
        if(yLength == 4){yKeys = new string[4]{"1", "2", "3", "4"};}
        if(yLength == 6){yKeys = new string[6]{"1", "2", "3", "4", "5", "6"};}
        if(zLength == 4){zKeys = new string[4]{"1", "2", "3", "4"};}
        if(zLength == 6){zKeys = new string[6]{"1", "2", "3", "4", "5", "6"};}
      }


      public void NumKeyDetect() //x,z,y,Enterの順でキーが押されると順にGameクラスの変数に代入
      {
          if(game.XCoordi == 0)
          {
              foreach(string key in xKeys)
              {
                  if(Input.GetKeyDown(key))
                  {
                      game.XCoordi = int.Parse(key);
                  }
              }
              if(Input.GetKeyDown("return"))
              {
                int[] returnInfo = new int[4]; returnInfo = stone.CanPutOnly1(game.Turn);
                if(returnInfo[0] == 1){ game.XCoordi = returnInfo[1]; game.YCoordi = returnInfo[2]; game.ZCoordi = returnInfo[3]; game.SetEnterPressed = true; }
              }
          }else if(game.ZCoordi == 0)
          {
              foreach(string key in zKeys)
              {
                  if(Input.GetKeyDown(key))
                  {
                      game.ZCoordi = int.Parse(key);
                  }
              }
          }else if(game.YCoordi == 0)
          {
              foreach(string key in yKeys)
              {
                  if(Input.GetKeyDown(key))
                  {
                      game.YCoordi = int.Parse(key);
                  }
              }
          }else
          {
              if(Input.GetKeyDown("return"))
              {
                  game.SetEnterPressed = true;
              }
          }
      }

      public void BackSpaceDetect() //backspaceが押されたらx,z,yに0を代入
      {
          if(game.YCoordi != 0)
          {
              if(Input.GetKeyDown("backspace"))
              {
                  game.YCoordi = 0;
              }
          }else if(game.ZCoordi != 0)
          {
              if(Input.GetKeyDown("backspace"))
              {
                  game.ZCoordi = 0;
              }
          }else if(game.XCoordi != 0)
          {
              if(Input.GetKeyDown("backspace"))
              {
                  game.XCoordi = 0;
              }
          }
      }


      public void KeyBackSpaceDetect() //スマホ版でbackspaceのボタンが押された時の挙動
      {
          if(game.YCoordi != 0)
          {
              game.YCoordi = 0;
          }
          else if(game.ZCoordi != 0)
          {
              game.ZCoordi = 0;
          }
          else if(game.XCoordi != 0)
          {
              game.XCoordi = 0;
          }
      }

      public void Key1Detect() //スマホ版で1のボタンが押された時の挙動
      {
          if(game.XCoordi == 0)
          {
              game.XCoordi = 1;
          }
          else if(game.ZCoordi == 0)
          {
              game.ZCoordi = 1;
          }
          else if(game.YCoordi == 0)
          {
              game.YCoordi = 1;
          }
      }

      public void Key2Detect() //スマホ版で2のボタンが押された時の挙動
      {
          if(game.XCoordi == 0)
          {
              game.XCoordi = 2;
          }
          else if(game.ZCoordi == 0)
          {
              game.ZCoordi = 2;
          }
          else if(game.YCoordi == 0)
          {
              game.YCoordi = 2;
          }
      }

      public void Key3Detect() //スマホ版で3のボタンが押された時の挙動
      {
          if(game.XCoordi == 0)
          {
              game.XCoordi = 3;
          }
          else if(game.ZCoordi == 0)
          {
              game.ZCoordi = 3;
          }
          else if(game.YCoordi == 0)
          {
              game.YCoordi = 3;
          }
      }

      public void Key4Detect() //スマホ版で4のボタンが押された時の挙動
      {
          if(game.XCoordi == 0)
          {
              game.XCoordi = 4;
          }
          else if(game.ZCoordi == 0)
          {
              game.ZCoordi = 4;
          }
          else if(game.YCoordi == 0)
          {
              game.YCoordi = 4;
          }
      }

      public void Key5Detect() //スマホ版で5のボタンが押された時の挙動
      {
          if(game.XCoordi == 0)
          {

          }
          else if(game.ZCoordi == 0)
          {

          }
          else if(game.YCoordi == 0)
          {
              game.YCoordi = 5;
          }
      }

      public void Key6Detect() //スマホ版で6のボタンが押された時の挙動
      {
          if(game.XCoordi == 0)
          {

          }
          else if(game.ZCoordi == 0)
          {
              
          }
          else if(game.YCoordi == 0)
          {
              game.YCoordi = 6;
          }
      }

      public void KeyReturnDetect() //スマホ版でreturnのボタンが押された時の挙動
      {
          if(game.XCoordi == 0)
          {
              int[] returnInfo = new int[4]; returnInfo = stone.CanPutOnly1(game.Turn);
              if(returnInfo[0] == 1){ game.XCoordi = returnInfo[1]; game.YCoordi = returnInfo[2]; game.ZCoordi = returnInfo[3]; game.SetEnterPressed = true; }
          }
          else if(game.ZCoordi == 0)
          {

          }
          else if(game.YCoordi == 0)
          {

          }
          else
          {
              game.SetEnterPressed = true;
          }
      }
  }
}
