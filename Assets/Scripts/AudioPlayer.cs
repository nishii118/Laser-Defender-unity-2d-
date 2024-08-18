using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolumn = 1f;
    [Header("Get Damage")]
    [SerializeField] AudioClip getDamageClip;
    [SerializeField][Range(0f, 1f)] float getDamageVolumn = 1f;
    [Header("Die State")]
    [SerializeField] AudioClip dieClip;
    [SerializeField][Range(0f, 1f)] float dieVolumn = 1f;
    public static AudioPlayer instance;

    public AudioPlayer GetInstance() {
        return instance;
    }
    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolumn);
    }
    public void PlayGetDamageClip()
    {
        PlayClip(getDamageClip, getDamageVolumn);
    }

    public void PlayDieClip()
    {
        PlayClip(dieClip, dieVolumn);
    }

    void PlayClip(AudioClip clip, float volumn)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volumn);
        }
    }
}
