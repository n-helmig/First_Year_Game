using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float speed;

    public float jumpForce;

    private bool canJump = true;

    private int jumps;

    public int jumpValue;

    private bool facingRight = true;

    public Transform groundCheck;

    public float checkRadius;

    public LayerMask whatIsGround;

    private Rigidbody2D rb2d;

    private Animator anim;



    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        jumps = jumpValue;
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        
         rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
        if (moveHorizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

         canJump = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
     
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump == true)
        {
            jumps = jumpValue;
        }

        if (Input.GetKeyDown("space") && jumps > 0)
        {
            anim.SetTrigger("jumpOff");
            rb2d.AddForce(this.gameObject.transform.up * jumpForce);
            jumps --;
            anim.SetTrigger("jumping");
        }
        else if (Input.GetKeyDown("space") && jumps == 0 && canJump == true)
        {
            rb2d.AddForce(this.gameObject.transform.up * jumpForce);
            canJump = false;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius );
    }
}




