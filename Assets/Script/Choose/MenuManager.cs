using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Choose
{
  public class MenuManager : MonoBehaviour
  {
      private AudioSource audioSource;
      public GameObject bgmVolumeSlider;
      public GameObject bgmDropdown;
      public BGMManager bgmManager;
      public GameObject playerTurnDropdown;
      public GameObject levelDropdown;

      void Awake()
      {
        audioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        bgmVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Value_of_BGMVolume", 0.5f) * 10f;
        bgmDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Value_of_BGM", 0);
        playerTurnDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Value_of_PlayerTurn", 0);
        levelDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Value_of_CPULevel", 0);
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

      public void OnPlayerTurnSelect() //CPU戦における手番を選択
      {
        int turnValue = playerTurnDropdown.GetComponent<Dropdown>().value;
        if(turnValue == 0)
        {
          InitialSetting.playerTurn = 1;
        }
        if(turnValue == 1)
        {
          InitialSetting.playerTurn = -1;
        }
        PlayerPrefs.SetInt("Value_of_PlayerTurn", turnValue);
        PlayerPrefs.Save();
      }

      public void OnLevelSelect() //CPU戦における手番を選択
      {
        int levelValue = levelDropdown.GetComponent<Dropdown>().value;
        if(levelValue == 0)
        {
          InitialSetting.cpuLevel = 1;
        }
        if(levelValue == 1)
        {
          InitialSetting.cpuLevel = 2;
        }
        if(levelValue == 2)
        {
          InitialSetting.cpuLevel = 3;
        }
        PlayerPrefs.SetInt("Value_of_CPULevel", levelValue);
        PlayerPrefs.Save();
      }

      public void OnTutorialLoad()
      {
        SceneManager.LoadScene("Tutorial");
      }
  }
}
