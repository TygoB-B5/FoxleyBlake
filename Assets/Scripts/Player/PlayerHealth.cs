using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public float health { get; private set; }
    private float newHealth = Mathf.Infinity;
    [SerializeField] private float healthLoseTime = default;

    public event Action OnDie = delegate { };

    private void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        health = 100;
        RemoveHealth(0);
    }

    private void Update()
    {
        if (newHealth <= health)
            health -= healthLoseTime * Time.deltaTime;

        if (health < 0)
            if (GetComponent<PlayerDie>())
                GetComponent<PlayerDie>().Die();
            else
                Debug.LogWarning("PlayerDie component not found on player");
    }

    public void RemoveHealth(int health)
    {
        newHealth = this.health - health;
    }
}
