using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private HealthBar health;
    private EnemyMovement enemyHealth;

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            health = col.gameObject.GetComponent<HealthBar>();
            health.health = 0;
            health.Death();

        }
        if (col.tag == "Enemy")
        {
            enemyHealth = col.gameObject.GetComponent<EnemyMovement>();
            enemyHealth.Death();
        }
    }
}
