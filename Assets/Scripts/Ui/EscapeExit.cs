using System.Collections;
using UnityEngine;

public class EscapeExit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine(ExitWithDelay());
    }

    private IEnumerator ExitWithDelay()
    {
        if (FindObjectOfType<AnimationFade>())
            FindObjectOfType<AnimationFade>().FadeOut();
        else
            Debug.LogWarning("No AnimationFade animation object found in scene");

        yield return new WaitForSecondsRealtime(1f);

        if (FindObjectOfType<PlayerEngine>())
        {
            Destroy(FindObjectOfType<DontDestroyOnSceneChange>().gameObject, 0);
            Scene.Load("Menu");
        }
        else
            Application.Quit();
    }
}
