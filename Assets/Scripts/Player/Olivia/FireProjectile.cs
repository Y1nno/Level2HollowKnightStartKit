using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;  // where the projectile spawns



    public float projectileSpeed = 10f;
    public float minimumCountdown = 0.5f;  // time between shots
    public float countdownTimer = 0f;

    void Update()
    {
        // reduce the timer every frame
        if (countdownTimer > 0)
            countdownTimer -= Time.deltaTime;
    }

    public void Fire()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * projectileSpeed;

        //set countdown
        countdownTimer = minimumCountdown;
    }
}
