using UnityEngine;
using System.Collections;

public class DoorOpenClose : MonoBehaviour {

	public bool isLocked = true;
	public bool rotateClockwise = true;
	//public float turnDegrees = 90.0f;
	public float moveSpeed = 1.0f;

	bool isOpen = false;
	bool isRotating = false;

	Quaternion closedRot, openRot;

	// Use this for initialization
	void Start () {
		closedRot = transform.rotation;

		int rotDir = 1;
		if (!rotateClockwise)
			rotDir = -1;

        
        openRot.SetLookRotation(new Vector3(rotDir * Mathf.PI / 2, 0, 1));
	}
	
	// Update is called once per frame
	void Update () {
		if (isRotating) {
			if (isOpen)
			{
				transform.rotation = Quaternion.LerpUnclamped(transform.rotation, 
				                                     closedRot, 
				                                     Time.deltaTime * moveSpeed);
			}
			else
			{
				transform.rotation = Quaternion.LerpUnclamped(transform.rotation, 
				                                     openRot, 
				                                     Time.deltaTime * moveSpeed);
			}

			if (openRot == transform.rotation || closedRot == transform.rotation)
			{
				isOpen = !isOpen;
				isRotating = false;
			}
		}
	}

	void OnMouseUpAsButton()
	{
		Debug.Log ("Door Clicked");
		if (isLocked || isRotating)
			return;

		isRotating = true;


	}
}
