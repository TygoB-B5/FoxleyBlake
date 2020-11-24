using UnityEngine;

public class EnemyEngine : MonoBehaviour
{
    public float walkSpeed;

    private float enemySpeed_;
    public float enemySpeed
    {
        get { return enemySpeed_; }
        set { enemySpeed_ = Mathf.Clamp(value, 0, walkSpeed); }
    }

    private void Start()
    {
        enemySpeed = walkSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
    }

    public void ChangeDirection(int rotation)
    {
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
