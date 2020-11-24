using UnityEngine;

public class Wave : MonoBehaviour
{
    private float t;
    [SerializeField] private float waveLength = default;
    [SerializeField] private float waveSpeed = default;

    private void Update()
    {
        t += waveSpeed * Time.deltaTime;
        if (t > Mathf.PI * 2)
            t -= Mathf.PI * 2;

        transform.position += transform.up * Mathf.Sin(t) * waveLength;
    }
}
