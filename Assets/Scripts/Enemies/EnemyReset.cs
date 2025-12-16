using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyDistanceReset2D : MonoBehaviour
{
    private GameObject player;

    public float resetDistance = 25f;
    public float checkEverySeconds = 0.5f;
    public bool requireNotVisible = true;
    public bool resetVelocity = true;
    public float distanceFromPlayer;

    private Vector3 spawnPos;
    private Quaternion spawnRot;

    private Rigidbody2D rb;
    private float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        var spawnT = transform;
        spawnPos = spawnT.position;
        spawnRot = spawnT.rotation;
    }

    void Start()
    {
        // Find the player GameObject, then look for a child named "Capsule".
        var playerGO = GameObject.FindWithTag("Player");
        if (playerGO == null) return;

        var capsuleTransform = playerGO.transform.Find("Capsule");
        player = (capsuleTransform != null) ? capsuleTransform.gameObject : playerGO;
    }

    void Update()
    {
        if (rb.simulated) return;
        if (!player) return;

        distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);

        timer += Time.deltaTime;
        if (timer < checkEverySeconds) return;
        timer = 0f;

        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist < resetDistance) return;

        if (requireNotVisible && IsVisibleToCamera()) return;

        ResetEnemy();
    }

    private void ResetEnemy()
    {
        transform.SetPositionAndRotation(spawnPos, spawnRot);

        if (resetVelocity && rb)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.simulated = true;
        }
        Destructible hp = GetComponent<Destructible>();
        if (hp != null) hp.HealToFull();
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<ShadowCaster2D>().enabled = true;
    }

    private bool IsVisibleToCamera()
    {
        var sr = GetComponentInChildren<SpriteRenderer>();
        if (sr == null) return false;
        return sr.isVisible;
    }
}