using UnityEngine;
using System.Collections;

public class ExitEnterTrigger : MonoBehaviour {

    public enum TriggerType {Enter,Exit, Enable, Disable, Other};
    public TriggerType trigger;
    public DoorOpenClose targDoor;
    public bool endResult;
    public GameObject enableDisableTarg;

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

        if(TriggerType.Disable == trigger)
        {
            enableDisableTarg.SetActive(false);
            return;
        }

        if(TriggerType.Enable == trigger)
        {
            enableDisableTarg.SetActive(true);
            return;
        }

        if (trigger == TriggerType.Enter && targDoor.isLocked != endResult)
        {
            Debug.Log("Starting lock");
            targDoor.isLocked = !targDoor.isLocked;

            if (targDoor.isOpen)
            {
                Debug.Log("Closing door");
                targDoor.isRotating = true;
            }
        }
    }


}
