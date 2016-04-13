using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    void OnTriggerEnter()
    {
        Application.LoadLevel("MainMenu");
    }
}
