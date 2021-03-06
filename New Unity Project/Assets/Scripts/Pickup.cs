﻿using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public bool isHeld = false;
    public float activateDistance = 1;
    public Vector3 rotationAdjust;
    public Vector3 relativePositionToPlayer = new Vector3(0, -1, 2);

    public AudioClip[] playOnPickup;
    public PlaySound.PlayEnd[] howToEnd;

    void OnMouseUpAsButton()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        float dxSquare = Mathf.Pow(cameraPos.x - transform.position.x, 2);
        float dySquare = Mathf.Pow(cameraPos.y - transform.position.y, 2);
        float dzSquare = Mathf.Pow(cameraPos.z - transform.position.z, 2);
        if (Mathf.Pow(activateDistance, 2) > (dxSquare + dySquare + dzSquare))
        {
            bool pickedUp = true;
            switch (gameObject.tag)
            {
                case "Flashlight":
                    //pick up here
                    if (PlayerInventory.hasFlashlight)
                        return;
                    Debug.Log("Pick Up Flashlight");
                    //Transform playerTrans = GameManager.Instance.Player.transform;
                    transform.SetParent(Camera.main.transform);
                    transform.localRotation = Quaternion.Euler(rotationAdjust);
                    transform.localPosition = relativePositionToPlayer;
                    isHeld = true;
                    PlayerInventory.flashlightAddress = gameObject;
                    PlayerInventory.hasFlashlight = true;
                    if (PlayerInventory.batteryCount < 2)
                    {
                        GetComponent<Flashlight>().FlickerStart(false);
                    }
                    else
                    {
                        GetComponent<Flashlight>().FlickerStart(true);
                    }
                    Collider[] cols = GetComponents<Collider>();
                    foreach (Collider c in cols)
                    {
                        Destroy(c);
                    }
                    break;
                case "Battery":
                    if (!PlayerInventory.hasFlashlight)
                        return;
                    Debug.Log("Pick Up Battery");
                    PlayerInventory.batteryCount++;
                    if (PlayerInventory.batteryCount >= 2)
                    {
                        Debug.Log("Got 2 batteries!");
                        Flashlight fl = PlayerInventory.flashlightAddress.GetComponent<Flashlight>();
                        fl.FlickerStart(true);
                        FlashlightMusic();
                        
                    }
                    else
                    {
                        Debug.Log("Need one more battery");
                    }
                    Debug.Log("GOT HERE MOTHER FUCKER");
                    gameObject.SetActive(false);
                    Debug.Log("FUCKING GONE");
                    break;
                default:
                    pickedUp = false;
                    return;
            }

            if (pickedUp && playOnPickup != null && !gameObject.tag.Equals("Flashlight"))
            {
                foreach (AudioClip ac in playOnPickup)
                {
                    PlaySound ps = gameObject.AddComponent<PlaySound>();
                    ps.soundClip = ac;
                    ps.whenToEnd = PlaySound.PlayEnd.endOfClip;
                    StartCoroutine(ps.StartClip(-1));
                    ps.whenToStart = PlaySound.PlayStart.never;
                }
            }
        }
    }

    public void FlashlightMusic()
    {
        GameManager.Instance.Player.GetComponent<AudioSource>().Stop();
        Pickup flPickup = PlayerInventory.flashlightAddress.GetComponent<Pickup>();
        foreach (AudioClip ac in flPickup.playOnPickup)
        {
            PlaySound ps = GameManager.Instance.Player.AddComponent<PlaySound>();
            ps.soundClip = ac;
            ps.whenToEnd = PlaySound.PlayEnd.endOfClip;
            StartCoroutine(ps.StartClip(-1));
            ps.whenToStart = PlaySound.PlayStart.never;
        }
    }
}