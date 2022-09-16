using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    public Transform up, down;
    private float upy, downy;
    public float speed;
    private float goup = 1;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        upy = up.position.y;
        downy = down.position.y;
        Destroy(up.gameObject);
        Destroy(down.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        rb.velocity = new Vector2(0, goup * speed);
        if (transform.position.y > upy)
        {
            goup = -1;
            rb.velocity = new Vector2(0, goup * speed);
        }
        if (transform.position.y < downy)
        {
            goup = 1;
            rb.velocity = new Vector2(0, goup * speed);
        }
    }
}
