using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
 
    
    private static GameManager _instance;
    public static GameManager Instance
    {
        set
        {
            _instance = value;
        }
        get
        {
            if (!_instance)
                new GameObject().AddComponent<GameManager>();
            return _instance;
        }
    }

    private GameObject _player;
    public GameObject Player
    {
        set
        {
            _player = value;
        }
        get
        {
            if (!_player)
                _player = GameObject.FindGameObjectWithTag("Player");
            return _player;
        }
    }

 	// Use this for initialization
 	void Start () {
		if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            Cursor.lockState = CursorLockMode.Locked;
        }
 	}
 	
 	// Update is called once per frame
 	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}