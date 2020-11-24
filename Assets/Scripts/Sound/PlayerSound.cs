using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource aud;

    private void Awake()
    {
        while(!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
            aud = GetComponent<AudioSource>();
            
    }
    public void PlaySound(string name, float pitch = 1, float volume = 1)
    {
        aud.pitch = pitch;
        aud.volume = volume;
        if (Resources.Load<AudioClip>("sounds/" + name))
            aud.PlayOneShot(Resources.Load<AudioClip>("sounds/" + name));
        else
            Debug.LogWarning("Soundfile \"" + name + "\" not found");

    }
}
