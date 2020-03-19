using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material clearBoard;
    public Material shinyBoard;


    public void UndoBoardColor(int x, int y, int z)
    {
      GameObject.FindGameObjectWithTag("tagB" + x + y + z).GetComponent<Renderer>().material.color = clearBoard.color;
    }

    public void ShineBoardColor(int x, int y, int z)
    {
      GameObject.FindGameObjectWithTag("tagB" + x + y + z).GetComponent<Renderer>().material.color = shinyBoard.color;
    }

    public void UndoAllBoardColor()
    {
      for(int y=0; y<4; y++)
      {
        for(int z=0; z<4; z++)
        {
          for(int x=0; x<4; x++)
          {
            UndoBoardColor(x,y,z);
          }
        }
      }
    }
}
