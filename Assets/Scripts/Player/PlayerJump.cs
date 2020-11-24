using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rb;
    public bool isGrounded { get; private set; }
    private bool isTiming;
    private float jumpCharge;
    private float timer;

    [SerializeField]private float maxUpForce = default;
    [SerializeField]private float jumpVelocityBuildup = default;
    [SerializeField]private float startUpForce = default;
    [SerializeField]private float maxJumpTime = default;

    private void Awake()
    {
        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
        else
            Debug.LogWarning("No Rigidbody Component found on object");

        if (GetComponent<PlayerInput>())
            playerInput = GetComponent<PlayerInput>();
        else
            Debug.LogError("no PlayerInput Component found on object");
    }

    private void Update()
    {
        if(isTiming)
            timer += Time.deltaTime;

        if (playerInput.GreenHold && timer < maxJumpTime)
        {
            isTiming = true;

            Jump();

            if (!isGrounded)
                return;

            jumpCharge += jumpVelocityBuildup * Time.deltaTime;
            jumpCharge = Mathf.Clamp(jumpCharge, 0, maxUpForce);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(0, startUpForce + jumpCharge, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            ResetCharge();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

            if(isTiming) GetComponent<PlayerSound>().PlaySound("Jump", Random.Range(1f, 1.1f));
        }
    }

    private void ResetCharge()
    {
        jumpCharge = 0;
        isTiming = false;
        timer = 0;
    }
}
