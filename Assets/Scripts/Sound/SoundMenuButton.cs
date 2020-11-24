using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenuButton : MonoBehaviour
{
    private AudioSource aud;
    [SerializeField]private AudioClip hoverOverButton = default;
    [SerializeField]private AudioClip clickButton = default;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    public void Hover()
    {
        aud.PlayOneShot(hoverOverButton);
    }

    public void ClickButton()
    {
        aud.PlayOneShot(clickButton);
    }
}
