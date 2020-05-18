using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvC
{
  public class Stone : MonoBehaviour
  {
      private int xLength = Choose.InitialSetting.xLength; //盤の一辺の長さ
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private int playerTurn = Choose.InitialSetting.playerTurn; //プレイヤーの手番
      private float stoneSize;
      private int[,,] square; //最新の盤面が記録されている。noStone : 0, blackStone : 1, whiteStone : -1
      [SerializeField] private bool diagonal = false; //{1,1,1}系のベクトルを採用するか。採用するならtrue/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      private int[,] vector;
      public GameObject blackStone;
      public GameObject whiteStone;
      public Game game; //GameからTurnを受け取る
      public Computer computer;
      public ChangeColor changeColor; //CanPutAndInformで置ける場所を光らせる
      private GameObject[,,] bs; //[x,y,z]にあるblackStoneを格納
      private GameObject[,,] ws; //[x,y,z]にあるwhiteStoneを格納


      void Awake()
      {
          stoneSize = PlayerPrefs.GetFloat("Value_of_StoneSize", 0.6f);
          if(diagonal) //{1,1,1}系のベクトルを採用するか/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          {
            vector = new int[,]{{0,1,0},{1,1,0},{0,1,1},{-1,1,0},{0,1,-1},{1,0,0},{1,0,1},{0,0,1},{-1,0,1},{-1,0,0},{-1,0,-1},{0,0,-1},{1,0,-1},{1,-1,0},{0,-1,1},{-1,-1,0},{0,-1,-1},{0,-1,0},{1,1,1},{1,1,-1},{1,-1,1},{1,-1,-1},{-1,1,1},{-1,1,-1},{-1,-1,1},{-1,-1,-1}};
          }else
          {
            vector = new int[,]{{0,1,0},{1,1,0},{0,1,1},{-1,1,0},{0,1,-1},{1,0,0},{1,0,1},{0,0,1},{-1,0,1},{-1,0,0},{-1,0,-1},{0,0,-1},{1,0,-1},{1,-1,0},{0,-1,1},{-1,-1,0},{0,-1,-1},{0,-1,0}};
          } //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          computer.Vector = vector;

          square = new int[xLength,yLength,zLength];
          bs = new GameObject[xLength,yLength,zLength];
          ws = new GameObject[xLength,yLength,zLength];
          DefStoneSize();
          for(int y=0; y<yLength; y++)
          {
            for(int z=0; z<zLength; z++)
            {
              for(int x=0; x<xLength; x++)
              {
                bs[x,y,z] = Instantiate(blackStone, this.transform);
                bs[x,y,z].transform.position = new Vector3(x,y,z);
                bs[x,y,z].SetActive(false);
                ws[x,y,z] = Instantiate(whiteStone, this.transform);
                ws[x,y,z].transform.position = new Vector3(x,y,z);
                ws[x,y,z].SetActive(false);
              }
            }
          }
      }


      private void DefStoneSize()
      {
        blackStone.transform.localScale = new Vector3(stoneSize, stoneSize, stoneSize);
        whiteStone.transform.localScale = new Vector3(stoneSize, stoneSize, stoneSize);
      }

      public int FlipNum(int stone, int x, int y, int z, int vec) //stone{1,-1}を座標(x,y,z)に置いた時vec方向のコマを返せる個数を返す
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
          bs[x,y,z].SetActive(true);
          square[x,y,z] = 1;
        }
        if(stone == -1)
        {
          ws[x,y,z].SetActive(true);
          square[x,y,z] = -1;
        }
        if(stone != 1 && stone != -1)
        {
          Debug.Log("Error : Stone/PutStone");//////////////////////////////////////////////////////////////////////////////////////
        }
      }

      private void RemoveStone(int x, int y, int z) //座標(x,y,z)の石を取り除く
      {
        if(square[x,y,z] == 1){ bs[x,y,z].SetActive(false); }
        if(square[x,y,z] == -1){ ws[x,y,z].SetActive(false); }
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

      public bool FlipStone(int stone, int x, int y, int z) //座標(x,y,z)にstoneをおき裏返しturnを変更する。置けない時は何もしない。置けたらtrue、置けないならfalseを返す
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
            changeColor.UndoAllSphereColor();
            changeColor.LastPutSphereColor(x,y,z);
            return true;
          }
        }
        return false;
      }

      public int CountStoneWillFlip(int stone, int x, int y, int z) //座標(x,y,z)にstoneをおいた場合に裏返るであろう石の個数を表示する。Game.AfterYPressed()で呼び出される
      {
        if(square[x,y,z] == 0)
        {
          int sumOfFlipNum = 0;
          for(int n=0; n<vector.GetLength(0); n++)
          {
            sumOfFlipNum += FlipNum(stone, x, y, z, n);
          }
          return sumOfFlipNum ;
        }
        return 0;
      }

      public void PutAllStoneAsList() //待ったが押された時盤面をリスト通りに置く。セーブ情報を書き換える
      {
        string[] strArray = game.Recordstr.Split(',');
        for(int n=game.TotalTurn; n>=0; n--)
        {
          if(int.Parse(strArray[n*(xLength*yLength*zLength+1)]) == playerTurn)
          {
            game.TotalTurn = n-1;
            break;
          }
          if(n == 0){ game.TotalTurn = 0; }
        }
        strArray[0] = game.TotalTurn.ToString();
        game.Recordstr = strArray[0];
        for(int n=1; n<(game.TotalTurn+1)*(xLength*yLength*zLength+1)+1; n++)
        {
          game.Recordstr = game.Recordstr + "," + strArray[n];
        }
        game.Turn = int.Parse(strArray[(game.TotalTurn+1)*(xLength*yLength*zLength+1)]);
        for(int _y=0; _y<yLength; _y++)
        {
          for(int _z=0; _z<zLength; _z++)
          {
            for(int _x=0; _x<xLength; _x++)
            {
              RemoveStone(_x,_y,_z);
              square[_x,_y,_z] = int.Parse(strArray[game.TotalTurn * (xLength * yLength * zLength + 1) + xLength * zLength * _y + xLength * _z + _x + 1]);
              if(square[_x,_y,_z] == 1 || square[_x,_y,_z] == -1)
              {
                PutStone(square[_x,_y,_z],_x,_y,_z);
              }
            }
          }
        }
        PlayerPrefs.SetString(game.RecordOfSuspendedKeyName, game.Recordstr);
        PlayerPrefs.Save();
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

      public void ChangeStoneSize() //石の大きさを変える
      {
        DefStoneSize();
        for(int y=0; y<yLength; y++)
        {
          for(int z=0; z<zLength; z++)
          {
            for(int x=0; x<xLength; x++)
            {
              if(bs[x,y,z] != null){ Destroy(bs[x,y,z]); }
              if(ws[x,y,z] != null){ Destroy(ws[x,y,z]); }
              bs[x,y,z] = Instantiate(blackStone, this.transform);
              bs[x,y,z].transform.position = new Vector3(x,y,z);
              bs[x,y,z].SetActive(false);
              ws[x,y,z] = Instantiate(whiteStone, this.transform);
              ws[x,y,z].transform.position = new Vector3(x,y,z);
              ws[x,y,z].SetActive(false);
              if(square[x,y,z] == 1 || square[x,y,z] == -1)
              {
                PutStone(square[x,y,z],x,y,z);
              }
            }
          }
        }
      }

      public float StoneSize { get {return stoneSize;} set {stoneSize = value;}}

      public int[,,] Square { get {return square;} }
  }

}
