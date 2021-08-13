using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public int damage;
 
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private HealthBar health;

    private void Start()
    {
    }

    private void OnTriggerStay2D(Collider2D col)
    { 
        if (timeBtwAttack <= 0)
        {
            if (col.tag == "Player")
            {
                health = col.gameObject.GetComponent<HealthBar>();
                health.takeDamage(damage);
                Debug.Log("Hitting player");
                timeBtwAttack = 5;
                if (health.isDead == true)
                {
                    Destroy(this);
                }
              
            } 
        } else
        {
           timeBtwAttack -= Time.deltaTime;
        }

    }

}
