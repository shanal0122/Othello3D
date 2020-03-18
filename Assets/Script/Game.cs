using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int turn = 1;
    public GameObject stones;


    void Start()
    {
      stones.GetComponent<Stone>().PutStone(1,1,1,1);
      stones.GetComponent<Stone>().PutStone(1,2,1,2);
      stones.GetComponent<Stone>().PutStone(-1,1,1,2);
      stones.GetComponent<Stone>().PutStone(-1,2,1,1);
      stones.GetComponent<Stone>().PutStone(1,1,2,2);
      stones.GetComponent<Stone>().PutStone(1,2,2,1);
      stones.GetComponent<Stone>().PutStone(-1,1,2,1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Turn
    {
      set {this.turn = value;}
      get {return turn;}
    }
}
