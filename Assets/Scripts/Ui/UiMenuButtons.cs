using UnityEngine;
using System.Collections;

public class UiMenuButtons : MonoBehaviour
{
    private void Start()
    {
        if (FindObjectOfType<AnimationFade>())
            FindObjectOfType<AnimationFade>().FadeIn();
        else
            Debug.LogWarning("No AnimationFade animation object found in scene");
    }

    public void StartGame()
    {
        StartCoroutine(LoadWithDelay(2));
    }

    public void Exit()
    {
        StartCoroutine(ExitWithDelay());
    }

    private IEnumerator LoadWithDelay(int number)
    {
        if (FindObjectOfType<AnimationFade>())
            FindObjectOfType<AnimationFade>().FadeOut();
        else
            Debug.LogWarning("No AnimationFade animation object found in scene");

        yield return new WaitForSecondsRealtime(1);
        Scene.Load(number);
    }

    private IEnumerator ExitWithDelay()
    {
        if (FindObjectOfType<AnimationFade>())
            FindObjectOfType<AnimationFade>().FadeOut();
        else
            Debug.LogWarning("No AnimationFade animation object found in scene");

        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
    }
}
