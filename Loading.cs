using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Loading : MonoBehaviour
{
    public Slider slider;

    AsyncOperation async;

    public void LoadScene()
    {
        StartCoroutine(LoadingScreen());
    }

    public void Start()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        async = SceneManager.LoadSceneAsync(2);
        async.allowSceneActivation = false;
        
        while (async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
 }



