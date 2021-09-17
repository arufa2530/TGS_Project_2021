using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchJitter : MonoBehaviour
{
    Vector3 startPos;
    void Update()
    {
        transform.position = new Vector2(Random.Range(-5, 5) + startPos.x, Random.Range(-5, 5) + startPos.y);
    }

    public void SetNewStartingPos()
    {
        startPos = transform.position;
    }
}
