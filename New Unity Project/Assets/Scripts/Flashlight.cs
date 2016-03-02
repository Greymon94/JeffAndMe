using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    Light flashlight;

	// Use this for initialization
	void Start () {
        flashlight = gameObject.GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
