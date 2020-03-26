using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Choose;

namespace PvP
{
  public class Stone : MonoBehaviour
  {
      private int xLength = InitialSetting.xLength; //盤の一辺の長さ
      private int yLength = InitialSetting.yLength;
      private int zLength = InitialSetting.zLength;
      private int[,,] square; //noStone : 0, blackStone : 1, whiteStone : -1
      private readonly int[,] vector = new int[,]{{0,1,0},{1,1,0},{0,1,1},{-1,1,0},{0,1,-1},{1,0,0},{1,0,1},{0,0,1},{-1,0,1},{-1,0,0},{-1,0,-1},{0,0,-1},{1,0,-1},{1,-1,0},{0,-1,1},{-1,-1,0},{0,-1,-1},{0,-1,0}};
      public GameObject blackStone;
      public GameObject whiteStone;
      public Game game; //GameからTurnを受け取る
      public ChangeColor changeColor; //CanPutAndInformで置ける場所を光らせる
      public InfoDisplay infoDisplay;


      void Start()
      {
         square = new int[xLength,yLength,zLength];
      }

      private int FlipNum(int stone, int x, int y, int z, int vec) //stone{1,-1}を座標(x,y,z)に置いた時vec方向のコマを返せる個数を返す
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
            if(square[x,y,z] == yourStone)
            {
              flipNum++;
            }else if(square[x,y,z] == myStone)
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

      public void PutStone(int stone, int x, int y, int z) //座標(x,y,z)に石をおく
      {
        if(stone == 1)
        {
          GameObject s = Instantiate(blackStone, this.transform);
          s.transform.position = new Vector3(x, y, z);
          s.tag = "tagS" + x + y + z;
          square[x,y,z] = 1;
        }
        if(stone == -1)
        {
          GameObject s = Instantiate(whiteStone, this.transform);
          s.transform.position = new Vector3(x, y, z);
          s.tag = "tagS" + x + y + z;
          square[x,y,z] = -1;
        }
        if(stone != 1 && stone != -1)
        {
          Debug.Log("Error : Stone/PutStone");//////////////////////////////////////////////////////////////////////////////////////
        }
      }

      private void RemoveStone(int x, int y, int z) //座標(x,y,z)の石を取り除く
      {
        Destroy(GameObject.FindGameObjectWithTag("tagS" + x + y + z));
        square[x,y,z] = 0;
      }

      private int VecFlipStone(int stone, int x, int y, int z, int vec) //stone{-1,1}を座標(x,y,z)に置いた時のvec方向のstoneを裏返す。戻り値は裏返す石の数
      {
        int flipNum = FlipNum(stone, x, y, z, vec);
        for(int n=1; n<=flipNum; n++)
        {
          RemoveStone(x+n*vector[vec,0], y+n*vector[vec,1], z+n*vector[vec,2]);
          PutStone(stone, x+n*vector[vec,0], y+n*vector[vec,1], z+n*vector[vec,2]);
        }
        return flipNum;
      }

      public void FlipStone(int stone, int x, int y, int z) //座標(x,y,z)に石をおき裏返しturnを変更する。置けない時は何もしない。Game.squareListに盤の情報を格納
      {
        if(square[x,y,z] == 0)
        {
          int sumOfFlipNum = 0;
          for(int n=0; n<vector.GetLength(0); n++)
          {
            sumOfFlipNum += VecFlipStone(stone, x, y, z, n);
          }
          if(sumOfFlipNum != 0)
          {
            PutStone(stone,x,y,z);
            game.Turn *= -1;
            Game.totalTurn++; //待った機能のための情報の格納
            for(int _y=0; _y<yLength; _y++)
            {
              for(int _z=0; _z<zLength; _z++)
              {
                for(int _x=0; _x<xLength; _x++)
                {
                  Game.squareList[Game.totalTurn, xLength * zLength * _y + xLength * _z + _x] = square[_x,_y,_z];
                }
              }
            }

          }else {infoDisplay.CantPutIndicate();}
        }
      }

      public void PutAllStoneAsList() //待ったが押された時盤面を元に戻す
      {
        for(int _y=0; _y<yLength; _y++)
        {
          for(int _z=0; _z<zLength; _z++)
          {
            for(int _x=0; _x<xLength; _x++)
            {
              RemoveStone(_x,_y,_z);
              square[_x,_y,_z] = Game.squareList[Game.totalTurn-1, xLength * zLength * _y + xLength * _z + _x];
              if(square[_x,_y,_z] == 1 || square[_x,_y,_z] == -1)
              {
                PutStone(square[_x,_y,_z],_x,_y,_z);
              }
            }
          }
        }
        game.SetBeforePressed = false;
        game.SetAfterXPressed = false;
        game.SetAfterZPressed = false;
        game.SetAfterYPressed = false;
        game.SetEnterPressed = false;
        game.XCoordi = game.YCoordi = game.ZCoordi = 0;
      }


      public int CountStone(int stone) //盤上にあるstoneの数を数える
      {
        int stoneNum = 0;
        foreach(int sq in square) {if(sq == stone) {stoneNum++;}}
        if(stone != 1 && stone != -1)
        {
          Debug.Log("Error : Stone/CountStone");//////////////////////////////////////////////////////////////////////////////////////
        }
        return stoneNum;
      }

      public bool CanPut(int stone) //stoneを置ける場所が一つでもあればtrueを返す
      {
        if(stone != 1 && stone != -1)
        {
          Debug.Log("Error : Stone/CanPut");//////////////////////////////////////////////////////////////////////////////////////
        }
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              for(int n=0; n<vector.GetLength(0); n++)
              {
                if(square[x,y,z] == 0 && FlipNum(stone,x,y,z,n) != 0) {return true;}
              }
            }
          }
        }
        return false;
      }

      public bool CanPutAndInform(int stone) //stoneを置ける場所が一つでもあればtrueを返す。置ける場所を光らせる（Menu画面で変更可能）
      {
        if(stone != 1 && stone != -1)
        {
          Debug.Log("Error : Stone/CanPutAndInform");//////////////////////////////////////////////////////////////////////////////////////
        }
        bool canPut = false;
        bool cp = false; //各マスの少なくとも1つの方向で石が返せるならtrue。これにより各マスの置ける場所を光らせる
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
                cp = false;
                for(int n=0; n<vector.GetLength(0); n++)
                {
                  if(square[x,y,z] == 0 && FlipNum(stone,x,y,z,n) != 0)
                  {
                    cp = true;
                    canPut = true;
                  }
                }
                if(cp) {changeColor.InformShineBoardColor(x,y,z);} //光らせる
            }
          }
        }
        return canPut;
      }

      public void Inform(int stone, int x, int y, int z) //(x,y,z)に石が置けるなら光らせる（Menu画面で変更可能）
      {
        if(stone != 1 && stone != -1)
        {
          Debug.Log("Error : Stone/CanPutAndInform");//////////////////////////////////////////////////////////////////////////////////////
        }
        if(square[x,y,z] == 0)
        {
          bool cp = false; //各マスの少なくとも1つの方向で石が返せるならtrue。これにより各マスの置ける場所を光らせる
          for(int n=0; n<vector.GetLength(0); n++)
          {
            if(FlipNum(stone,x,y,z,n) != 0) { cp = true; break; }
          }
          if(cp) {changeColor.InformShineBoardColor(x,y,z);}
        }
      }

      public int[,,] Square { get {return square;} }
  }

}
