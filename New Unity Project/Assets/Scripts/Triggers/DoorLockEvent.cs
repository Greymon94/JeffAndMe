using UnityEngine;
using System.Collections;

[RequireComponent (typeof(DoorOpenClose))]

public class DoorLockEvent : BaseEvent {

	DoorOpenClose doorControl;

	// Use this for initialization
	void Awake () {
		doorControl = GetComponent<DoorOpenClose> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void TriggerEvent (bool b)
	{
		//doorControl
	}
}
