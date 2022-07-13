using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource AudioScr;
    private float Volume = 0.125f;

    void Start()
    {
        AudioScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioScr.volume = Volume;
    }
    public void SetVolume(float vol)
    {
        Volume = vol;
    }
}
