using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public bool Red { get; private set; } 
    public bool Blue { get; private set; }
    public bool Yellow { get; private set; }
    public bool Green { get; private set; }
    public bool GreenHold { get; private set; }
    public bool White { get; private set; }
    public bool Orange { get; private set; }
    public bool Escape { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Red = Input.GetKeyDown(KeyCode.R);
        Blue = Input.GetKeyDown(KeyCode.LeftShift);
        Yellow = Input.GetKeyDown(KeyCode.F);
        Green = Input.GetKeyDown(KeyCode.Space);
        GreenHold = Input.GetKey(KeyCode.Space);
        White = Input.GetKeyDown(KeyCode.LeftControl);
        Orange = Input.GetKeyDown(KeyCode.E);
    }
}
