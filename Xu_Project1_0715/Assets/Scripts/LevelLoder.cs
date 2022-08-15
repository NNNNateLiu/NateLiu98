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
            alpha -= Time.deltaTime;
            blackimage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            blackimage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
