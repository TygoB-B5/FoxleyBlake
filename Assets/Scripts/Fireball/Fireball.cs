using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float s = 0;
    private float t = 4;
    private void Start()
    {
        Destroy(gameObject, 0.75f);
    }

    private void Update()
    {
        s += 15 * Time.deltaTime;
        transform.Translate(Vector3.right * (12.5f + s) * Time.deltaTime);

        t -= 3 * Time.deltaTime;
        transform.localScale = new Vector3(t, t, 0.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
            Destroy(gameObject, 0);
    }
}
