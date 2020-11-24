using UnityEngine;

public class PlayerVent : MonoBehaviour
{
    private PlayerInput playerInput;

    const int manaUse = 45;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput.White)
            if (GetComponent<PlayerMana>().mana >= manaUse)
                SmokeVent();
    }

    private void SmokeVent()
    {
        GameObject nearestVent = NearestVent();

        if (Vector3.Distance(transform.position, nearestVent.transform.position) < 3)
        {
            nearestVent.GetComponentInParent<VentSystem>().EnterVent(nearestVent);
            FindObjectOfType<PlayerMana>().RemoveMana(manaUse);
        }
            
    }

    private GameObject NearestVent()
    {
        GameObject[] vents = GameObject.FindGameObjectsWithTag("Vent");
        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach(GameObject vent in vents)
        {
            float singleVentDistance = Vector3.Distance(transform.position, vent.transform.position);
            if (singleVentDistance < distance)
            {
                nearest = vent;
                distance = singleVentDistance;
            }
            else
                continue;
        }
        return nearest;
    }
}
