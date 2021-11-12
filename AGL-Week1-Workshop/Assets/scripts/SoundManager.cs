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
    public List<AudioSource> CatGrabs;
    public List<AudioSource> PlayerSteps;
    public AudioSource Trampoline;
    public AudioSource wind;
    private static SoundManager _instance;
    bool stepping = false;
    public float stepTime;
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
        if (!stepping)
        {
            int num = Random.Range(0, PlayerSteps.Count);
            PlayerSteps[num].Play();
            StartCoroutine(stepCooldown());
        }
    }
    private IEnumerator stepCooldown()
    {
        stepping = true;
        yield return new WaitForSeconds(stepTime);
        stepping = false;
    }
    public void PlayPlayerWhip()
    {
        PlayerWhip.Play();
    }
    public void PlayCatGrab()
    {
        int num = Random.Range(0, CatGrabs.Count);
        CatGrabs[num].Play();
    }
    public void PlayWind()
    {
        wind.Play();
    }
    public void StopWind()
    {
        wind.Stop();
    }
}
