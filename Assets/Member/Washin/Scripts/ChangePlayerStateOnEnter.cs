using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerStateOnEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerReferences.playerMovement.ChangePlayerMode(PlayerMovement.PlayerModes.MovementMode);
    }
    
}
