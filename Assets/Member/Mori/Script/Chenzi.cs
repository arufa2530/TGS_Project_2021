using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chenzi : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { SceneManager.LoadScene("MenuScene"); }
        if (Input.GetKeyDown(KeyCode.S)) { SceneManager.LoadScene("Test_Alpha"); }
        if (Input.GetKeyDown(KeyCode.D)) { SceneManager.LoadScene("DesktopScene"); }
        if (Input.GetKeyDown(KeyCode.W)) { SceneManager.LoadScene("PaintTestScene"); }
        if (Input.GetKeyDown(KeyCode.B)) { SceneManager.LoadScene("BulletTesting(debug)"); }
        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene("GameOverScreen"); }
        if (Input.GetKeyDown(KeyCode.T)) { SceneManager.LoadScene("Solitia"); }
        
    }
}
