using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public void Die()
    {
        ResetStats();
        Scene.Load(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    private void ResetStats()
    {
        FindObjectOfType<PlayerMana>().ResetMana();
        FindObjectOfType<PlayerHealth>().ResetHealth();

        EnablePlayer();
    }

    private void EnablePlayer(bool enabled = true)
    {
        GameObject player = FindObjectOfType<PlayerEngine>().gameObject;
        player.GetComponent<SpriteRenderer>().enabled = enabled;
        player.GetComponent<PlayerEngine>().enabled = enabled;
        player.GetComponent<PlayerInput>().enabled = enabled;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody>().useGravity = enabled;
        player.GetComponent<Collider>().enabled = enabled;
    }
}
