using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Enemy
{
    public Transform left, right;
    private float leftx, rightx;
    public float speed;
    public Collider2D coll;
    private float facetoleft = 1;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        leftx = left.position.x;
        rightx = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        rb.velocity = new Vector2(-facetoleft * speed, 0);
        if (transform.position.x > rightx)
        {
            facetoleft = 1;
            rb.velocity = new Vector2(-facetoleft * speed, 0);
            transform.localScale = new Vector3(facetoleft, 1, 1);
        }
        if (transform.position.x < leftx)
        {
            facetoleft = -1;
            rb.velocity = new Vector2(-facetoleft * speed, 0);
            transform.localScale = new Vector3(facetoleft, 1, 1);
        }
    }
}
