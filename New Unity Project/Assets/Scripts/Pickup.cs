using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public float activateDistance = 1;
    public Vector3 rotationAdjust;
    public Vector3 relativePositionToPlayer = new Vector3(0, -1, 2);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUpAsButton()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        float dxSquare = Mathf.Pow(cameraPos.x - transform.position.x, 2);
        float dySquare = Mathf.Pow(cameraPos.y - transform.position.y, 2);
        float dzSquare = Mathf.Pow(cameraPos.z - transform.position.z, 2);
        if (Mathf.Pow(activateDistance, 2) > (dxSquare + dySquare + dzSquare))
        {
            //pick up here
            Debug.Log("Pick Up!");
            //Transform playerTrans = GameManager.Instance.Player.transform;
            transform.SetParent(Camera.main.transform);
            transform.localRotation = Quaternion.Euler(rotationAdjust);
            transform.localPosition = relativePositionToPlayer;
        }
    }
}
