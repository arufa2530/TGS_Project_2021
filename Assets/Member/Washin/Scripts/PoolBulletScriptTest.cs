using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBulletScriptTest : MonoBehaviour
{
    Vector3 moveDown = new Vector3(0,-0.5f,0);

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDown;
    }
}
