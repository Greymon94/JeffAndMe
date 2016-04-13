using UnityEngine;
using System.Collections;

public class ExitEnterTrigger : MonoBehaviour {

    public enum TriggerType {Enter,Exit, Other};
    public TriggerType trigger;
    public DoorOpenClose targDoor;
    public bool endResult;

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            Debug.Log("Collided with not player");
            return;            
        }

        if (trigger == TriggerType.Exit && targDoor.isLocked != endResult)
        {
            Debug.Log("Starting audio");
            targDoor.isLocked = !targDoor.isLocked;
            this.enabled = false;
            if (targDoor.isOpen)
                targDoor.isRotating = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Debug.Log("Collided with not player");
            return;
        }

        if (trigger == TriggerType.Enter && targDoor.isLocked != endResult)
        {
            Debug.Log("Starting audio");
            targDoor.isLocked = !targDoor.isLocked;

            if (targDoor.isOpen)
                targDoor.isRotating = true;
        }
    }


}
