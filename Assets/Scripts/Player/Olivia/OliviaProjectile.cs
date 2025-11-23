using UnityEngine;

public class OliviaProjectile : MonoBehaviour
{
    public float lifetime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // reduce the timer every frame
        if (lifetime > 0)
            lifetime -= Time.deltaTime;
        else
        {
            Destroy(gameObject);
        }
    }

    //OnCollisionEnter2D is a built in Unity function that happens at the start of any collision with this game object
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy this game object
        Destroy(gameObject);
    }
}
