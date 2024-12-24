using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        Music();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Music()
    {
        AudioClip clip = sounds[Random.Range(0, sounds.Length)];
        myAudioSource.PlayOneShot(clip);
    }
}
