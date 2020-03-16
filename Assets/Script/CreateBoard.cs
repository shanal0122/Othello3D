using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour
{
    [SerializeField] private int xMaxNum = 4;
    [SerializeField] private int yMaxNum = 4;
    [SerializeField] private int zMaxNum = 4;
    [SerializeField,Range(0f,0.05f)] private float flameWidge = 0.01f; //オセロ盤のフレームの幅
    public GameObject boardPrefab;
    public GameObject board;
    public Transform boardTransform;

    void Start()
    {
        SetBoardFlameWidge();
        for(int y=0; y<yMaxNum; y++)
        {
          for(int z=0; z<zMaxNum; z++)
          {
            for(int x=0; x<xMaxNum ; x++)
            {
              GameObject b = Instantiate(boardPrefab, board.transform);
              b.transform.position = new Vector3(x,y,z);
            }
          }
        }
    }


    void Update()
    {

    }


    private void SetBoardFlameWidge() //オセロ盤のフレームの幅を設定
    {
      float f = flameWidge;
      float p = (1-f)/2;
      boardTransform.GetChild(0).gameObject.transform.position = new Vector3(0,p,-p);
      boardTransform.GetChild(1).gameObject.transform.position = new Vector3(p,p,0);
      boardTransform.GetChild(2).gameObject.transform.position = new Vector3(0,p,p);
      boardTransform.GetChild(3).gameObject.transform.position = new Vector3(-p,p,0);
      boardTransform.GetChild(4).gameObject.transform.position = new Vector3(-p,0,-p);
      boardTransform.GetChild(5).gameObject.transform.position = new Vector3(p,0,-p);
      boardTransform.GetChild(6).gameObject.transform.position = new Vector3(p,0,p);
      boardTransform.GetChild(7).gameObject.transform.position = new Vector3(-p,0,p);
      boardTransform.GetChild(8).gameObject.transform.position = new Vector3(0,-p,-p);
      boardTransform.GetChild(9).gameObject.transform.position = new Vector3(p,-p,0);
      boardTransform.GetChild(10).gameObject.transform.position = new Vector3(0,-p,p);
      boardTransform.GetChild(11).gameObject.transform.position = new Vector3(-p,-p,0);

      boardTransform.GetChild(0).gameObject.transform.localScale = new Vector3(1,f,f);
      boardTransform.GetChild(1).gameObject.transform.localScale = new Vector3(f,f,1);
      boardTransform.GetChild(2).gameObject.transform.localScale = new Vector3(1,f,f);
      boardTransform.GetChild(3).gameObject.transform.localScale = new Vector3(f,f,1);
      boardTransform.GetChild(4).gameObject.transform.localScale = new Vector3(f,1,f);
      boardTransform.GetChild(5).gameObject.transform.localScale = new Vector3(f,1,f);
      boardTransform.GetChild(6).gameObject.transform.localScale = new Vector3(f,1,f);
      boardTransform.GetChild(7).gameObject.transform.localScale = new Vector3(f,1,f);
      boardTransform.GetChild(8).gameObject.transform.localScale = new Vector3(1,f,f);
      boardTransform.GetChild(9).gameObject.transform.localScale = new Vector3(f,f,1);
      boardTransform.GetChild(10).gameObject.transform.localScale = new Vector3(1,f,f);
      boardTransform.GetChild(11).gameObject.transform.localScale = new Vector3(f,f,1);
    }

    public int xMaxNumGet { get {return this.xMaxNum;} }

    public int yMaxNumGet { get {return this.yMaxNum;} }

    public int zMaxNumGet { get {return this.zMaxNum;} }
}
