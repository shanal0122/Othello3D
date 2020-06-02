using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choose
{
  public class BGMManager : MonoBehaviour
  {
      public static BGMManager instance;

      void Awake()
      {
          if(instance == null)
          {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
          }else{ Destroy(this.gameObject); }

      }
  }
}
