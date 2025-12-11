using UnityEngine;

public class HealthPickupEffect : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        collision.gameObject.GetComponent<Destructible>().increaseMaxHealth();
    }
}
