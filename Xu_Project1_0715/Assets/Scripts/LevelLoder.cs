using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoder : MonoBehaviour
{
    public Image blackimage;
    public Text loading;

    public float alpha;
    public float fadeModifier;
    
    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    
    public void FadeTo(string _sceneName)
    {
        StartCoroutine(FadeOut(_sceneName));
    }
    IEnumerator FadeIn()
    {
        alpha = 1;

        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeModifier;
            blackimage.color = new Color(0, 0, 0, alpha);
            loading.color = new Color(255, 255, 255, alpha);
            //yield return new WaitForSeconds(0f);
            yield return null;
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeModifier;
            blackimage.color = new Color(0, 0, 0, alpha);
            loading.color = new Color(255, 255, 255, alpha);
            yield return null;
        }
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
