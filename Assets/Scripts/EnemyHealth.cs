using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value  = 100;
    public Animator animator;

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
