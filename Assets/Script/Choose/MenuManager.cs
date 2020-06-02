using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Choose
{
  public class MenuManager : MonoBehaviour
  {
      private AudioSource audioSource;
      public GameObject bgmVolumeSlider;

      void Awake()
      {
        audioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        bgmVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Value_of_BGMVolume", 0.5f) * 10f;
      }

      public void OnBGMVolumeSlide() //BGMの音量のスライダーの値を取得
      {
        audioSource.volume = bgmVolumeSlider.GetComponent<Slider>().value / 10;
        PlayerPrefs.SetFloat("Value_of_BGMVolume", audioSource.volume);
        PlayerPrefs.Save();
      }
  }
}
