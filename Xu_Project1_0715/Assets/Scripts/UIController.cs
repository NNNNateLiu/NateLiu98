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
        
        //如果切换到表演场景，则让currentSceneIndex与实际可游玩场景保持一致
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            currentSceneIndex = 0;
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            currentSceneIndex = 5;
        }

        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            currentSceneIndex = 4;
        }

        
        scenesOnMinimap[currentSceneIndex].GetComponent<Image>().sprite = atHereSprite;
        Txt_Location.text = scenesOnMinimap[currentSceneIndex].name;
    }
    
    public void OnEnterMinimapPosition(GameObject clickedMinimapPosition)
    {
        clickedMinimapPosition.GetComponent<Image>().color = new Color(0.56f, 0.9f, 1, 1);
        Txt_Location.text = clickedMinimapPosition.name;
    }
    
    public void OnExitMinimapPosition(GameObject clickedMinimapPosition)
    {
        clickedMinimapPosition.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        Txt_Location.text = scenesOnMinimap[currentSceneIndex].name;
    }
}
