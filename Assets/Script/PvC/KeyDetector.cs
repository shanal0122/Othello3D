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
      private int x = 0; //GameObject.csのXCoordiに連動
      private int y = 0;
      private int z = 0;
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
          if(x == 0)
          {
              foreach(string key in xKeys)
              {
                  if(Input.GetKeyDown(key))
                  {
                      x = int.Parse(key);
                      game.XCoordi = x;
                  }
              }
          }else if(z == 0)
          {
              foreach(string key in zKeys)
              {
                  if(Input.GetKeyDown(key))
                  {
                      z = int.Parse(key);
                      game.ZCoordi = z;
                  }
              }
          }else if(y == 0)
          {
              foreach(string key in yKeys)
              {
                  if(Input.GetKeyDown(key))
                  {
                      y = int.Parse(key);
                      game.YCoordi = y;
                  }
              }
          }else
          {
              if(Input.GetKeyDown("return"))
              {
                  game.SetEnterPressed = true;
                  x = y = z = 0;
              }
          }
      }

      public void BackSpaceDetect() //backspaceが押されたらx,z,yに0を代入
      {
          if(y != 0)
          {
              if(Input.GetKeyDown("backspace"))
              {
                  y = 0;
                  game.YCoordi = 0;
              }
          }else if(z != 0)
          {
              if(Input.GetKeyDown("backspace"))
              {
                  z = 0;
                  game.ZCoordi = 0;
              }
          }else if(x != 0)
          {
              if(Input.GetKeyDown("backspace"))
              {
                  x = 0;
                  game.XCoordi = 0;
              }
          }
      }
  }

}
