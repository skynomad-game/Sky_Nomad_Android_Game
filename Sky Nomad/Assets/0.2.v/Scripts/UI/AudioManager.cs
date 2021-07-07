using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioSource> audioTracks= new List<AudioSource>();
    public int currentTrack;
    public bool audioCanBePlayed = false;

    private void Start()
    {
        foreach (Transform t in transform)
        {
            audioTracks.Add(t.gameObject.GetComponent<AudioSource>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audioCanBePlayed)
        {
            if (!audioTracks[currentTrack].isPlaying)
            {
                audioTracks[currentTrack].Play();
                Debug.Log("Esta sonando!");
            }
            else
            {
                audioTracks[currentTrack].Stop();
            }
        }
    }

    public void PlayNewTrack(int newTrack)
    {
        audioTracks[currentTrack].Stop();
        currentTrack = newTrack;
        audioTracks[currentTrack].Play();
    }
}
