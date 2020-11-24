using UnityEngine;
using System.Collections;

public class PlayerStepSound : MonoBehaviour
{
    private PlayerJump playerJump;
    private PlayerInput playerInput;
    [SerializeField] private float stepFrequency = default;

    private void Awake()
    {
        playerJump = GetComponent<PlayerJump>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        StartCoroutine(StepSpeed());
    }

    private IEnumerator StepSpeed()
    {
        while (true)
        {
            if (playerInput.Horizontal != 0 && playerJump.isGrounded)
            {
                GetComponent<PlayerSound>().PlaySound("Step", Random.Range(0.7f, 1f));
            }

            yield return new WaitForSeconds(Mathf.Abs(stepFrequency * playerInput.Horizontal));
        }
    }
}
