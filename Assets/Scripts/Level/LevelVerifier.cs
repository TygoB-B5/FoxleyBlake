using UnityEngine;

public class LevelVerifier : MonoBehaviour
{
    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnSceneChange;
    }

    private void OnSceneChange(UnityEngine.SceneManagement.Scene a, UnityEngine.SceneManagement.Scene b)
    {
        //verify if scene has End object
        if (!FindObjectOfType<LevelEnd>())
            Debug.LogWarning("Unable to find Level End Component in scene");

        //verify if scene has Start object
        if (!FindObjectOfType<LevelStart>())
            Debug.LogWarning("Unable to find Level Start Component in scene");

        //verify if player gameobject exists
        if (!GameObject.FindGameObjectWithTag("Player"))
            Debug.LogError("Player Object could not be found, does it have the 'Player' tag?");

        //verify if camera gameobject exists
        if (!GameObject.FindGameObjectWithTag("Camera"))
            Debug.LogError("Camera Object could not be found, does it have the 'Camera' tag?");
    }
}
