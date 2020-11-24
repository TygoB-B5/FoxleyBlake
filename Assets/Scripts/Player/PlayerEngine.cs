using UnityEngine;

public class PlayerEngine : MonoBehaviour
{
    private PlayerInput playerInput;
    private float actualSpeed;
    [SerializeField] private float playerSpeed = default;
    [SerializeField] private float airSpeed = default;
    

    private void Awake()
    {
        actualSpeed = playerSpeed;

        if (GetComponent<PlayerInput>())
            playerInput = GetComponent<PlayerInput>();
        else
            Debug.LogError("PlayerInput Component not found");

        if (!GetComponent<PlayerJump>())
            Debug.LogWarning("PlayerJump Component not found");
    }

    private void Update()
    {
        Rotation();
        AirCheck();
        Move();
    }

    private void Rotation()
    {
        //checks for rotation
        if (playerInput.Horizontal > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (playerInput.Horizontal < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void AirCheck()
    {
        //checks if player is in the air
        if (GetComponent<PlayerJump>())
            if (GetComponent<PlayerJump>().isGrounded)
                actualSpeed = playerSpeed;
            else
                actualSpeed = airSpeed;
    }

    private void Move()
    {
        //moves the player
        if (playerInput.Horizontal != 0)
            transform.Translate(Vector3.right * actualSpeed * Mathf.Abs(playerInput.Horizontal) * Time.deltaTime);
    }
}
