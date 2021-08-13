using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    private GameObject enemy;
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown("k"))
            {
                anim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyMovement>().takeDamage(damage);
                    Debug.Log("Taking damage");

                    var enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
                    enemy.knockbackCount = enemy.knockbackLength;
                    if(enemy.enemyrb2d.position.x < rb2d.position.x)
                    {
                        enemy.knockFromRight = true;
                    } else
                    {
                        enemy.knockFromRight = false;
                    }
                    
                }
            }
            
            
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
