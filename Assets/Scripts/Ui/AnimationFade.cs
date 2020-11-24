using System.Net;
using UnityEngine;

public class AnimationFade : MonoBehaviour
{
    private Animator anim;
    private AudioSource[] aud;
    private bool isLowering, isActive;
    private float t;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        aud = FindObjectsOfType<AudioSource>();
        t = 0;
    }
    private void Update()
    {
        SetTimer();
    }

    private void SetTimer()
    {
        if (!isActive)
            return;

        if (isLowering)
            t -= 1 * Time.deltaTime;
        else
            t += 1 * Time.deltaTime;

        for (int i = 0; i < aud.Length; i++)
                aud[i].volume = t;

        if (t > 1)
            isActive = false;
    }

    public void FadeOut()
    {
        isActive = true;
        isLowering = true;

        anim.Play("FadeOut");
    }

    public void FadeIn()
    {
        isActive = true;
        isLowering = false;

        anim.Play("FadeIn");
    }
}
