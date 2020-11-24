using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UiManabar : MonoBehaviour
{
    private Slider manaBar;

    private void Awake()
    {
        manaBar = GetComponent<Slider>();
        if (!FindObjectOfType<PlayerMana>())
        {
            Debug.LogError("PlayerHealth component could not be found in scene");
            GetComponent<UiHealthbar>().enabled = false;
        }
    }

    private void Update()
    {
        manaBar.value = FindObjectOfType<PlayerMana>().mana;
    }
}
