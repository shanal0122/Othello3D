using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title
{
  public class Game : MonoBehaviour
  {
    private int xLength = 4; //盤の一辺の長さ
    private int yLength = 4;
    private int zLength = 4;
    private Vector3 center;  //オセロ盤の中心位置
    [SerializeField,Range(0f,0.03f)] private float flameWidth = 0.01f;
    public GameObject flamePrefab;
    public GameObject blackStone;
    public GameObject whiteStone;
    private GameObject[] stone;
    public Transform othelloTransform;
    public Transform flameXTransform;
    public Transform flameYTransform;
    public Transform flameZTransform;
    public Transform stonesTransform;

    void Start()
    {
      CreateFlame();
      CreateStone();

      float xCenterCoordi = (xLength - 1f)/2f;
      float yCenterCoordi = (yLength - 1f)/2f;
      float zCenterCoordi = (zLength - 1f)/2f;
      center = new Vector3(xCenterCoordi,yCenterCoordi,zCenterCoordi); //中心位置の定義
      othelloTransform.Rotate(45f,0f,45f);
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Return))
      {
        SceneManager.LoadScene("Choose");
      }
      othelloTransform.RotateAround(center,transform.up,10f*Time.deltaTime);
    }


    private void CreateFlame()
    {
      float xCenter = (xLength-1f)/2f;
      float zCenter = (zLength-1f)/2f;
      float yCenter = (yLength-1f)/2f;

      flamePrefab.transform.localScale = new Vector3(xLength,flameWidth,flameWidth);
      for(int y=0; y<=yLength; y++)
      {
        for(int z=0; z<=zLength; z++)
        {
          GameObject f = Instantiate(flamePrefab, flameXTransform);
          f.transform.position = new Vector3(xCenter,y-0.5f,z-0.5f);
        }
      }

      flamePrefab.transform.localScale = new Vector3(flameWidth,flameWidth,zLength);
      for(int y=0; y<=yLength; y++)
      {
        for(int x=0; x<=xLength; x++)
        {
          GameObject f = Instantiate(flamePrefab, flameZTransform);
          f.transform.position = new Vector3(x-0.5f,y-0.5f,zCenter);
        }
      }

      flamePrefab.transform.localScale = new Vector3(flameWidth,yLength,flameWidth);
      for(int z=0; z<=zLength; z++)
      {
        for(int x=0; x<=xLength; x++)
        {
          GameObject f = Instantiate(flamePrefab, flameYTransform);
          f.transform.position = new Vector3(x-0.5f,yCenter,z-0.5f);
        }
      }
    }

    private void CreateStone()
    {
      stone = new GameObject[8];
      stone[0] = Instantiate(blackStone, stonesTransform);
      stone[0].transform.position = new Vector3(1,1,1);
      stone[1] = Instantiate(blackStone, stonesTransform);
      stone[1].transform.position = new Vector3(2,1,2);
      stone[2] = Instantiate(whiteStone, stonesTransform);
      stone[2].transform.position = new Vector3(1,1,2);
      stone[3] = Instantiate(whiteStone, stonesTransform);
      stone[3].transform.position = new Vector3(2,1,1);
      stone[4] = Instantiate(blackStone, stonesTransform);
      stone[4].transform.position = new Vector3(1,2,2);
      stone[5] = Instantiate(blackStone, stonesTransform);
      stone[5].transform.position = new Vector3(2,2,1);
      stone[6] = Instantiate(whiteStone, stonesTransform);
      stone[6].transform.position = new Vector3(1,2,1);
      stone[7] = Instantiate(whiteStone, stonesTransform);
      stone[7].transform.position = new Vector3(2,2,2);
    }

    public void LoadChooseScene()
    {
      SceneManager.LoadScene("Choose");
    }

  }
}
