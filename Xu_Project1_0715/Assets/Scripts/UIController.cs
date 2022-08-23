using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    
    public GameObject Minimap;
    public bool isMinimapOpen;
    public int currentSceneIndex;
    public Text Txt_Location;

    //后面可能会给每一个scene单独产出一套对应的贴图
    public Sprite normalSprite;
    public Sprite atHereSprite;

    //让小地图中代表场景的贴图和其在buildsetting中的index保持一致
    public List<GameObject> scenesOnMinimap;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MinimapSwitch();
        }
    }

    public void MinimapSwitch()
    {
        if (isMinimapOpen)
        {
            isMinimapOpen = false;
            Minimap.SetActive(false);
        }
        else
        {
            isMinimapOpen = true;
            Minimap.SetActive(true);
        }
    }

    public void UpdateMinimapPosition()
    {
        scenesOnMinimap[currentSceneIndex].GetComponent<Image>().sprite = normalSprite;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        scenesOnMinimap[currentSceneIndex].GetComponent<Image>().sprite = atHereSprite;
        Txt_Location.text = scenesOnMinimap[currentSceneIndex].name;
    }
}
