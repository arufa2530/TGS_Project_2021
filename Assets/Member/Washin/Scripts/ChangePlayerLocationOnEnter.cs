using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerLocationOnEnter : MonoBehaviour
{
    [SerializeField] bool useDefaultPosition;
    [SerializeField] Vector3 targetStartPosition;
    Vector3 playerDefaultPosition = new Vector3(257, -160, -1);

    private void Start()
    {
        if (useDefaultPosition || targetStartPosition == Vector3.zero)
            PlayerReferences.playerMovement.SetPlayerPosition(playerDefaultPosition);
        else
            PlayerReferences.playerMovement.SetPlayerPosition(targetStartPosition);

        Cursor.lockState = CursorLockMode.Confined;
    }
}
