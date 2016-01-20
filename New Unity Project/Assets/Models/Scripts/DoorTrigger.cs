using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

    bool triggeredBefore = false;

	void OnTriggerExit(Collider c)
    {
        if (!triggeredBefore)
        {
            Debug.Log("Door Closing!");
            triggeredBefore = true;
        }
        else
        {
            Debug.Log("Door closed before");
        }
    }
}
