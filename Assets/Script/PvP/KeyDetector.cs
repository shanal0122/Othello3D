using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP
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
  }

}
