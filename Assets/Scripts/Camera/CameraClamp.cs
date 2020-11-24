using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    private Vector2 clampXValues;

    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    private void ChangedActiveScene(UnityEngine.SceneManagement.Scene current, UnityEngine.SceneManagement.Scene next)
    {
        GetClampValues();
    }

    private void GetClampValues()
    {
        if (FindObjectOfType<LevelStart>())
            clampXValues.x = FindObjectOfType<LevelStart>().transform.position.x + 9.5f;

        if (FindObjectOfType<LevelEnd>())
            clampXValues.y = FindObjectOfType<LevelEnd>().transform.position.x - 9.5f;
    }

    public Vector2 GetXClampValues()
    {
        return clampXValues;
    }
}
