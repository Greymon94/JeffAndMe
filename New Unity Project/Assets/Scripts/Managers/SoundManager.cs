using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    /*
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        set
        {
            _instance = value;
        }
        get
        {
            if (!_instance)
                new GameObject().AddComponent<SoundManager>();
            return _instance;
        }
    }

    public List<AudioClip> audioClips = new List<AudioClip>();

    private Dictionary<string, AudioClip> clipDict = new Dictionary<string,AudioClip>;

    private List<AudioSource> playing;

    void Start()
    {
        foreach(AudioClip a in audioClips)
        {
            clipDict.Add(a.name, a);
        }
    }

    public bool PlaySoundOnce(string name, AudioSource soundSource, float volume)
    {
        if (clipDict.Count == 0 || !clipDict.ContainsKey(name))
            return false;

        soundSource.PlayOneShot(clipDict[name], volume);
        return true;
    }
    //*/
}
