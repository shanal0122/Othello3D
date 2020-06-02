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
      float[,,] basicMap1_444; //各座標の基本点。座標(0,0,0)に自分の石があればbasicMap1[0,0,0]点入る
      float[,,] basicMap2_444;
      float[,,] basicMap3_444;
      float[,,,] sideMap444; //各辺の石組み合わせに関する追加点。0:nostone,1:自分の石,2:相手の石
      float[,,,] surfaceMap444; //各面上の直線上の石の組み合わせに関する追加点。0:nostone,1:自分の石,2:相手の石

      void Awake()
      {
        basicMap1_444 = new float[,,]
        {
          { {100f,-10f,-10f,100f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {100f,-10f,-10f,100f} },
          { {-10f, -15f, -15f, -10f}, {-15f, -5f, -5f, -15f}, {-15f, -5f, -5f, -15f}, {-10f, -15f, -15f, -10f} },
          { {-10f, -15f, -15f, -10f}, {-15f, -5f, -5f, -15f}, {-15f, -5f, -5f, -15f}, {-10f, -15f, -15f, -10f} },
          { {100f,-10f,-10,100f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {100f,-10f,-10f,100f} }
        };
        basicMap2_444 = new float[,,]
        {
          { {82,-10f,-10f,82f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {82f,-10f,-10f,82f} },
          { {-10f, -15f, -15f, -10f}, {-15f, -5f, -5f, -15f}, {-15f, -5f, -5f, -15f}, {-10f, -15f, -15f, -10f} },
          { {-10f, -15f, -15f, -10f}, {-15f, -5f, -5f, -15f}, {-15f, -5f, -5f, -15f}, {-10f, -15f, -15f, -10f} },
          { {82f,-10f,-10,82f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {82f,-10f,-10f,82f} }
        };
        basicMap3_444 = new float[,,]
        {
          { {72f,-10f,-10f,72f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {72f,-10f,-10f,72f} },
          { {-10f, -13f, -13f, -10f}, {-13f, -5f, -5f, -13f}, {-13f, -5f, -5f, -13f}, {-10f, -13f, -13f, -10f} },
          { {-10f, -13f, -13f, -10f}, {-13f, -5f, -5f, -13f}, {-13f, -5f, -5f, -13f}, {-10f, -13f, -13f, -10f} },
          { {72f,-10f,-10,72f}, {-10f, -15f, -15f, -10f}, {-10f, -15f, -15f, -10f}, {72f,-10f,-10f,72f} }
        };
        sideMap444 = new float[,,,]
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
        surfaceMap444 = new float[,,,]
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
                  score = CulScoreBest444(willSq);
                  if(bestScore == null){ bestScore = score; sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z); }
                  if(bestScore == score){ sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z); }
                  if(bestScore < score)
                  {
                    bestScore = score;
                    sqListX = new List<int>(); sqListY = new List<int>(); sqListZ = new List<int>();
                    sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z);
                  }
                }
              }
            }
          }
        }
        int rv = (int)(UnityEngine.Random.value * sqListX.Count);
        if(rv == sqListX.Count){ rv--; }
        //Debug.Log("sqList.Count : " + sqListX.Count); //////////////////////////////////////////////////////////////////////////////////////////////
        //Debug.Log("rv : " + rv);
        //Debug.Log("x,z,y : " + sqListX[rv] + " " + sqListZ[rv] + " " + sqListY[rv]); //////////////////////////////////////////////////////////////////////////////////////////////
        bool a = stone.FlipStone(cpuStone,sqListX[rv], sqListY[rv], sqListZ[rv]);
      }

      public void CPU3() //CPUが石を置く（上の評価関数を用いて石を置く。3手先の読み）
      {
        List<int> sqListX = new List<int>();
        List<int> sqListY = new List<int>();
        List<int> sqListZ = new List<int>();
        List<int> sqListXEnemy = new List<int>();
        List<int> sqListYEnemy = new List<int>();
        List<int> sqListZEnemy = new List<int>();
        float score = 0;
        float? bestScore = null;
        float? bestScoreTemp = null;
        float scoreEnemy = 0;
        float? bestScoreEnemy = null;
        square = stone.Square;
        cpuStone = game.Turn;
        int[,,] willSq = new int[xLength,yLength,zLength];
        int[,,] willSqEnemy = new int[xLength,yLength,zLength];
        int[,,] willSqLast = new int[xLength,yLength,zLength];
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
                  sqListXEnemy = new List<int>();
                  sqListYEnemy = new List<int>();
                  sqListZEnemy = new List<int>();
                  for(int _y=0; _y<yLength; _y++)
                  {
                    for(int _z=0; _z<zLength; _z++)
                    {
                      for(int _x=0; _x<xLength; _x++)
                      {
                        if(willSq[_x,_y,_z] == 0)
                        {
                          willSqEnemy = TryFlip(willSq, -1*cpuStone, _x, _y, _z);
                          if(willSqEnemy != null)
                          {
                            scoreEnemy = CulScoreBest444(willSqEnemy);
                            if(bestScoreEnemy == null){ bestScoreEnemy = scoreEnemy; sqListXEnemy.Add(_x); sqListYEnemy.Add(_y); sqListZEnemy.Add(_z); }
                            if(bestScoreEnemy == scoreEnemy){ sqListXEnemy.Add(_x); sqListYEnemy.Add(_y); sqListZEnemy.Add(_z); }
                            if(bestScoreEnemy > scoreEnemy)
                            {
                              bestScoreEnemy = scoreEnemy;
                              sqListXEnemy = new List<int>(); sqListYEnemy = new List<int>(); sqListZEnemy = new List<int>();
                              sqListXEnemy.Add(_x); sqListYEnemy.Add(_y); sqListZEnemy.Add(_z);
                            }
                          }
                        }
                      }
                    }
                  }
                  bestScoreEnemy = null;
                  for(int n=0; n<sqListXEnemy.Count; n++)
                  {
                    willSqEnemy = TryFlip(willSq, -1*cpuStone, sqListXEnemy[n], sqListYEnemy[n], sqListZEnemy[n]);
                    for(int y_=0; y_<yLength; y_++)
                    {
                      for(int z_=0; z_<zLength; z_++)
                      {
                        for(int x_=0; x_<xLength; x_++)
                        {
                          if(willSqEnemy[x_,y_,z_] == 0)
                          {
                            willSqLast = TryFlip(willSqEnemy, cpuStone, x_, y_, z_);
                            if(willSqLast != null)
                            {
                              score = CulScoreBest444(willSqLast);
                              if(bestScoreTemp == null){ bestScoreTemp = score; }
                              if(bestScoreTemp < score){ bestScoreTemp = score; }
                            }
                          }
                        }
                      }
                    }
                    if(bestScoreTemp < bestScore){ break; }
                  }
                  if(bestScore == null){ bestScore = bestScoreTemp; sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z); }
                  if(bestScore == bestScoreTemp){ sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z); }
                  if(bestScore < bestScoreTemp)
                  {
                    bestScore = bestScoreTemp;
                    sqListX = new List<int>(); sqListY = new List<int>(); sqListZ = new List<int>();
                    sqListX.Add(x); sqListY.Add(y); sqListZ.Add(z);
                  }
                  bestScoreTemp = null;
                }
              }
            }
          }
        }
        int rv = (int)(UnityEngine.Random.value * sqListX.Count);
        if(rv == sqListX.Count){ rv--; }
        //Debug.Log("sqList.Count : " + sqListX.Count); //////////////////////////////////////////////////////////////////////////////////////////////
        //Debug.Log("rv : " + rv);
        //Debug.Log("x,z,y : " + sqListX[rv] + " " + sqListZ[rv] + " " + sqListY[rv]); //////////////////////////////////////////////////////////////////////////////////////////////
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

      private float CulScoreBest444(int[,,] sq)
      {
        int n;
        if(game.TotalTurn < 20){ n = 1; } else if(game.TotalTurn < 40){ n = 2; } else{ n = 3; }
        return CulBasic(n,sq,basicMap1_444,basicMap2_444,basicMap3_444) + CulSide444(sq,sideMap444) + CulSurface444(sq,surfaceMap444);
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

      private float CulSide444(int[,,] sq, float[,,,] map)
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

      private float CulSurface444(int[,,] sq, float[,,,] map)
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
