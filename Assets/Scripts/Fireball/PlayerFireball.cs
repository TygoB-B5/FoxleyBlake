using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject fireball;
    private float timer;

    const int manaUse = 25;
    const float reloadTime = 0.5f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (playerInput.Red && timer > reloadTime)
        {
            if(GetComponent<PlayerMana>().mana >= manaUse)
            {
                timer = 0;
                ShootFireball();
            }
        }
    }

    private void ShootFireball()
    {
        if (GetComponent<PlayerAnimation>())
            GetComponent<PlayerAnimation>().FireballShot();
        else
            Debug.LogWarning("Could not find PlayerAnimation component");

        GetComponent<PlayerMana>().RemoveMana(manaUse);
        GetComponent<PlayerSound>().PlaySound("FireballLaunch", Random.Range(0.7f, 1.0f));

        Instantiate(fireball, transform.position + transform.right * 0.5f, transform.rotation);
    }
}
