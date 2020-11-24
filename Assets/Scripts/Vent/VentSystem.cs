using System.Collections;
using UnityEngine;

[ExecuteAlways]
public class VentSystem : MonoBehaviour
{
    private Transform[] vents;
    private bool isDoneTeleporting, isVenting = false;
    private Transform player;
    private int toVent = default;

    private void Awake()
    {
        vents = GetComponentsInChildren<Transform>();
    }

    public void EnterVent(GameObject enteredVent)
    {
        player = FindObjectOfType<PlayerEngine>().transform;

        if (enteredVent.transform == vents[1])
            StartCoroutine(Vent(2));
        else if (enteredVent.transform == vents[2])
            StartCoroutine(Vent(1));
    }

    private IEnumerator Vent(int toVent)
    {
        this.toVent = toVent;
        isDoneTeleporting = false;

        if (FindObjectOfType<PlayerSound>())
            FindObjectOfType<PlayerSound>().PlaySound("Vent");
        else
            Debug.LogWarning("PlayerSound script not found in scene");

        if (FindObjectOfType<PlayerAnimation>())
            FindObjectOfType<PlayerAnimation>().VentIn();
        else
            Debug.LogWarning("PlayerAnimation script not found in scene");

        yield return new WaitForSecondsRealtime(0.25f);

        isVenting = true;
        EnablePlayer(false);

        yield return new WaitUntil(() => isDoneTeleporting == true);

        EnablePlayer(true);

        FindObjectOfType<PlayerSound>().PlaySound("Vent", 0.8f);

        if (FindObjectOfType<PlayerAnimation>())
            FindObjectOfType<PlayerAnimation>().VentOut();

        isVenting = false;

    }

    private void Update()
    {
        DebugLines();

        if (!Application.isPlaying)
            return;

        MovePlayerToVent();
    }

    private void DebugLines()
    {
        Debug.DrawLine(transform.position, vents[1].transform.position, Color.yellow);
        Debug.DrawLine(transform.position, vents[2].transform.position, Color.yellow);
    }

    private void MovePlayerToVent()
    {
        if (!isVenting)
            return;

        //if venting go to vent
        if (isVenting)
            player.transform.position = Vector3.Lerp(player.transform.position, vents[toVent].transform.position, 5 * Time.deltaTime);

        //if arrived at other vent
        if (Vector3.Distance(player.transform.position, vents[toVent].transform.position) < 0.25f)
            isDoneTeleporting = true;
    }

    private void EnablePlayer(bool enabled)
    {
        player.GetComponent<SpriteRenderer>().enabled = enabled;
        player.GetComponent<PlayerEngine>().enabled = enabled;
        player.GetComponent<PlayerInput>().enabled = enabled;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody>().useGravity = enabled;
        player.GetComponent<Collider>().enabled = enabled;
    }
}
