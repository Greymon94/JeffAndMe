using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour 
{

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void NewGame()
    {
        Application.LoadLevel(1);
    }
    public void LoadGame()
    {
        Debug.Log("Not Yet Implemented");
    }
    public void Credits()
    {
        Application.LoadLevel("Credits");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
