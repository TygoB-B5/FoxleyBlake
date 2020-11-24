using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            AudioSource[] a = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < a.Length; i++)
                if (a[i].gameObject.tag != "Player") a[i].Stop();

            Scene.Load("EasterEgg");
        }
    }
}
