using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    private float health = 2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            health--;

            if (health <= 0)
                Destroy(gameObject, 0);
        }
    }
}
