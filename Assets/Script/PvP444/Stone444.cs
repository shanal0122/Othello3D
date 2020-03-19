using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone444 : MonoBehaviour
{
    private int[,,] square = new int[4,4,4];
    private readonly int[,] vector = new int[,]{{0,1,0},{1,1,0},{0,1,1},{-1,1,0},{0,1,-1},{1,0,0},{1,0,1},{0,0,1},{-1,0,1},{-1,0,0},{-1,0,-1},{0,0,-1},{1,0,-1},{1,-1,0},{0,-1,1},{-1,-1,0},{0,-1,-1},{0,-1,0}};
    public GameObject blackStone; //stone=1
    public GameObject whiteStone; //stone=-1
    public GameObject stones; //stone=0
    public GameObject master; //GameからTurnを受け取る


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

    public void PutStone(int stone, int x, int y, int z) //座標(x,y,z)の石を取り除く
    {
      if(stone == 1)
      {
        GameObject s = Instantiate(blackStone, stones.transform);
        s.transform.position = new Vector3(x, y, z);
        s.tag = "tagS" + x + y + z;
        square[x,y,z] = 1;
      }
      if(stone == -1)
      {
        GameObject s = Instantiate(whiteStone, stones.transform);
        s.transform.position = new Vector3(x, y, z);
        s.tag = "tagS" + x + y + z;
        square[x,y,z] = -1;
      }
    }

    private void RemoveStone(int x, int y, int z) //座標(x,y,z)の石を取り除く
    {
      Destroy(GameObject.FindGameObjectWithTag("tagS" + x + y + z));
      square[x,y,z] = 0;
    }

    private int VecFlipStone(int stone, int x, int y, int z, int vec) //stone{-1,1}を座標(x,z)に置いた時のvec方向のstoneを裏返す。戻り値は裏返す石の数
    {
      int flipNum = FlipNum(stone, x, y, z, vec);
      for(int n=1; n<=flipNum; n++)
      {
        RemoveStone(x+n*vector[vec,0], y+n*vector[vec,1], z+n*vector[vec,2]);
        PutStone(stone, x+n*vector[vec,0], y+n*vector[vec,1], z+n*vector[vec,2]);
      }
      return flipNum;
    }

    public void FlipStone(int stone, int x, int y, int z)
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
          master.GetComponent<Game444>().Turn *= -1;
        }
      }
    }
}
