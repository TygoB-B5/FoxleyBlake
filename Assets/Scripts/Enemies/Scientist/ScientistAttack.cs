using System.Collections;
using UnityEngine;

public class ScientistAttack : MonoBehaviour
{
    private Transform player;
    private EnemyEngine enemyEngine;
    private bool isAttacking = false;

    private void Awake()
    {
        enemyEngine = GetComponent<EnemyEngine>();
        player = FindObjectOfType<PlayerEngine>().transform;
    }

    private void Update()
    {
        RaycastHit hit;

        Vector3 relativePos = player.position - transform.position;

        Debug.DrawRay(transform.position + transform.right * 0.5f, relativePos, Color.cyan, Time.deltaTime);

        if (Physics.Raycast(transform.position + transform.right * 0.5f, relativePos, out hit, 14))
        {
            if (hit.transform.tag == "Player")
            {
                if (Vector3.Distance(player.transform.position, transform.position) < 3.5f)
                {
                    if (player.transform.position.x > transform.position.x + 1 || player.transform.position.x < transform.position.x - 1)
                    {
                        SetDirection();
                        enemyEngine.enemySpeed = 0;

                        if (!isAttacking)
                            StartCoroutine(Attack());
                    }
                }
                else
                    enemyEngine.enemySpeed = enemyEngine.walkSpeed;
            }
        }
    }

    private void SetDirection()
    {
        if (player.transform.position.x < transform.position.x)
            enemyEngine.ChangeDirection(180);
        else
            enemyEngine.ChangeDirection(0);
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        if (Vector3.Distance(player.transform.position, transform.position) < 4f)
        {
            Hit();
        }

        yield return new WaitForSeconds(0.5f);
        isAttacking = false;

        yield return null;
    }

    private void Hit()
    {
        if (FindObjectOfType<PlayerHealth>())
            FindObjectOfType<PlayerHealth>().RemoveHealth(45);
        else
            Debug.LogError("PlayerHealth Can not be found in scene");
    }
}
