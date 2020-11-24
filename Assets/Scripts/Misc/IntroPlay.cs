using System.Collections;
using UnityEngine;

public class IntroPlay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {   
        double videoLength = GetComponent<UnityEngine.Video.VideoPlayer>().clip.length;
        Debug.Log("Intro length = " + videoLength.ToString() + " seconds");
        yield return new WaitForSecondsRealtime((float)videoLength);
        EndIntro();
    }

    public void EndIntro()
    {
        Scene.Load(3);
    }
}
