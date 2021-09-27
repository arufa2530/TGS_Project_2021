using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDespawnWindowScript : MonoBehaviour
{
    [SerializeField]
    private float timeLeft;
    private float timeUntilDespawn = 1.5f;
    private void Start()
    {
        timeLeft = timeUntilDespawn;
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime / timeUntilDespawn;
        if (timeLeft <= 0)
            Destroy(this.gameObject);
    }
}
