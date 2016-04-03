using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{
    public Pickup pickupScript;

    Light flashlight;
    float maxBrightness;

    bool isFlickering = false;
    const int flickerCount = 6;
    int curFlickerCount = 0;
    bool flickerStartOn = true;
    bool flickerEndOn = true;
    const float flickerTimer = 0.5f;
    float curFlickerTimer = 0;

    const float flickerDelay = 3;
    float curFlickerDelay = 0;
 
    bool isOn
    {
        get
        {
            if (flashlight.intensity == 0)
            {
                Debug.Log("Flashlight is OFF");
                return false;
            }
            Debug.Log("Flashlight is ON");
            return true;
        }
    }

    // Use this for initialization
    void Start()
    {
        flashlight = gameObject.GetComponentInChildren<Light>();

        maxBrightness = flashlight.intensity;

        pickupScript = GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
/*****FLICKER TEST CODE******
        if (isFlickering)
        {
            Flicker();
        }
        else
        {
            curFlickerDelay += Time.deltaTime;
            if (curFlickerDelay > flickerDelay)
            {
                Debug.Log("FLICKER START");
                curFlickerDelay = 0;
                FlickerStart(true);
            }
        }
//*/
        if (Input.GetMouseButtonUp(1) && pickupScript.isHeld)
        {
            Debug.Log("Right mouse released");
            TogglePower();
        }
    }

    public void PowerSwitch(bool turnOn)
    {
        if (turnOn)
        {
            flashlight.intensity = maxBrightness;
            return;
        }
        flashlight.intensity = 0;
    }

    public void TogglePower()
    {
        PowerSwitch(!isOn);
    }

    public void FlickerStart(bool willEndOn)
    {
        flickerStartOn = isOn;

        flickerEndOn = willEndOn;
        curFlickerCount = 0;
        isFlickering = true;
    }

    public void Flicker()
    {
        curFlickerTimer += Time.deltaTime;
        if (curFlickerTimer > flickerTimer)
        {
            curFlickerTimer -= flickerTimer;
            TogglePower();
            curFlickerCount++;
        }

        if (curFlickerCount >= flickerCount)
        {
            if (isOn == flickerEndOn)
            {
                isFlickering = false;
                Debug.Log("FLICKER END");
            }
            else
                curFlickerCount--;
        }
    }
}