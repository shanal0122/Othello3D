using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor444 : MonoBehaviour
{
    public Material clearBoard;
    public Material shinyBoard;
    public GameObject board; //MaxNumを受け取る


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
      for(int y=0; y<board.GetComponent<CreateBoard444>().YMaxNum; y++)
      {
        for(int z=0; z<board.GetComponent<CreateBoard444>().ZMaxNum; z++)
        {
          for(int x=0; x<board.GetComponent<CreateBoard444>().XMaxNum; x++)
          {
            UndoBoardColor(x,y,z);
          }
        }
      }
    }
}
