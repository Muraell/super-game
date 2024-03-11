using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{

    public float speed;
    public float lifetime;
    public float damage = 10;

   

    private void Start()
    {
        Invoke("DestroyFireBall", lifetime);
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    // Update is called once per frame
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.value -= damage;
            if (enemyHealth.value <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }
        }

        DestroyFireBall();
    }

    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }

   
}
