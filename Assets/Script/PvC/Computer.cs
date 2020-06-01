using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
      float[,,] basicMap1; //各座標の基本点。座標(0,0,0)に自分の石があればbasicMap1[0,0,0]点入る
      float[,,] basicMap2;
      float[,,] basicMap3;
      float[,,,] sideMap; //各辺の石組み合わせに関する追加点。0:nostone,1:自分の石,2:相手の石
      float[,,,] surfaceMap; //各面上の直線上の石の組み合わせに関する追加点。0:nostone,1:自分の石,2:相手の石

      void Awake()
      {
        basicMap1 = new float[,,]
        {
          { {100f,-10f,-10f,100f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {100f,-10f,-10f,100f} },
          { {-10f, -15f, -15f, -10f}, {-15f, -5f, -5f, -15f}, {-15f, -5f, -5f, -15f}, {-10f, -15f, -15f, -10f} },
          { {-10f, -15f, -15f, -10f}, {-15f, -5f, -5f, -15f}, {-15f, -5f, -5f, -15f}, {-10f, -15f, -15f, -10f} },
          { {100f,-10f,-10,100f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {100f,-10f,-10f,100f} }
        };
        basicMap2 = new float[,,]
        {
          { {82,-10f,-10f,82f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {82f,-10f,-10f,82f} },
          { {-10f, -15f, -15f, -10f}, {-15f, -5f, -5f, -15f}, {-15f, -5f, -5f, -15f}, {-10f, -15f, -15f, -10f} },
          { {-10f, -15f, -15f, -10f}, {-15f, -5f, -5f, -15f}, {-15f, -5f, -5f, -15f}, {-10f, -15f, -15f, -10f} },
          { {82f,-10f,-10,82f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {82f,-10f,-10f,82f} }
        };
        basicMap3 = new float[,,]
        {
          { {72f,-10f,-10f,72f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {72f,-10f,-10f,72f} },
          { {-10f, -13f, -13f, -10f}, {-13f, -5f, -5f, -13f}, {-13f, -5f, -5f, -13f}, {-10f, -13f, -13f, -10f} },
          { {-10f, -13f, -13f, -10f}, {-13f, -5f, -5f, -13f}, {-13f, -5f, -5f, -13f}, {-10f, -13f, -13f, -10f} },
          { {72f,-10f,-10,72f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {72f,-10f,-10f,72f} }
        };
        sideMap = new float[,,,]
        {
          {
            { {0f, 0f, 0f}, {0f, 20f, -40f}, {0f, 40f, -20f} },
            { {0f, -30f, -10f}, {0f, 30f, -100f}, {-60f, -60f, -85f} },
            { {0f, 10f, 30f}, {-60f, 85f, 60f}, {0f, 100f, -30f} }
          },
          {
            { {0f, 0f, 0f}, {-30f, -30f, -40f}, {10f, 40f, -20f} },
            { {20f, -30f, 20f}, {30f, 120f, 20f}, {85f, -40f, 0f} },
            { {40f, 40f, 40f}, {-60f, -40f, 0f}, {100f, -40f, -20f} }
          },
          {
            { {0f, 0f, 0f}, {-10f, 20f, -40f}, {30f, 40f, 30f} },
            { {-40f, -40f, -40f}, {-100f, 20f, 40f}, {60f, 0f, 40f} },
            { {-20f, -20f, 30f}, {-85f, 0f, 40f}, {-30f, -20f, -120f} }
          }
        };
        surfaceMap = new float[,,,]
        {
          {
            { {0f, 0f, 0f}, {0f, 0f, -40f}, {0f, 40f, 0f} },
            { {0f, -20f, 0f}, {0f, 0f, -60f}, {-40f, -40f, -40f} },
            { {0f, 0f, 20f}, {-40f, 40f, 40f}, {0f, 60f, 0f} }
          },
          {
            { {0f, 0f, 0f}, {-20f, -20f, -40f}, {0f, 40f, 0f} },
            { {0f, -20f, 0f}, {0f, 0f, 0f}, {40f, 0f, 0f} },
            { {40f, 40f, 40f}, {-40f, 0f, 0f}, {60f, 0f, 0f} }
          },
          {
            { {0f, 0f, 0f}, {0f, 0f, -40f}, {20f, 40f, 20f} },
            { {-40f, -40f, -40f}, {-60f, 0f, 0f}, {40f, 0f, 0f} },
            { {0f, 0f, 20f}, {-40f, 0f, 0f}, {0f, 0f, 0f} }
          }
        };
      }



      public void CPU1() //CPUが石を置く（置ける場所の中からランダムに置く）
      {
        square = stone.Square;
        cpuStone = game.Turn;
        List<int> sqList = new List<int>(); //xLength*zLength*y+xLength*z+xを代入
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
                if(sumOfFlipNum > 0){ sqList.Add(xLength*zLength*y+xLength*z+x); }
                sumOfFlipNum = 0;
              }
            }
          }
        }
        int rv = (int)(UnityEngine.Random.value * sqList.Count);
        if(rv == sqList.Count){ rv--; }
        int _y = sqList[rv] / (xLength*zLength);
        int _z = (sqList[rv] - xLength*zLength*_y) / xLength;
        int _x = sqList[rv] - xLength*zLength*_y - xLength*_z;
        //Debug.Log("sqList.Count : " + sqList.Count); //////////////////////////////////////////////////////////////////////////////////////////////
        //Debug.Log("rv : " + rv);
        //Debug.Log("x,y,z : " + _x + " " + _z + " " + _y); //////////////////////////////////////////////////////////////////////////////////////////////
        bool a = stone.FlipStone(cpuStone,_x,_y,_z);
      }

      public void CPU2() //CPUが石を置く（上の評価関数を用いて石を置く。1手先の読み）
      {
        List<int> sqListX = new List<int>();
        List<int> sqListY = new List<int>();
        List<int> sqListZ = new List<int>();
        float score = 0;
        float? bestScore = null;
        square = stone.Square;
        cpuStone = game.Turn;
        int[,,] willSq = new int[xLength,yLength,zLength];
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              if(square[x,y,z] == 0)
              {
                willSq = TryFlip(square, cpuStone, x, y, z);
                if(willSq != null)
                {
                  score = CulScoreBest(willSq);
                  if(bestScore == null){ bestScore = score; sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z); }
                  if(bestScore == score){ sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z); }
                  if(bestScore < score)
                  {
                    bestScore = score;
                    sqListX = new List<int>(); sqListY = new List<int>(); sqListZ = new List<int>();
                    sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z);
                  }
                  score = 0;
                }
              }
            }
          }
        }
        int rv = (int)(UnityEngine.Random.value * sqListX.Count);
        if(rv == sqListX.Count){ rv--; }
        Debug.Log("sqList.Count : " + sqListX.Count); //////////////////////////////////////////////////////////////////////////////////////////////
        Debug.Log("rv : " + rv);
        Debug.Log("x,z,y : " + sqListX[rv] + " " + sqListZ[rv] + " " + sqListY[rv]); //////////////////////////////////////////////////////////////////////////////////////////////
        bool a = stone.FlipStone(cpuStone,sqListX[rv], sqListY[rv], sqListZ[rv]);
      }

      public int TryFlipNum(int[,,] sq, int stone, int x, int y, int z, int vec) //stone{1,-1}を座標(x,y,z)に置いたらvec方向のコマを返せるはずの個数を返す
      {
        int flipNum = 0;
        int myStone = stone;
        int yourStone = -1 * stone;
        while(true)
        {
          x += vector[vec,0];
          y += vector[vec,1];
          z += vector[vec,2];
          try
          {
            if(sq[x,y,z] == yourStone)
            {
              flipNum++;
            }else if(sq[x,y,z] == myStone)
            {
              break;
            }else
            {
              flipNum = 0;break;
            }
          }catch(IndexOutOfRangeException)
          {
            flipNum = 0;break;
          }
        }
        return flipNum;
      }

      public int[,,] TryFlip(int[,,] sq, int stone, int x, int y, int z) //座標(x,y,z)にstoneをおき裏返しturnを変更したらどうなるか見る。おいた後の配列を返す
      {
        int[,,] newsq = new int[xLength,yLength,zLength];
        Array.Copy(sq, newsq, sq.Length);
        int sumOfFlipNum = 0;
        int flipNum = 0;
        for(int vec=0; vec<vector.GetLength(0); vec++)
        {
          flipNum = TryFlipNum(sq, stone, x, y, z, vec);
          sumOfFlipNum += flipNum;
          for(int n=1; n<=flipNum; n++)
          {
            newsq[x+n*vector[vec,0], y+n*vector[vec,1], z+n*vector[vec,2]] = stone;
          }
          flipNum = 0;
        }
        if(sumOfFlipNum != 0)
        {
          newsq[x,y,z] = stone;
          return newsq;
        }
        else
        {
          return null;
        }
      }

      private float CulScoreBest(int[,,] sq)
      {
        int n;
        if(game.TotalTurn < 20){ n = 1; } else if(game.TotalTurn < 40){ n = 2; } else{ n = 3; }
        return CulBasic(n,sq,basicMap1,basicMap2,basicMap3) + CulSide(sq,sideMap) + CulSurface(sq,surfaceMap);
      }

      private float CulBasic(int n, int[,,] sq, float[,,] map1, float[,,] map2, float[,,] map3)
      {
        float[,,] basicMap = new float[xLength,yLength,zLength];
        if(n == 1){ basicMap = map1; }
        if(n == 2){ basicMap = map2; }
        if(n == 3){ basicMap = map3; }
        float score = 0;
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              if(sq[x,y,z] == cpuStone){ score += basicMap[x,y,z]; }
              if(sq[x,y,z] == -1*cpuStone){ score -= basicMap[x,y,z]; }
            }
          }
        }
        return score;
      }

      private float CulSide(int[,,] sq, float[,,,] map)
      {
        float score = 0;
        score += map[ TransSqIndex(cpuStone*sq[0,0,0]), TransSqIndex(cpuStone*sq[1,0,0]), TransSqIndex(cpuStone*sq[2,0,0]), TransSqIndex(cpuStone*sq[3,0,0])];
        score += map[ TransSqIndex(cpuStone*sq[0,0,3]), TransSqIndex(cpuStone*sq[1,0,3]), TransSqIndex(cpuStone*sq[2,0,3]), TransSqIndex(cpuStone*sq[3,0,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,3,0]), TransSqIndex(cpuStone*sq[1,3,0]), TransSqIndex(cpuStone*sq[2,3,0]), TransSqIndex(cpuStone*sq[3,3,0])];
        score += map[ TransSqIndex(cpuStone*sq[0,3,3]), TransSqIndex(cpuStone*sq[1,3,3]), TransSqIndex(cpuStone*sq[2,3,3]), TransSqIndex(cpuStone*sq[3,3,3])];

        score += map[ TransSqIndex(cpuStone*sq[0,0,0]), TransSqIndex(cpuStone*sq[0,1,0]), TransSqIndex(cpuStone*sq[0,2,0]), TransSqIndex(cpuStone*sq[0,3,0])];
        score += map[ TransSqIndex(cpuStone*sq[3,0,0]), TransSqIndex(cpuStone*sq[3,1,0]), TransSqIndex(cpuStone*sq[3,2,0]), TransSqIndex(cpuStone*sq[3,3,0])];
        score += map[ TransSqIndex(cpuStone*sq[0,0,3]), TransSqIndex(cpuStone*sq[0,1,3]), TransSqIndex(cpuStone*sq[0,2,3]), TransSqIndex(cpuStone*sq[0,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[3,0,3]), TransSqIndex(cpuStone*sq[3,1,3]), TransSqIndex(cpuStone*sq[3,2,3]), TransSqIndex(cpuStone*sq[3,3,3])];

        score += map[ TransSqIndex(cpuStone*sq[0,0,0]), TransSqIndex(cpuStone*sq[0,0,1]), TransSqIndex(cpuStone*sq[0,0,2]), TransSqIndex(cpuStone*sq[0,0,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,3,0]), TransSqIndex(cpuStone*sq[0,3,1]), TransSqIndex(cpuStone*sq[0,3,2]), TransSqIndex(cpuStone*sq[0,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[3,0,0]), TransSqIndex(cpuStone*sq[3,0,1]), TransSqIndex(cpuStone*sq[3,0,2]), TransSqIndex(cpuStone*sq[3,0,3])];
        score += map[ TransSqIndex(cpuStone*sq[3,3,0]), TransSqIndex(cpuStone*sq[3,3,1]), TransSqIndex(cpuStone*sq[3,3,2]), TransSqIndex(cpuStone*sq[3,3,3])];

        return score;
      }

      private float CulSurface(int[,,] sq, float[,,,] map)
      {
        float score = 0;
        score += map[ TransSqIndex(cpuStone*sq[0,0,1]), TransSqIndex(cpuStone*sq[1,0,1]), TransSqIndex(cpuStone*sq[2,0,1]), TransSqIndex(cpuStone*sq[3,0,1])];
        score += map[ TransSqIndex(cpuStone*sq[0,0,2]), TransSqIndex(cpuStone*sq[1,0,2]), TransSqIndex(cpuStone*sq[2,0,2]), TransSqIndex(cpuStone*sq[3,0,2])];
        score += map[ TransSqIndex(cpuStone*sq[0,1,3]), TransSqIndex(cpuStone*sq[1,1,3]), TransSqIndex(cpuStone*sq[2,1,3]), TransSqIndex(cpuStone*sq[3,1,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,2,3]), TransSqIndex(cpuStone*sq[1,2,3]), TransSqIndex(cpuStone*sq[2,2,3]), TransSqIndex(cpuStone*sq[3,2,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,3,2]), TransSqIndex(cpuStone*sq[1,3,2]), TransSqIndex(cpuStone*sq[2,3,2]), TransSqIndex(cpuStone*sq[3,3,2])];
        score += map[ TransSqIndex(cpuStone*sq[0,3,1]), TransSqIndex(cpuStone*sq[1,3,1]), TransSqIndex(cpuStone*sq[2,3,1]), TransSqIndex(cpuStone*sq[3,3,1])];
        score += map[ TransSqIndex(cpuStone*sq[0,2,0]), TransSqIndex(cpuStone*sq[1,2,0]), TransSqIndex(cpuStone*sq[2,2,0]), TransSqIndex(cpuStone*sq[3,2,0])];
        score += map[ TransSqIndex(cpuStone*sq[0,1,0]), TransSqIndex(cpuStone*sq[1,1,0]), TransSqIndex(cpuStone*sq[2,1,0]), TransSqIndex(cpuStone*sq[3,1,0])];

        score += map[ TransSqIndex(cpuStone*sq[1,0,0]), TransSqIndex(cpuStone*sq[1,1,0]), TransSqIndex(cpuStone*sq[1,2,0]), TransSqIndex(cpuStone*sq[1,3,0])];
        score += map[ TransSqIndex(cpuStone*sq[2,0,0]), TransSqIndex(cpuStone*sq[2,1,0]), TransSqIndex(cpuStone*sq[2,2,0]), TransSqIndex(cpuStone*sq[2,3,0])];
        score += map[ TransSqIndex(cpuStone*sq[3,0,1]), TransSqIndex(cpuStone*sq[3,1,1]), TransSqIndex(cpuStone*sq[3,2,1]), TransSqIndex(cpuStone*sq[3,3,1])];
        score += map[ TransSqIndex(cpuStone*sq[3,0,2]), TransSqIndex(cpuStone*sq[3,1,2]), TransSqIndex(cpuStone*sq[3,2,2]), TransSqIndex(cpuStone*sq[3,3,2])];
        score += map[ TransSqIndex(cpuStone*sq[2,0,3]), TransSqIndex(cpuStone*sq[2,1,3]), TransSqIndex(cpuStone*sq[2,2,3]), TransSqIndex(cpuStone*sq[2,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[1,0,3]), TransSqIndex(cpuStone*sq[1,1,3]), TransSqIndex(cpuStone*sq[1,2,3]), TransSqIndex(cpuStone*sq[1,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,0,2]), TransSqIndex(cpuStone*sq[0,1,2]), TransSqIndex(cpuStone*sq[0,2,2]), TransSqIndex(cpuStone*sq[0,3,2])];
        score += map[ TransSqIndex(cpuStone*sq[0,0,1]), TransSqIndex(cpuStone*sq[0,1,1]), TransSqIndex(cpuStone*sq[0,2,1]), TransSqIndex(cpuStone*sq[0,3,1])];

        score += map[ TransSqIndex(cpuStone*sq[0,1,0]), TransSqIndex(cpuStone*sq[0,1,1]), TransSqIndex(cpuStone*sq[0,1,2]), TransSqIndex(cpuStone*sq[0,1,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,2,0]), TransSqIndex(cpuStone*sq[0,2,1]), TransSqIndex(cpuStone*sq[0,2,2]), TransSqIndex(cpuStone*sq[0,2,3])];
        score += map[ TransSqIndex(cpuStone*sq[1,3,0]), TransSqIndex(cpuStone*sq[1,3,1]), TransSqIndex(cpuStone*sq[1,3,2]), TransSqIndex(cpuStone*sq[1,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[2,3,0]), TransSqIndex(cpuStone*sq[2,3,1]), TransSqIndex(cpuStone*sq[2,3,2]), TransSqIndex(cpuStone*sq[2,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[3,2,0]), TransSqIndex(cpuStone*sq[3,2,1]), TransSqIndex(cpuStone*sq[3,2,2]), TransSqIndex(cpuStone*sq[3,2,3])];
        score += map[ TransSqIndex(cpuStone*sq[3,1,0]), TransSqIndex(cpuStone*sq[3,1,1]), TransSqIndex(cpuStone*sq[3,1,2]), TransSqIndex(cpuStone*sq[3,1,3])];
        score += map[ TransSqIndex(cpuStone*sq[2,0,0]), TransSqIndex(cpuStone*sq[2,0,1]), TransSqIndex(cpuStone*sq[2,0,2]), TransSqIndex(cpuStone*sq[2,0,3])];

        score += map[ TransSqIndex(cpuStone*sq[0,0,0]), TransSqIndex(cpuStone*sq[1,0,1]), TransSqIndex(cpuStone*sq[2,0,2]), TransSqIndex(cpuStone*sq[3,0,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,0,3]), TransSqIndex(cpuStone*sq[1,0,2]), TransSqIndex(cpuStone*sq[2,0,1]), TransSqIndex(cpuStone*sq[3,0,0])];
        score += map[ TransSqIndex(cpuStone*sq[0,3,0]), TransSqIndex(cpuStone*sq[1,3,1]), TransSqIndex(cpuStone*sq[2,3,2]), TransSqIndex(cpuStone*sq[3,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,3,3]), TransSqIndex(cpuStone*sq[1,3,2]), TransSqIndex(cpuStone*sq[2,3,1]), TransSqIndex(cpuStone*sq[3,3,0])];

        score += map[ TransSqIndex(cpuStone*sq[0,0,0]), TransSqIndex(cpuStone*sq[1,1,0]), TransSqIndex(cpuStone*sq[2,2,0]), TransSqIndex(cpuStone*sq[3,3,0])];
        score += map[ TransSqIndex(cpuStone*sq[3,0,0]), TransSqIndex(cpuStone*sq[2,1,0]), TransSqIndex(cpuStone*sq[1,2,0]), TransSqIndex(cpuStone*sq[0,3,0])];
        score += map[ TransSqIndex(cpuStone*sq[0,0,3]), TransSqIndex(cpuStone*sq[1,1,3]), TransSqIndex(cpuStone*sq[2,2,3]), TransSqIndex(cpuStone*sq[3,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[3,0,3]), TransSqIndex(cpuStone*sq[2,1,3]), TransSqIndex(cpuStone*sq[1,2,3]), TransSqIndex(cpuStone*sq[0,3,3])];

        score += map[ TransSqIndex(cpuStone*sq[0,0,0]), TransSqIndex(cpuStone*sq[0,1,1]), TransSqIndex(cpuStone*sq[0,2,2]), TransSqIndex(cpuStone*sq[0,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[0,3,0]), TransSqIndex(cpuStone*sq[0,2,1]), TransSqIndex(cpuStone*sq[0,1,2]), TransSqIndex(cpuStone*sq[0,0,3])];
        score += map[ TransSqIndex(cpuStone*sq[3,0,0]), TransSqIndex(cpuStone*sq[3,1,1]), TransSqIndex(cpuStone*sq[3,2,2]), TransSqIndex(cpuStone*sq[3,3,3])];
        score += map[ TransSqIndex(cpuStone*sq[3,3,0]), TransSqIndex(cpuStone*sq[3,2,1]), TransSqIndex(cpuStone*sq[3,1,2]), TransSqIndex(cpuStone*sq[3,0,3])];

        return score;
      }

      private int TransSqIndex(int n) //0->0,1->1,-1->2
      {
        return (3 * n * n - n) / 2;
      }

      public int[,] Vector { get {return vector;} set {vector = value;} }
  }
}
