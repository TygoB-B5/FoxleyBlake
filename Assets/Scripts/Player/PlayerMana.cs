using UnityEngine;
using System.Collections;

public class PlayerMana : MonoBehaviour
{
    public float mana { get; private set; }
    private float newMana = Mathf.Infinity;
    private float timer;
    [SerializeField] private float manaLoseTime = default;
    [SerializeField]private float manaRegenTime = default;
    [SerializeField]private float autoRegenWaitTime = default;

    private void Start()
    {
        ResetMana();
    }

    public void ResetMana()
    {
        mana = 100;
        RemoveMana(0);
    }

    private void Update()
    {
        //lose mana
        if (newMana <= mana)
            mana -= manaLoseTime * Time.deltaTime;

        //regain mana
        if (timer > autoRegenWaitTime && mana < 100)
        {
            newMana = 100;
            mana += manaRegenTime * Time.deltaTime;

            if (mana >= 100)
                timer = 0;
        }

        timer += Time.deltaTime;
    }

    public void RemoveMana(int mana)
    {
        newMana = this.mana - mana;
        timer = 0;
    }
}
