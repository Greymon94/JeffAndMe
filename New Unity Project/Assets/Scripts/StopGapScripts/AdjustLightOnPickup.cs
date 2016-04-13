using UnityEngine;
using System.Collections;

public class AdjustLightOnPickup : MonoBehaviour {
    public float newLightIntensity;
    public Light lightSource;

    void OnDisable()
    {
        if (lightSource != null && PlayerInventory.batteryCount >= 2)
        {
            lightSource.intensity = newLightIntensity;
        }
    }
}
