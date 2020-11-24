using UnityEngine;

[RequireComponent(typeof(EnemyEngine))]
public class GuardAnimation : MonoBehaviour
{
    private EnemyEngine enemyEngine;
    private Animator anim;

    private void Awake()
    {
        enemyEngine = GetComponent<EnemyEngine>();

        if (GetComponent<Animator>())
            anim = GetComponent<Animator>();
        else
            Debug.LogWarning("Animator component not found on enemy object");

    }
    private void Update()
    {
        if (enemyEngine.enemySpeed < 0.1f)
            anim.SetBool("isShooting", true);
        else
            anim.SetBool("isShooting", false);
    }
}
