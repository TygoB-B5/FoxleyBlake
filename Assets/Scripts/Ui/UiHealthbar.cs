using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UiHealthbar : MonoBehaviour
{
    private Slider healthBar;

    private void Awake()
    {
        healthBar = GetComponent<Slider>();
        if (!FindObjectOfType<PlayerHealth>())
        {
            Debug.LogError("PlayerHealth component could not be found in scene");
            GetComponent<UiHealthbar>().enabled = false;
        }
    }

    private void Update()
    {
        healthBar.value = FindObjectOfType<PlayerHealth>().health;
    }
}
