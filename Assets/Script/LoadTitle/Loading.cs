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

    void Start()
    {

    }

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
      async = SceneManager.LoadSceneAsync("Title");

		  while(!async.isDone)
      {
			  var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			  slider.value = progressVal;
			  yield return null;
      }
    }
}
