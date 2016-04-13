using UnityEngine;
using System.Collections;

public class DoorOpenClose : MonoBehaviour {

	public bool isLocked = true;
	public bool rotateClockwise = true;
    public float activateDistance = 2.0f;
	//public float turnDegrees = 90.0f;
	public float moveSpeed = 1.0f;
    public AudioClip lockedSound;
    [HideInInspector]
	public bool isOpen = false;
    [HideInInspector]
    public bool isRotating = false;
    public AudioClip angryLockedSound;
    public bool lockTimer;
    public float lockTime;
    private bool counting = false;
    private float currentTime = 0f;
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
        if (counting)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                isLocked = false;
                counting = false;
            }
        }
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
        Vector3 cameraPos = Camera.main.transform.position;
        float dxSquare = Mathf.Pow(cameraPos.x - transform.position.x, 2);
        float dySquare = Mathf.Pow(cameraPos.y - transform.position.y, 2);
        float dzSquare = Mathf.Pow(cameraPos.z - transform.position.z, 2);
        if (Mathf.Pow(activateDistance, 2) < (dxSquare + dySquare + dzSquare))
        {
            return;
        }

		if (isLocked)
        {
            if (currentTime > 0f)
            {
                PlaySound ps = gameObject.AddComponent<PlaySound>();
                ps.soundClip = angryLockedSound;
                ps.whenToEnd = PlaySound.PlayEnd.endOfClip;
                StartCoroutine(ps.StartClip(-1));
                ps.whenToStart = PlaySound.PlayStart.never;
                return;
            }
            else if (gameObject.tag.Equals("OnClickDoor"))
            {
                currentTime = lockTime;
                counting = true;
                return;
            }
            else {
                PlaySound ps = gameObject.AddComponent<PlaySound>();
                ps.soundClip = lockedSound;
                ps.whenToEnd = PlaySound.PlayEnd.endOfClip;
                StartCoroutine(ps.StartClip(-1));
                ps.whenToStart = PlaySound.PlayStart.never;
                return;
            }
        }

        if (isRotating)
			return;

		isRotating = true;


	}
}
