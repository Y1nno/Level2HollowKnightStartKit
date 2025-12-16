using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;  // where the projectile spawns



    public float projectileSpeed = 10f;
    public float minimumCountdown = 0.5f;  // time between shots
    public float cooldownTimer = 0f;
    public bool canShoot = false;
    public bool flipFireDirection = false;

    void Update()
    {
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;
    }

    public void Fire()
    {
        if (!canShoot) { return; }

        Quaternion newRot;
        if (flipFireDirection)
        {
            newRot = transform.rotation * Quaternion.Euler(0, 0, 180f);
        }
        else
        {
            newRot = transform.rotation;
        }


        GameObject proj = Instantiate(projectilePrefab, firePoint.position, newRot);
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();

        if (flipFireDirection)
        {
            rb.linearVelocity = -transform.right * projectileSpeed;

        }
        else { rb.linearVelocity = transform.right * projectileSpeed; }


        cooldownTimer = minimumCountdown;
    }

    public void ChangeShootingAbility(bool? newBool)
    {
        if (newBool != null)
        {
            canShoot = newBool.Value;
        }
        else
        {
            canShoot = !canShoot;
        }
    }
}