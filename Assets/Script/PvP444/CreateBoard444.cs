using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard444 : MonoBehaviour
{
    public GameObject boardPrefab;
    public GameObject board;
    public Transform boardTransform;

    void Start()
    {
        for(int y=0; y<4; y++)
        {
          for(int z=0; z<4; z++)
          {
            for(int x=0; x<4; x++)
            {
              GameObject b = Instantiate(boardPrefab, board.transform);
              b.transform.position = new Vector3(x,y,z);
              b.tag = "tagB" + x + y + z;
            }
          }
        }
    }
}
