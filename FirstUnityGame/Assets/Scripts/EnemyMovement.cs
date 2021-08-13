using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Transform target;

    public int startingHealth = 100;
    public int currentHealth;
    public float timeToLive;

    private float dazedTime;
    public float startDazedTime;
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public Rigidbody2D enemyrb2d;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = startingHealth;
        Destroy(gameObject, timeToLive);
        enemyrb2d = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        checkStatus();

        if (dazedTime <= 0)
        {
            speed = 1;
        } else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (knockbackCount <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else
        {
            if (knockFromRight)
            {
                enemyrb2d.velocity = new Vector2(-knockback, knockback);
            }
            if (!knockFromRight)
            {
                enemyrb2d.velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }

        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
    }
    
    void checkStatus()
    {
        if (currentHealth > startingHealth)
            currentHealth = startingHealth;

        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth == 0)
            Death();
    }

    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        dazedTime = startDazedTime;
        
    }

    public void Death()
    {
        Destroy(this.gameObject);

    }

}


