using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]

public class PlaySound : MonoBehaviour 
{
    public AudioClip soundClip;
    AudioSource myAudio;

    public enum PlayStart {onEnter, onExit};
    public PlayStart whenToStart;

    public enum PlayEnd { endOfClip, onEnter, onExit, onTimer };
    public PlayEnd whenToEnd;

    public float optionalTimer;

	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = soundClip;
        GetComponent<Collider>().isTrigger = true;
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
            StartClip(optionalTimer, other);
        }
        else if (whenToEnd == PlayEnd.onEnter)
        {
            StopClip();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            Debug.Log("Collided with not player");
            return;
        }

        if (whenToStart == PlayStart.onExit)
        {
            StartClip(optionalTimer, other);
        }
        else if (whenToEnd == PlayEnd.onExit)
        {
            StopClip();
        }
    }

    IEnumerator StartClip(float timer, Collider c)
    {
        /*
        myAudio = null;
        foreach (AudioSource a in c.GetComponents<AudioSource>())
        {
            if (!a.isPlaying)
            {
                myAudio = a;
                break;
            }
        }
        if (myAudio == null)
        {
            myAudio = c.gameObject.AddComponent<AudioSource>();
        }
        myAudio.clip = soundClip;
        //*/
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
