using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTextFloat : MonoBehaviour
{

    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    Vector3 tempPos;
    [SerializeField] float timeToMove;
    [SerializeField] private float percentToCompletion = 0;
    [SerializeField] float smallPauseTime;
    [SerializeField] bool transitionBack;


    private void Start()
    {
        percentToCompletion = 0;
    }
    private void Update()
    {
        if (GetPosition() != pointB)
        {
            percentToCompletion += Time.deltaTime / timeToMove;
            this.gameObject.transform.position = MoveFromAToB(pointA, pointB, percentToCompletion);
        }
        else if (transitionBack)
        {
            StartCoroutine(SmallPause());
        }
    }

    public void FlipPointAandB()
    {
        if (GetPosition() == pointB)
        {
            Vector3 tempPoint = pointB;
            pointB = pointA;
            pointA = tempPoint;
            percentToCompletion = 0;
        }
    }

    private Vector3 GetPosition()
    {
        return this.transform.position;
    }


    public Vector3 MoveFromAToB(Vector3 pointA, Vector3 pointB, float timeDelta)
    {
        tempPos = Vector3.Lerp(pointA, pointB, timeDelta);
        return tempPos;
    }

    IEnumerator SmallPause()
    {
        yield return new WaitForSeconds(smallPauseTime);
        FlipPointAandB();
    }
}
