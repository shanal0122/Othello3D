using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvC
{
  public class Computer : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private int[,,] square; //Game.csに呼ばれたらstone.squareをコピー。noStone : 0, blackStone : 1, whiteStone : -1
      private int[,] vector; //ゲーム開始時にstone.vectorを代入する
      private int cpuStone; //CPUの石。Game.csに呼ばれたらgame.turnをコピー
      public Stone stone;
      public Game game;


      public void CPU() //CPUが石を置く（返せる石の数が最も多い手の中からランダムに置く）
      {
        square = stone.Square;
        cpuStone = game.Turn;
        List<int> sqList = new List<int>(); //xLength*zLength*y+xLength*z+xを代入
        int maxFlippable = 1;　//裏返せる石の最大数
        int sumOfFlipNum = 0; //各石に対して裏返せる石の数
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              if(square[x,y,z] == 0)
              {
                for(int n=0; n<vector.GetLength(0); n++)
                {
                  sumOfFlipNum += stone.FlipNum(cpuStone, x, y, z, n);
                }
                if(sumOfFlipNum == maxFlippable){ sqList.Add(xLength*zLength*y+xLength*z+x); }
                if(sumOfFlipNum > maxFlippable)
                {
                  sqList = new List<int>();
                  sqList.Add(xLength*zLength*y+xLength*z+x);
                  maxFlippable = sumOfFlipNum;
                }
                sumOfFlipNum = 0;
              }
            }
          }
        }
        int rv = (int)(Random.value * sqList.Count);
        if(rv == sqList.Count){ rv--; }
        int _y = sqList[rv] / (xLength*zLength);
        int _z = (sqList[rv] - xLength*zLength*_y) / xLength;
        int _x = sqList[rv] - xLength*zLength*_y - xLength*_z;
        //Debug.Log("maxFlippable : " + maxFlippable); //////////////////////////////////////////////////////////////////////////////////////////////
        //Debug.Log("rv : " + rv);
        //Debug.Log("x,y,z : " + _x + " " + _z + " " + _y); //////////////////////////////////////////////////////////////////////////////////////////////
        bool a = stone.FlipStone(cpuStone,_x,_y,_z);
      }


      public int[,] Vector { get {return vector;} set {vector = value;} }
  }
}
