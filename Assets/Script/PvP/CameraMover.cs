using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PvP
{
  public class CameraMover : MonoBehaviour
  {
      private float swidth; //画面サイズ（幅）
      private float sheight; //画面サイズ（高さ）
      float magni; //RightCamera,LeftCamera,KeyCameraのViewPortRectの倍率
      private int xLength = Choose.InitialSetting.xLength;
      private int yLength = Choose.InitialSetting.yLength;
      private int zLength = Choose.InitialSetting.zLength;
      private bool flickFlug = false; //フリック判定中true
      private float flickSpeed = 0f; //フリック判定がtrueの時、カメラが動くスピード
      private float flickSpeedFirst = 0f; //フリックし始めた瞬間の、カメラが動くスピード
      private float movingSpeed; //カメラの動くスピードを設定
      private float squaredDistance; //カメラを球面状で動かす時の半径の二乗
      private float upLimit; //カメラの上方向に動く限界のy座標
      private float downLimit; //カメラの上方向に動く限界のy座標
      private Vector3 defaultPosition; //カメラの初期位置
      private Vector3 center;  //オセロ盤の中心位置
      private Transform mainCameraTransform;
      public Game game;

      [SerializeField] private Vector2 FlickMinRange = new Vector2(5.0f,5.0f); // フリック最小移動距離
      [SerializeField] private Vector2 SwipeMinRange = new Vector2(50.0f,50.0f); // スワイプ最小移動距離
      [SerializeField] private int NoneCountMax = 2; // TAPをNONEに戻すまでのカウント
      private int NoneCountNow = 0;
      [SerializeField] private float swipeSpeed = 0.002f; //スワイプのスピード
      [SerializeField] private float flickTime = 0.5f; //フリックでの自動回転が止まるまでの時間
      private Vector2 SwipeRange; // スワイプ入力距離
      private Vector2 InputSTART; // 入力方向記録用
      private Vector2 InputMOVE;
      private Vector2 InputEND;
      public enum FlickDirection // フリックの方向
      {
          NONE,
          TAP,
          UP,
          RIGHT,
          DOWN,
          LEFT,
          UP_LEFT,
          UP_RIGHT,
          DOWN_LEFT,
          DOWN_RIGHT
      }
      private FlickDirection NowFlick = FlickDirection.NONE;

      public enum SwipeDirection // スワイプの方向
      {
          NONE,
          TAP,
          UP,
          RIGHT,
          DOWN,
          LEFT,
          UP_LEFT,
          UP_RIGHT,
          DOWN_LEFT,
          DOWN_RIGHT
      }
      private SwipeDirection NowSwipe = SwipeDirection.NONE;


      void Awake()
      {
          movingSpeed = PlayerPrefs.GetFloat("Value_of_MovingSpeed", 20f);
      }

      void Start()
      {
          swidth = Screen.width; sheight = Screen.height;
          float aspect = sheight / swidth; magni = Mathf.Min(1.4f/aspect,1f);

          float xCenterCoordi = (xLength - 1f)/2f;
          float yCenterCoordi = (yLength - 1f)/2f;
          float zCenterCoordi = (zLength - 1f)/2f;
          center = new Vector3(xCenterCoordi,yCenterCoordi,zCenterCoordi); //中心位置の定義

          mainCameraTransform = this.gameObject.transform;
          if(yLength == 4){ mainCameraTransform.position = new Vector3 (xCenterCoordi, yCenterCoordi, zCenterCoordi - 7.2f); }
          if(yLength == 6){ mainCameraTransform.position = new Vector3 (xCenterCoordi, yCenterCoordi, zCenterCoordi - 8.4f); }
          defaultPosition = mainCameraTransform.position;

          squaredDistance = (defaultPosition.x - center.x) * (defaultPosition.x - center.x) + (defaultPosition.y - center.y) * (defaultPosition.y - center.y) + (defaultPosition.z - center.z) * (defaultPosition.z - center.z);
          upLimit = center.y + Mathf.Sqrt(squaredDistance) - 0.5f;
          downLimit = center.y - Mathf.Sqrt(squaredDistance) + 0.5f;

          mainCameraTransform.LookAt(center,Vector3.up);
      }

      void Update()
      {
          if(swidth <= sheight){ GetInputVector(); }
      }

      void LateUpdate()
      {
          if(swidth > sheight){ CameraPosotionControlPC(); }
          if(swidth <= sheight){ CameraPosotionControlMobile(); }
      }


      private void CameraPosotionControlPC() //PCの矢印キーでメインカメラを動かす
      {
        Vector3 pos = mainCameraTransform.position;
        if(Input.GetKey(KeyCode.RightArrow)){ mainCameraTransform.position = CulPosRight(pos,Time.deltaTime); }
        if(Input.GetKey(KeyCode.LeftArrow)){ mainCameraTransform.position = CulPosLeft(pos,Time.deltaTime); }
        if(Input.GetKey(KeyCode.UpArrow)){ mainCameraTransform.position = CulPosUp(pos,Time.deltaTime); }
        if(Input.GetKey(KeyCode.DownArrow)){ mainCameraTransform.position = CulPosDown(pos,Time.deltaTime); }
        mainCameraTransform.LookAt(center,Vector3.up);
      }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      private void CameraPosotionControlMobile() //携帯端末のタッチパネルで矢印キーでメインカメラを動かす
      {
        Vector3 pos = mainCameraTransform.position;
        float _work;

        switch (GetNowSwipe())
        {
          case SwipeDirection.TAP:
          flickFlug = false; NowFlick = FlickDirection.NONE;
          break;

          case SwipeDirection.UP:
          _work = GetSwipeRange() * Time.deltaTime * swipeSpeed;
          mainCameraTransform.position = CulPosDown(pos,_work);
          break;

          case SwipeDirection.RIGHT:
          _work = GetSwipeRange() * Time.deltaTime * swipeSpeed;
          mainCameraTransform.position = CulPosLeft(pos,_work);
          break;

          case SwipeDirection.DOWN:
          _work = GetSwipeRange() * Time.deltaTime * swipeSpeed;
          mainCameraTransform.position = CulPosUp(pos,_work);
          break;

          case SwipeDirection.LEFT:
          _work = GetSwipeRange() * Time.deltaTime * swipeSpeed;
          mainCameraTransform.position = CulPosRight(pos,_work);
          break;

          case SwipeDirection.UP_LEFT:
          _work = GetSwipeRange() * Time.deltaTime * swipeSpeed;
          mainCameraTransform.position = CulPosRight(CulPosDown(pos,_work/Mathf.Sqrt(2)),_work/Mathf.Sqrt(2));
          break;

          case SwipeDirection.UP_RIGHT:
          _work = GetSwipeRange() * Time.deltaTime * swipeSpeed;
          mainCameraTransform.position = CulPosLeft(CulPosDown(pos,_work/Mathf.Sqrt(2)),_work/Mathf.Sqrt(2));
          break;

          case SwipeDirection.DOWN_LEFT:
          _work = GetSwipeRange() * Time.deltaTime * swipeSpeed;
          mainCameraTransform.position = CulPosRight(CulPosUp(pos,_work/Mathf.Sqrt(2)),_work/Mathf.Sqrt(2));
          break;

          case SwipeDirection.DOWN_RIGHT:
          _work = GetSwipeRange() * Time.deltaTime * swipeSpeed;
          mainCameraTransform.position = CulPosLeft(CulPosUp(pos,_work/Mathf.Sqrt(2)),_work/Mathf.Sqrt(2));
          break;
        }

        if(NowFlick != FlickDirection.NONE){ flickFlug = true; }

        if(flickFlug)
        {
          switch (GetNowFlick())
          {
            case FlickDirection.UP:
            _work = flickSpeed * Time.deltaTime * 0.002f;
            mainCameraTransform.position = CulPosDown(pos,_work);
            flickSpeed = Mathf.Max(flickSpeed-flickSpeedFirst*Time.deltaTime/flickTime,0f);
            if(flickSpeed == 0f){ flickFlug = false; NowFlick = FlickDirection.NONE; } //Debug.Log(NowFlick + " " + flickSpeed);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            break;

            case FlickDirection.RIGHT:
            _work = flickSpeed * Time.deltaTime * 0.002f;
            mainCameraTransform.position = CulPosLeft(pos,_work);
            flickSpeed = Mathf.Max(flickSpeed-flickSpeedFirst*Time.deltaTime/flickTime,0f);
            if(flickSpeed == 0f){ flickFlug = false; NowFlick = FlickDirection.NONE; } //Debug.Log(NowFlick + " " + flickSpeed);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            break;

            case FlickDirection.DOWN:
            _work = flickSpeed * Time.deltaTime * 0.002f;
            mainCameraTransform.position = CulPosUp(pos,_work);
            flickSpeed = Mathf.Max(flickSpeed-flickSpeedFirst*Time.deltaTime/flickTime,0f);
            if(flickSpeed == 0f){ flickFlug = false; NowFlick = FlickDirection.NONE; } //Debug.Log(NowFlick + " " + flickSpeed);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            break;

            case FlickDirection.LEFT:
            _work = flickSpeed * Time.deltaTime * 0.002f;
            mainCameraTransform.position = CulPosRight(pos,_work);
            flickSpeed = Mathf.Max(flickSpeed-flickSpeedFirst*Time.deltaTime/flickTime,0f);
            if(flickSpeed == 0f){ flickFlug = false; NowFlick = FlickDirection.NONE; } //Debug.Log(NowFlick + " " + flickSpeed);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            break;

            case FlickDirection.UP_LEFT:
            _work = flickSpeed * Time.deltaTime * 0.002f;
            mainCameraTransform.position = CulPosRight(CulPosDown(pos,_work/Mathf.Sqrt(2)),_work/Mathf.Sqrt(2));
            flickSpeed = Mathf.Max(flickSpeed-flickSpeedFirst*Time.deltaTime/flickTime,0f);
            if(flickSpeed == 0f){ flickFlug = false; NowFlick = FlickDirection.NONE; } //Debug.Log(NowFlick + " " + flickSpeed);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            break;

            case FlickDirection.UP_RIGHT:
            _work = flickSpeed * Time.deltaTime * 0.002f;
            mainCameraTransform.position = CulPosLeft(CulPosDown(pos,_work/Mathf.Sqrt(2)),_work/Mathf.Sqrt(2));
            flickSpeed = Mathf.Max(flickSpeed-flickSpeedFirst*Time.deltaTime/flickTime,0f);
            if(flickSpeed == 0f){ flickFlug = false; NowFlick = FlickDirection.NONE; } //Debug.Log(NowFlick + " " + flickSpeed);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            break;

            case FlickDirection.DOWN_LEFT:
            _work = flickSpeed * Time.deltaTime * 0.002f;
            mainCameraTransform.position = CulPosRight(CulPosUp(pos,_work/Mathf.Sqrt(2)),_work/Mathf.Sqrt(2));
            flickSpeed = Mathf.Max(flickSpeed-flickSpeedFirst*Time.deltaTime/flickTime,0f);
            if(flickSpeed == 0f){ flickFlug = false; NowFlick = FlickDirection.NONE; } //Debug.Log(NowFlick + " " + flickSpeed);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            break;

            case FlickDirection.DOWN_RIGHT:
            _work = flickSpeed * Time.deltaTime * 0.002f;
            mainCameraTransform.position = CulPosLeft(CulPosUp(pos,_work/Mathf.Sqrt(2)),_work/Mathf.Sqrt(2));
            flickSpeed = Mathf.Max(flickSpeed-flickSpeedFirst*Time.deltaTime/flickTime,0f);
            if(flickSpeed == 0f){ flickFlug = false; NowFlick = FlickDirection.NONE; } //Debug.Log(NowFlick + " " + flickSpeed);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            break;
          }
        }

        mainCameraTransform.LookAt(center,Vector3.up);
      }

      private void GetInputVector() // 入力の取得
      {
          if (Application.isEditor && game.CameraDetectable) // Unity上での操作取得
          {
              if (Input.GetMouseButtonDown(0))
              {
                InputSTART = Input.mousePosition; //Debug.Log("InputStart : " + Input.mousePosition); ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
              }
              else if (Input.GetMouseButton(0))
              {
                if(InputSTART.y >= 0.12f*magni*sheight && InputSTART.y <= (1f-0.27f*magni)*sheight)
                {
                  InputMOVE = Input.mousePosition; //Debug.Log("InputMOVE : " + Input.mousePosition); ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                  SwipeCLC();
                }
              }
              else if (Input.GetMouseButtonUp(0))
              {
                if(InputSTART.y >= 0.12f*magni*sheight && InputSTART.y <= (1f-0.27f*magni)*sheight)
                {
                  InputEND = Input.mousePosition; //Debug.Log("InputEND : " + Input.mousePosition); ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                  FlickCLC();
                }
              }
              else if(NowFlick != FlickDirection.NONE || NowSwipe != SwipeDirection.NONE)
              {
                  ResetParameter();
              }
          }
          else // 端末上での操作取得
          {
              if (Input.touchCount > 0 && game.CameraDetectable)
              {
                  Touch touch = Input.touches[0];
                  if (touch.phase == TouchPhase.Began)
                  {
                    InputSTART = touch.position;
                  }
                  else if (touch.phase == TouchPhase.Moved)
                  {
                    if(InputSTART.y >= 0.12f*magni*sheight && InputSTART.y <= (1f-0.27f*magni)*sheight)
                    {
                      InputMOVE = touch.position;
                      SwipeCLC();
                    }
                  }
                  else if (touch.phase == TouchPhase.Ended)
                  {
                    if(InputSTART.y >= 0.12f*magni*sheight && InputSTART.y <= (1f-0.27f*magni)*sheight)
                    {
                      InputEND = touch.position;
                      FlickCLC();
                    }
                  }
              }
              else if (NowFlick != FlickDirection.NONE || NowSwipe != SwipeDirection.NONE)
              {
                  ResetParameter();
              }
          }
      }

      private void FlickCLC() // 入力内容からフリック方向を計算
      {
          Vector2 _work = new Vector2((new Vector3(InputEND.x, 0, 0) - new Vector3(InputMOVE.x, 0, 0)).magnitude, (new Vector3(0, InputEND.y, 0) - new Vector3(0, InputMOVE.y, 0)).magnitude);

          if (_work.x <= FlickMinRange.x && _work.y <= FlickMinRange.y)
          {
              NowFlick = FlickDirection.TAP;
          }
          else
          {
              float _angle = Mathf.Atan2(InputEND.y - InputMOVE.y, InputEND.x - InputMOVE.x) * Mathf.Rad2Deg;

              if (-22.5f <= _angle && _angle < 22.5f) NowFlick = FlickDirection.RIGHT;
              else if (22.5f <= _angle && _angle < 67.5f) NowFlick = FlickDirection.UP_RIGHT;
              else if (67.5f <= _angle && _angle < 112.5f) NowFlick = FlickDirection.UP;
              else if (112.5f <= _angle && _angle < 157.5f) NowFlick = FlickDirection.UP_LEFT;
              else if (157.5f <= _angle || _angle < -157.5f) NowFlick = FlickDirection.LEFT;
              else if (-157.5f <= _angle && _angle < -112.5f) NowFlick = FlickDirection.DOWN_LEFT;
              else if (-112.5f <= _angle && _angle < -67.5f) NowFlick = FlickDirection.DOWN;
              else if (-67.5f <= _angle && _angle < -22.5f) NowFlick = FlickDirection.DOWN_RIGHT;
          }

          if (SwipeRange.x > SwipeRange.y){ flickSpeedFirst = SwipeRange.x; flickSpeed = SwipeRange.x; }
          else{ flickSpeedFirst = SwipeRange.y; flickSpeed = SwipeRange.y; }
      }

      private void SwipeCLC() // 入力内容からスワイプ方向を計算
      {
          SwipeRange = new Vector2((new Vector3(InputMOVE.x, 0, 0) - new Vector3(InputSTART.x, 0, 0)).magnitude, (new Vector3(0, InputMOVE.y, 0) - new Vector3(0, InputSTART.y, 0)).magnitude);

          if (SwipeRange.x <= SwipeMinRange.x && SwipeRange.y <= SwipeMinRange.y)
          {
              NowSwipe = SwipeDirection.TAP;
          }
          else
          {
              float _angle = Mathf.Atan2(InputMOVE.y - InputSTART.y, InputMOVE.x - InputSTART.x) * Mathf.Rad2Deg;

              if(-22.5f <= _angle && _angle < 22.5f) NowSwipe = SwipeDirection.RIGHT;
              else if(22.5f <= _angle && _angle < 67.5f) NowSwipe = SwipeDirection.UP_RIGHT;
              else if (67.5f <= _angle && _angle < 112.5f) NowSwipe = SwipeDirection.UP;
              else if (112.5f <= _angle && _angle < 157.5f) NowSwipe = SwipeDirection.UP_LEFT;
              else if (157.5f <= _angle || _angle < -157.5f) NowSwipe = SwipeDirection.LEFT;
              else if (-157.5f <= _angle && _angle < -112.5f) NowSwipe = SwipeDirection.DOWN_LEFT;
              else if (-112.5f <= _angle && _angle < -67.5f) NowSwipe = SwipeDirection.DOWN;
              else if (-67.5f <= _angle && _angle < -22.5f) NowSwipe = SwipeDirection.DOWN_RIGHT;
          }
      }

      private void ResetParameter() // NONEにリセット
      {
          NoneCountNow++;
          if (NoneCountNow >= NoneCountMax)
          {
              NoneCountNow = 0;
              NowSwipe = SwipeDirection.NONE;
              SwipeRange = new Vector2(0, 0);
          }
      }

      public FlickDirection GetNowFlick() // フリック方向の取得
      {
          return NowFlick;
      }

      public SwipeDirection GetNowSwipe() // スワイプ方向の取得
      {
          return NowSwipe;
      }

      public float GetSwipeRange() // スワイプ量の取得
      {
          if (SwipeRange.x > SwipeRange.y){ return SwipeRange.x; }
          else{ return SwipeRange.y; }
      }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      private Vector3 CulPosDown(Vector3 pos, float _work) //上方向へ動かした時の行き先の座標を計算
      {
        float r; float rxy; float d; float y; float con; float x; float z; Vector3 newPos = new Vector3(0,0,0);
        r = Mathf.Sqrt(squaredDistance);
        rxy = Mathf.Sqrt(squaredDistance-(pos.y-center.y)*(pos.y-center.y));
        d = _work * movingSpeed;
        y = center.y + (pos.y-center.y) * Mathf.Cos(d/r) - rxy * Mathf.Sin(d/r);
        if(y < downLimit){ return pos; }
        con = Mathf.Sqrt((squaredDistance-(y-center.y)*(y-center.y))/(squaredDistance-(pos.y-center.y)*(pos.y-center.y)));
        x = center.x + con * (pos.x-center.x);
        z = center.z + con * (pos.z-center.z);
        newPos = new Vector3 (x,y,z);
        return newPos;
      }

      private Vector3 CulPosUp(Vector3 pos, float _work) //下方向へ動かした時の行き先の座標を計算
      {
        float r; float rxy; float d; float y; float con; float x; float z; Vector3 newPos = new Vector3(0,0,0);
        r = Mathf.Sqrt(squaredDistance);
        rxy = Mathf.Sqrt(squaredDistance-(pos.y-center.y)*(pos.y-center.y));
        d = _work * movingSpeed;
        y = center.y + (pos.y-center.y) * Mathf.Cos(d/r) + rxy * Mathf.Sin(d/r);
        if(y > upLimit){ return pos; }
        con = Mathf.Sqrt((squaredDistance-(y-center.y)*(y-center.y))/(squaredDistance-(pos.y-center.y)*(pos.y-center.y)));
        x = center.x + con * (pos.x-center.x);
        z = center.z + con * (pos.z-center.z);
        newPos = new Vector3 (x,y,z);
        return newPos;
      }

      private Vector3 CulPosRight(Vector3 pos, float _work) //左方向へ動かした時の行き先の座標を計算
      {
        float r; float d; float x; float z; Vector3 newPos = new Vector3(0,0,0);
        r = Mathf.Sqrt(squaredDistance-(pos.y-center.y)*(pos.y-center.y));
        d = _work * movingSpeed;
        x = center.x + (pos.x-center.x) * Mathf.Cos(d/r) - (pos.z-center.z) * Mathf.Sin(d/r);
        z = center.z + (pos.z-center.z) * Mathf.Cos(d/r) + (pos.x-center.x) * Mathf.Sin(d/r);
        newPos = new Vector3 (x,pos.y,z);
        return newPos;
      }

      private Vector3 CulPosLeft(Vector3 pos, float _work) //右方向へ動かした時の行き先の座標を計算
      {
        float r; float d; float x; float z; Vector3 newPos = new Vector3(0,0,0);
        r = Mathf.Sqrt(squaredDistance-(pos.y-center.y)*(pos.y-center.y));
        d = _work * movingSpeed;
        x = center.x + (pos.x-center.x) * Mathf.Cos(d/r) + (pos.z-center.z) * Mathf.Sin(d/r);
        z = center.z + (pos.z-center.z) * Mathf.Cos(d/r) - (pos.x-center.x) * Mathf.Sin(d/r);
        newPos = new Vector3 (x,pos.y,z);
        return newPos;
      }

      public Vector3 MainCameraTransformPosition {get {return this.mainCameraTransform.position;} }

      public float MovingSpeed {get {return this.movingSpeed;} set {this.movingSpeed = value;}}
  }

}
