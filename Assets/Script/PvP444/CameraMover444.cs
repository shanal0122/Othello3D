using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP444
{
  public class CameraMover444 : MonoBehaviour
  {
      [SerializeField,Range(5f,15f)] private float movingSpeed = 10f; //カメラの動くスピードを設定
      private float squaredDistance; //カメラを球面状で動かす時の半径の二乗
      private float upLimit; //カメラの上方向に動く限界のy座標
      private float downLimit; //カメラの上方向に動く限界のy座標
      private Vector3 defaultPosition; //カメラの初期位置
      private Transform mainCameraTransform;
      private Vector3 center;  //オセロ盤の中心位置
      public GameObject master;


      void Start()
      {
          float xCenterCoordi =1.5f;
          float yCenterCoordi =1.5f;
          float zCenterCoordi =1.5f;
          center = new Vector3(xCenterCoordi,yCenterCoordi,zCenterCoordi); //中心位置の定義

          mainCameraTransform = this.gameObject.transform;
          mainCameraTransform.position = new Vector3 (xCenterCoordi, yCenterCoordi, zCenterCoordi - 8f);
          defaultPosition = mainCameraTransform.position;

          squaredDistance = (defaultPosition.x - center.x) * (defaultPosition.x - center.x) + (defaultPosition.y - center.y) * (defaultPosition.y - center.y) + (defaultPosition.z - center.z) * (defaultPosition.z - center.z);
          upLimit = center.y + Mathf.Sqrt(squaredDistance) - 0.5f;
          downLimit = center.y - Mathf.Sqrt(squaredDistance) + 0.5f;

          mainCameraTransform.LookAt(center,Vector3.up);
      }


      void LateUpdate()
      {
          if(master.GetComponent<Game444>().KeyDetectable) {CameraPosotionControlByKey();}
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
          if(pos.y <= upLimit)
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
          if(pos.y >= downLimit)
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

      public Vector3 MainCameraTransformPosition {get {return this.mainCameraTransform.position;} }
  }

}
