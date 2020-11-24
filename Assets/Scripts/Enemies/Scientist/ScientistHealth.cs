using UnityEngine;

public class ScientistHealth : MonoBehaviour
{
    private float health = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            health--;

            if(health <= 0)
                Destroy(gameObject, 0);
        }
    }
}
