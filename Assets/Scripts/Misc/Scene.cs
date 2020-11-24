using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene : MonoBehaviour
{
    static public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }

    static public void Load(int number)
    {
        SceneManager.LoadScene(number);
    }

    static public int CurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
