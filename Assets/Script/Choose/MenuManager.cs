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
      public GameObject bgmDropdown;
      public BGMManager bgmManager;

      void Awake()
      {
        audioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        bgmVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Value_of_BGMVolume", 0.5f) * 10f;
        bgmDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Value_of_BGM", 0);
        bgmDropdown.GetComponent<Dropdown>().onValueChanged.AddListener(OnBGMGhange);
      }

      public void OnBGMVolumeSlide() //BGMの音量のスライダーの値を取得
      {
        audioSource.volume = bgmVolumeSlider.GetComponent<Slider>().value / 10;
        PlayerPrefs.SetFloat("Value_of_BGMVolume", audioSource.volume);
        PlayerPrefs.Save();
      }

      public void OnBGMGhange(int value) //BGMの変更を取得
      {
         int audio = bgmDropdown.GetComponent<Dropdown>().value;
         bgmManager.SelectAudio(audio);
         Invoke("AudioPlay", 0.5f);
         PlayerPrefs.SetInt("Value_of_BGM", audio);
         PlayerPrefs.Save();
      }

      private void AudioPlay()
      {
        audioSource.Play();
      }
  }
}
