using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToWindow : MonoBehaviour
{
    [SerializeField] DragWindow dragWindow;

    private void Start()
    {
        dragWindow = GetComponent<DragWindow>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        dragWindow.SetCanDrag(false);
        //DontDestroyOnLoad(this.gameObject);
        //collision.transform.SetParent(this.transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        dragWindow.SetCanDrag(true);
        //collision.transform.SetParent(null);
    }

}
