using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource Background;
    public AudioSource PlayerJump;
    public AudioSource PlayerLand;
    public AudioSource PlayerWhip;
    public AudioSource CatGrab;
    public AudioSource PlayerStep;
    public AudioSource Trampoline;
    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void PlayPlayerJumpSound()
    {
        if (!PlayerJump.isPlaying)
            PlayerJump.Play();
    }
    public void PlayTrampolineSound()
    {
        if (!Trampoline.isPlaying)
            Trampoline.Play();
    }
    public void PlayPlayerLandSound()
    {
        if (!PlayerLand.isPlaying)
            PlayerLand.Play();
    }
    public void PlayPlayerStep()
    {
        if (!PlayerStep.isPlaying)
            PlayerStep.Play();
    }
    public void PlayPlayerWhip()
    {
        PlayerWhip.Play();
    }
    public void PlayCatGrab()
    {
        CatGrab.Play();
    }

}
