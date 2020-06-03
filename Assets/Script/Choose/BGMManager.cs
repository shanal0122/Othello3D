using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choose
{
  public class BGMManager : MonoBehaviour
  {
      public static BGMManager instance;
      public AudioClip audioClip1;
      public AudioClip audioClip2;
      public AudioClip audioClip3;
      private AudioSource audioSource;

      void Awake()
      {
          audioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();

          if(instance == null)
          {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            int audio = PlayerPrefs.GetInt("Value_of_BGM", 0);
            SelectAudio(audio);
            audioSource.Play();

          }else{ Destroy(this.gameObject); }
      }

      public void SelectAudio(int audio)
      {
        if(audio == 0){ audioSource.clip = audioClip1; }
        else if(audio == 1){ audioSource.clip = audioClip2; }
        else if(audio == 2){ audioSource.clip = audioClip3; }
        else{ Debug.Log("Error : BGMManager/Awake"); } /////////////////////////////////////////////////////////////////////////////////////////////
      }
  }
}
