using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public  AudioSource sfxAudioSource;
    [SerializeField] private float sfxVolume;
    //[SerializeField] AudioClip rockCollide;
    [SerializeField] AudioClip coinCollect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySfx(AudioClip clip, float value)
    {
        if (sfxAudioSource != null)
        {
            sfxAudioSource.PlayOneShot(clip, value);
        }

    }

    /*public void RockColliderSfx()
    {
        PlaySfx(rockCollide, sfxVolume);
    }*/

    public void CoinCollectSfx()
    {
        PlaySfx(coinCollect, sfxVolume);
    }


}
