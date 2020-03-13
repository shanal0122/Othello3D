using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField,Range(5f,15f)] private float movingSpeed = 10f; //カメラの動くスピードを設定
    private float squaredDistance; //カメラを球面状で動かす時の半径
    private Vector3 defaultPosition; //カメラの初期位置 （推奨 : (1.5f,1.5f,-5.1f)）
    private Transform mainCameraTransform;
    private Vector3 center;  //オセロ盤の中心位置

    void Start()
    {
        center = new Vector3(1.5f,1.5f,1.5f); //中心位置の定義
        mainCameraTransform = this.gameObject.transform;
        defaultPosition = mainCameraTransform.position;
        squaredDistance = (defaultPosition.x - center.x) * (defaultPosition.x - center.x) + (defaultPosition.y - center.y) * (defaultPosition.y - center.y) + (defaultPosition.z - center.z) * (defaultPosition.z - center.z);
        mainCameraTransform.LookAt(center,Vector3.up);
    }


    void Update()
    {
        CameraPosotionControlByKey();
    }

    private void CameraPosotionControlByKey() //矢印キーでメインカメラを動かす
    {
      Vector3 pos = mainCameraTransform.position;
      if(Input.GetKey(KeyCode.RightArrow))
      {
        float r = Mathf.Sqrt(squaredDistance-(pos.y-center.y)*(pos.y-center.y));
        float d = Time.deltaTime * movingSpeed;
        float x = center.x + (pos.x-center.x) * Mathf.Cos(d/r) - (pos.z-center.z) * Mathf.Sin(d/r);
        float z = center.z + (pos.z-center.z) * Mathf.Cos(d/r) + (pos.x-center.x) * Mathf.Sin(d/r);
        mainCameraTransform.position = new Vector3 (x,pos.y,z);
      }
      if(Input.GetKey(KeyCode.LeftArrow))
      {
        float r = Mathf.Sqrt(squaredDistance-(pos.y-center.y)*(pos.y-center.y));
        float d = Time.deltaTime * movingSpeed;
        float x = center.x + (pos.x-center.x) * Mathf.Cos(d/r) + (pos.z-center.z) * Mathf.Sin(d/r);
        float z = center.z + (pos.z-center.z) * Mathf.Cos(d/r) - (pos.x-center.x) * Mathf.Sin(d/r);
        mainCameraTransform.position = new Vector3 (x,pos.y,z);
      }
      if(Input.GetKey(KeyCode.UpArrow))
      {
        if(pos.y <= 7.5)
        {
          float r = Mathf.Sqrt(squaredDistance);
          float rxy = Mathf.Sqrt(squaredDistance-(pos.y-center.y)*(pos.y-center.y));
          float d = Time.deltaTime * movingSpeed;
          float y = center.y + (pos.y-center.y) * Mathf.Cos(d/r) + rxy * Mathf.Sin(d/r);
          float con = Mathf.Sqrt((squaredDistance-(y-center.y)*(y-center.y))/(squaredDistance-(pos.y-center.y)*(pos.y-center.y)));
          float x = center.x + con * (pos.x-center.x);
          float z = center.z + con * (pos.z-center.z);
          mainCameraTransform.position = new Vector3 (x,y,z);
        }
      }
      if(Input.GetKey(KeyCode.DownArrow))
      {
        if(pos.y >= -4.5)
        {
          float r = Mathf.Sqrt(squaredDistance);
          float rxy = Mathf.Sqrt(squaredDistance-(pos.y-center.y)*(pos.y-center.y));
          float d = Time.deltaTime * movingSpeed;
          float y = center.y + (pos.y-center.y) * Mathf.Cos(d/r) - rxy * Mathf.Sin(d/r);
          float con = Mathf.Sqrt((squaredDistance-(y-center.y)*(y-center.y))/(squaredDistance-(pos.y-center.y)*(pos.y-center.y)));
          float x = center.x + con * (pos.x-center.x);
          float z = center.z + con * (pos.z-center.z);
          mainCameraTransform.position = new Vector3 (x,y,z);
        }
      }
      mainCameraTransform.LookAt(center,Vector3.up);
    }
}
