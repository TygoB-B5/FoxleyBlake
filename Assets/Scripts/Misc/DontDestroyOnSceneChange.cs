using UnityEngine;

public class DontDestroyOnSceneChange : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<DontDestroyOnSceneChange>().Length > 1)
            Destroy(gameObject, 0);
    }
}
