using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int score = 50;
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool isAppliedCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public int GetCurrentHealth()
    {
        return health;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            //take damage
            TakeDamage(damageDealer.GetDamage());
            Shake();
            audioPlayer.PlayGetDamageClip();

            PlayHitEffect();
            // damageDealer.Hit();
        }
    }

    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        // Debug
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isPlayer)
        {
            audioPlayer.PlayDieClip();
            levelManager.LoadGameOver();
        }
        else
        {
            scoreKeeper.ModifyScore(score);
        }
        Destroy(gameObject);
    }
    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void Shake()
    {
        if (cameraShake != null && isAppliedCameraShake)
        {
            cameraShake.Play();
        }
    }
}
