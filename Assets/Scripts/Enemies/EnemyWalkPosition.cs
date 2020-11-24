using UnityEngine;

enum Direction { Left, Right };

[ExecuteAlways]
public class EnemyWalkPosition : MonoBehaviour
{
    private Transform[] referencePoint;
    private Vector3[] oldPos;
    private float minX, maxX = 0;

    private void Start()
    {
        if (!Application.isPlaying)
            return;

        ///////////////////////////////
        /// Run on application start///
        ///////////////////////////////
        
        //make references
        referencePoint = GetComponentsInChildren<Transform>();

        //set min and max x variables
        minX = referencePoint[1].transform.position.x;
        maxX = referencePoint[2].transform.position.x;

        //unparent referencepoints
        referencePoint[1].parent = null;
        referencePoint[2].parent = null;

        //delete referencepoints
        Destroy(referencePoint[1].gameObject, 0);
        Destroy(referencePoint[2].gameObject, 0);
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            EditMode();
        }
        else
        {
            RunTime();
        }
    }

    private void RunTime()
    {
        //switch
        if (transform.position.x < minX)
            GetComponent<EnemyEngine>().ChangeDirection(0);
        else if (transform.position.x > maxX)
            GetComponent<EnemyEngine>().ChangeDirection(180);

    }

    private void EditMode()
    {
        //set references
        referencePoint = new Transform[2];
        referencePoint = GetComponentsInChildren<Transform>();

        ClampYPoints();
        DisableZAxis();

        //debug line
        Debug.DrawLine(referencePoint[2].transform.position, referencePoint[1].transform.position, Color.red, Time.deltaTime);
    }

    private void ClampYPoints()
    {
        //create oldPos array
        if (oldPos == null)
            oldPos = new Vector3[2];

        if (referencePoint[1].transform.position.y != oldPos[0].y)
        {
            referencePoint[2].transform.position = new Vector3(referencePoint[2].transform.position.x, referencePoint[1].transform.position.y, 0);
        }
        else if (referencePoint[2].transform.position.y != oldPos[1].y)
        {
            referencePoint[1].transform.position = new Vector3(referencePoint[1].transform.position.x, referencePoint[2].transform.position.y, 0);
        }

        oldPos[0] = referencePoint[1].transform.position;
        oldPos[1] = referencePoint[2].transform.position;
    }

    private void DisableZAxis()
    {
        for (int i = 1; i < 2; i++)
        {
            referencePoint[i].transform.position = new Vector3(referencePoint[i].transform.position.x, referencePoint[i].transform.position.y, 0);
        }
    }

}