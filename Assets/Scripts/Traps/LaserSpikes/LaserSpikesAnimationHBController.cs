using UnityEngine;
using System;

public class LaserSpikesAnimationHBController : MonoBehaviour
{
    private Collider2D damageTrigger;


    void Start()
    {

        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

        foreach (var col in colliders) // find which one is the laser spike hb
        {
            if (col.isTrigger)
            {
                damageTrigger = col;
                break;
            }
        }
    }

    public void ChangeHB(int changeTo)
    {
        damageTrigger.enabled = Convert.ToBoolean(changeTo);
    }


}
