using UnityEngine;

public class DebugScenes : MonoBehaviour
{
    private void Update()
    {
        Debug.LogWarning("Debugging Object in Scene");
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            FindObjectOfType<LevelHandler>().LoadNext();
        }
    }
}
