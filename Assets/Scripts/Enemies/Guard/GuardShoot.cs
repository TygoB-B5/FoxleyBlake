using System.Collections;
using UnityEngine;

public class GuardShoot : MonoBehaviour
{
    private Transform player;
    private EnemyEngine enemyEngine;
    public GameObject bullet;
    private bool isShooting = false;

    private void Awake()
    {
        enemyEngine = GetComponent<EnemyEngine>();
        player = FindObjectOfType<PlayerEngine>().transform;
    }

    private void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        RaycastHit hit;

        Vector3 relativePos = player.position - transform.position;

        Debug.DrawRay(transform.position + transform.right * 0.5f, relativePos, Color.cyan , Time.deltaTime);

        if (Physics.Raycast(transform.position + transform.right * 0.5f, relativePos, out hit, 14))
        {
            if (hit.transform.tag == "Player")
            {
                enemyEngine.enemySpeed = 0;
                SetDirection();

                if (!isShooting)
                    StartCoroutine(Shoot(relativePos));
            }
            else
                enemyEngine.enemySpeed = enemyEngine.walkSpeed;
        }
        else
            enemyEngine.enemySpeed = enemyEngine.walkSpeed;
    }

    private void SetDirection()
    {
        if (player.transform.position.x < transform.position.x)
            enemyEngine.ChangeDirection(180);
        else
            enemyEngine.ChangeDirection(0);
    }

    private IEnumerator Shoot(Vector3 relativePos)
    {
        isShooting = true;

        //set shoot angle
        float rot_z = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;

        //instantitae bullet
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rot_z));

        yield return new WaitForSeconds(0.6f);
        isShooting = false;

        yield return null;
    }
}
