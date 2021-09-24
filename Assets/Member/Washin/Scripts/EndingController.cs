using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    [SerializeField] GameObject floatingFolderPrefab;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;


    void Start()
    {
        GameObject tempFolder = Instantiate(floatingFolderPrefab,this.transform);
        EndingFolderMoveToPosition tempMoveFolder = tempFolder.GetComponent<EndingFolderMoveToPosition>();
        tempFolder.transform.position = pointA.position;
        tempMoveFolder.pointA = pointA;
        tempMoveFolder.pointB = pointB;
    }

}
