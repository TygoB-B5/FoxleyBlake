using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.Translate(-Vector3.left * 25 * Time.deltaTime);

        TestHit();
    }

    private void TestHit()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.right, Color.green, 0.2f);

        if (Physics.Raycast(transform.position, transform.right, out hit, 0.2f))
        {
            if (hit.transform.gameObject.GetComponent<PlayerEngine>())
            {
                Hit();
            }
            else
                Destroy(gameObject, 0);
        }
    }

    private void Hit()
    {
        Destroy(gameObject, 0);
        FindObjectOfType<PlayerHealth>().RemoveHealth(23);
    }
}
