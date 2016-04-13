using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]

public class PlaySound : MonoBehaviour 
{
    public AudioClip soundClip;
    AudioSource myAudio;

    public enum PlayStart { onEnter, onExit, never };
    public PlayStart whenToStart;

    public enum PlayEnd { endOfClip, onEnter, onExit, onTimer, never };
    public PlayEnd whenToEnd;

    public float optionalLength = -1;

	// Use this for initialization
	void Start () {
        myAudio = gameObject.AddComponent<AudioSource>();
        myAudio.clip = soundClip;
        //GetComponent<Collider>().isTrigger = true;
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTERED");
        if (other.tag != "Player")
        {
            Debug.Log("Collided with not player");
            return;
        }

        if (whenToStart == PlayStart.onEnter)
        {
            Debug.Log("starting audio");
            //other.GetComponent<AudioSource>().PlayOneShot(soundClip);
            StartCoroutine(StartClip(optionalLength));
        }
        else if (whenToEnd == PlayEnd.onEnter)
        {
            StopClip();
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exiting collider");
        if (other.tag != "Player")
        {
            Debug.Log("Collided with not player");
            return;
        }

        if (whenToStart == PlayStart.onExit)
        {
            Debug.Log("Starting audio");
            StartCoroutine(StartClip(optionalLength));
        }
        else if (whenToEnd == PlayEnd.onExit)
        {
            StopClip();
        }
    }

    public IEnumerator StartClip(float timer)
    {
        if (myAudio == null)
            myAudio = gameObject.AddComponent<AudioSource>();
        if (myAudio.clip == null)
            myAudio.clip = soundClip;
        Debug.Log("Starting clip: " + myAudio.clip.name);
        myAudio.Stop();
        myAudio.Play();
        if (timer > 0)
        {
            yield return new WaitForSeconds(timer);
            myAudio.Stop();
        }
    }

    void StopClip()
    {
        myAudio.Stop();
    }
}
