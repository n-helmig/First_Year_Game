using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int health;                            
    public int numOfHearts;                                                                                                                                          
    public bool isDead = false;                                                
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private Rigidbody2D rb2d;
    private MovePlayer playerMove;
    private EnemyMovement enemyMove;
    private SpriteRenderer sRender;
    public GameObject gameOver;
    public int knockbackPower = 50;

    public void Awake()
    {
        health = numOfHearts;
        playerMove = GetComponent<MovePlayer>();
        sRender = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        enemyMove = GetComponent<EnemyMovement>();
    }


    public void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }

    }

    public void takeDamage(int damage)
    {

        health -= damage;
        if (health <= 0 && !isDead)
        {
            
            Death();
        }
    }


    public void Death()
    {
        isDead = true;
        Destroy(playerMove);
        Destroy(sRender);
        gameOver.SetActive(true);

    }
}
