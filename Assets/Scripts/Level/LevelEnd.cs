using UnityEngine;
using System.Collections;


public class LevelEnd : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < 2)
        {
            EnablePlayer(false);
            StartCoroutine(EndLevel());
        }
    }

    private void EnablePlayer(bool enabled)
    {
        player.GetComponent<PlayerEngine>().enabled = enabled;
        player.GetComponent<PlayerInput>().enabled = enabled;
    }

    private IEnumerator EndLevel()
    {
        if (FindObjectOfType<AnimationFade>())
            FindObjectOfType<AnimationFade>().FadeOut();
        else
            Debug.LogWarning("No AnimationFade animation object found in scene");

        yield return new WaitForSeconds(1);
        FindObjectOfType<LevelHandler>().LoadNext();
    }
}
