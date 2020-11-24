using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        if (GetComponent<Animator>())
            anim = GetComponent<Animator>();
        else
            Debug.LogWarning("No Animator component found on player");

        if (!GetComponent<PlayerJump>())
                Debug.LogWarning("No PlayerJump component found on player");
    }

    private void Update()
    {
        if (GetComponent<PlayerJump>().isGrounded)
        {
            anim.SetBool("isJumping", false);
            TestGroundAnimations();
        } else
        {
            isJumping();
        }
    }

    private void isJumping()
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isJumping", true);
    }

    private void TestGroundAnimations()
    {
        if (playerInput.Horizontal != 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
    }


    public void VentIn()
    {
        anim.SetTrigger("VentIn");
    }

    public void VentOut()
    {
        anim.SetTrigger("VentOut");
    }

    public void FireballShot()
    {
        anim.SetTrigger("ShootFireball");
    }
}
