using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private float time = 0f;
    private float updTime = 0f;
    private AsyncOperation async;
    public Text text;
    public Slider slider;


    IEnumerator Start()
    {
      yield return new WaitForSeconds(1);
      async = SceneManager.LoadSceneAsync("Choose");
      async.allowSceneActivation = false;

      while (async.progress < 0.9f)
      {
          slider.value = async.progress;
          yield return 0;
      }
      slider.value = 1.0f;
      async.allowSceneActivation = true;

      yield return async;
    }

    void Update()
    {
      updTime = time + Time.deltaTime;
      if(Mathf.Floor(2*time) < Mathf.Floor(2*updTime)){ LoadingText(Mathf.Floor(2*updTime)); }
      time = updTime;
    }

    private void LoadingText(float time)
    {
      if(time % 4 == 0){ text.text = ""; }
      if(time % 4 == 1){ text.text = "."; }
      if(time % 4 == 2){ text.text = ". ."; }
      if(time % 4 == 3){ text.text = ". . ."; }
    }
/*
    void Update()
    {
        updTime = time + Time.deltaTime;
        if(Mathf.Floor(time) < Mathf.Floor(updTime)){ LoadingText(Mathf.Floor(updTime)); }
        time = updTime;

        StartCoroutine("LoadData");
    }

    private void LoadingText(float time)
    {
      if(time % 4 == 0){ text.text = ""; }
      if(time % 4 == 1){ text.text = "."; }
      if(time % 4 == 2){ text.text = ". ."; }
      if(time % 4 == 3){ text.text = ". . ."; }
    }

    IEnumerator LoadData()
    {
      async = SceneManager.LoadSceneAsync("Tutorial");
      Debug.Log(!async.isDone);

		  while(!async.isDone)
      {
			  var progressVal = Mathf.Clamp01(async.progress / 0.9f);
        Debug.Log(async.progress);
			  slider.value = progressVal;
			  yield return null;
      }
    }*/
}
