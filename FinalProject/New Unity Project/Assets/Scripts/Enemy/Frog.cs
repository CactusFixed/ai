using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    //private Rigidbody2D rb;
    public Transform left, right;
    public float Speed, JumpForce;
    public LayerMask Ground;
    public Collider2D Coll;
    private float leftx, rightx;
    //private Animator anima;
    private float facetoleft = 1;


    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //anima = GetComponent<Animator>();
        leftx = left.position.x;
        rightx = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);

    }

    void Update()
    {
        
    }

    void Movement()
    {
        /*
        if(transform.position.x < leftx)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(-Speed, JumpForce);
            facetoleft = -1;
        }
        if (transform.position.x > rightx)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-Speed, JumpForce);
            facetoleft = 1;
        }
        else
        {
            rb.velocity = new Vector2(-Speed*facetoleft, rb.velocity.y);
        }
        */
        if (facetoleft > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (Coll.IsTouchingLayers(Ground))
            {
                anima.SetBool("f_jumping", true);
                anima.SetBool("f_falling", false);
                rb.velocity = new Vector2(-Speed * facetoleft, JumpForce);
                if (transform.position.x < leftx)
                {
                    facetoleft = -1;
                }
            }
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (Coll.IsTouchingLayers(Ground))
            {
                anima.SetBool("f_jumping", true);
                anima.SetBool("f_falling", false);
                rb.velocity = new Vector2(-Speed * facetoleft, JumpForce);
                if (transform.position.x > rightx)
                {
                    facetoleft = 1;
                }
            }
        }
        
    }
    
    void SwitchAnima()
    {
        if (rb.velocity.y < -0.1f)
        {
            anima.SetBool("f_falling", true);
            anima.SetBool("f_jumping", false);
        }
        if (Coll.IsTouchingLayers(Ground))
        {
            anima.SetBool("f_falling", false);
        }
    }
    


}