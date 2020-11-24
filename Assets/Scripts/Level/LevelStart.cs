using UnityEngine;

public class LevelStart : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        if (FindObjectOfType<AnimationFade>())
            FindObjectOfType<AnimationFade>().FadeIn();
        else
            Debug.LogWarning("No AnimationFade animation object found in scene");

        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = transform.position;

        //set camera position to player position - offset
        if (FindObjectOfType<CameraFollow>())
        {
            Vector3 cameraOffset = FindObjectOfType<CameraFollow>().GetOffset();
            GameObject.FindGameObjectWithTag("Camera").transform.position = transform.position - cameraOffset - new Vector3(-8.5f, 0, 0);
        }
        else
            Debug.LogWarning("Camera Follow script not found");

        EnablePlayer(true);
    }

    private void EnablePlayer(bool enabled)
    {
        player.GetComponent<PlayerEngine>().enabled = enabled;
        player.GetComponent<PlayerInput>().enabled = enabled;
    }
}
