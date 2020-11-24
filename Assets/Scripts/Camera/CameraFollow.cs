using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform trackingObject = default;
    [SerializeField] private Vector3 offset = default;
    private CameraClamp camClamp;
    private float yPos;
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        if (FindObjectOfType<CameraClamp>())
            camClamp = GetComponent<CameraClamp>();
        else
            Debug.LogWarning("Can't find CameraClamp component");

        yPos = cam.transform.position.y;
    }

    private void LateUpdate()
    {
        SetCameraPos();
    }

    private void SetCameraPos()
    {
        float clampedX = Mathf.Clamp(trackingObject.transform.position.x, camClamp.GetXClampValues().x, camClamp.GetXClampValues().y);
        Vector3 pos = new Vector3(clampedX, yPos, 0);
        cam.transform.position = Vector3.Lerp(cam.transform.position, pos - offset, 6 * Time.deltaTime);
    }


    public Vector3 GetOffset()
    {
        return offset - new Vector3(0, yPos, 0);
    }
}
