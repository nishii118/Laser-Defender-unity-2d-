using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 4f;
    [SerializeField] float baseFiringRate = 0.2f;
    [Header("AI")]
    [SerializeField] float firingRateVariance = 0;
    [SerializeField] float miniumFiringRate = 0.7f;
    [SerializeField] bool useAI;
    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    ObjectPool objectPool;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        objectPool = GetComponent<ObjectPool>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());

        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        // GameObject instance = objectPool.GetPooledObject();
        // Debug.Log(instance);
        // yield return new WaitForSeconds(0);
        while (true)
        {
            // GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // Debug.Log("instance is created");
            GameObject instance = objectPool.GetPooledObject();
            Debug.Log("get instance");
            if (instance != null)
            {
                instance.transform.position = transform.position;
                instance.transform.rotation = Quaternion.identity;
                instance.SetActive(true);

                Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                rb.velocity = transform.up * projectileSpeed;
                // Destroy(instance, projectileLifetime);
                // StartCoroutine(instance.SetActive(false));
                float timeToNextInstance = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
                timeToNextInstance = Mathf.Clamp(timeToNextInstance, miniumFiringRate, float.MaxValue);
                audioPlayer.PlayShootingClip();
                StartCoroutine(DeleteBulletCoroutine(instance, projectileLifetime));

                yield return new WaitForSeconds(timeToNextInstance);
            }
        }
    }

    IEnumerator DeleteBulletCoroutine(GameObject instance, float projectileLifetime)
    {
        yield return new WaitForSeconds(projectileLifetime);
        instance.SetActive(false);
    }
}
