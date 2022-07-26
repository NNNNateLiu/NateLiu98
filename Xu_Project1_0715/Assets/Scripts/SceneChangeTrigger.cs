using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChangeTrigger : MonoBehaviour
{
    public GameObject SceneChangeTrigger_Flowchart;

    public void ChangeScene(string SceneName,int SceneEnterPointPositionsIndex)
    {
        PlayerController_test.instance.isInConversation = false;
        PlayerController_test.instance.SceneEnterPointPositionTogoIndex = SceneEnterPointPositionsIndex;
        
        SceneManager.LoadScene(SceneName);
    }
}
