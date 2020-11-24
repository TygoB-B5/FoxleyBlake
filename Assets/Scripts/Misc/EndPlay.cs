using System.Collections;
using UnityEngine;

public class EndPlay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Outro());
    }

    IEnumerator Outro()
    {
        double videoLength = GetComponent<UnityEngine.Video.VideoPlayer>().clip.length;
        Debug.Log("Intro length = " + videoLength.ToString() + " seconds");
        yield return new WaitForSecondsRealtime((float)videoLength);
        EndIntro();
    }

    public void EndIntro()
    {
        if(FindObjectOfType<DontDestroyOnSceneChange>())
            Destroy(FindObjectOfType<DontDestroyOnSceneChange>().gameObject, 0);

        Scene.Load("Menu");
    }
}
