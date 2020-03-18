using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    private int x = 0;
    private int y = 0;
    private int z = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void NumKeyDetect(ref int n) //1~4が押されたら検出しnに代入
    {
      string[] keys = {"1", "2", "3", "4"};
      if(Input.anyKeyDown)
      {
        foreach(string key in keys)
        {
          if(Input.GetKeyDown(key))
          {
            Debug.Log("押されたキー : " + key); ///////////////////////////////////////
            n = int.Parse(key);
          }
        }
      }
    }

    public void KeyDetect()
    {
      
    }
}
