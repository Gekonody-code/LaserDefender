using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.5f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

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
        while(true)
        {
            Vector3 rotation;
            if (useAI)
            {
                rotation = new Vector3(0,0,0);
            }
            else
            {
                rotation = new Vector3(0, 0, 180);
            }
            GameObject projectile;
            projectile = Instantiate(projectilePrefab,
                transform.position,
                Quaternion.Euler(rotation));

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log(transform.up);
                rb.velocity = -transform.up * projectileSpeed;
            }
            Destroy(projectile, projectileLifetime);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(GetRandomShootTime());
        }
    }

    private float GetRandomShootTime()
    {
        float spawnTime = Random.Range(firingRate - firingRateVariance,
            firingRate + firingRateVariance);
        return Mathf.Clamp(spawnTime, minimumFiringRate, float.MaxValue);
    }
}
