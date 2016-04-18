using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    void OnTriggerEnter()
    {
        Cursor.lockState = CursorLockMode.None;
        Application.LoadLevel("MainMenu");
    }
}
