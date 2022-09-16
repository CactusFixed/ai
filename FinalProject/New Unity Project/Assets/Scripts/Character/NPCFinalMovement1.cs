using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFinalMovement1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    public float speed, jumpForce;
    public Transform celling, groundCheck;
    public LayerMask ground,player;

    public bool  isGround;

    public NPCControl1 NPCControl1;

    bool jumpPressed;
    int jumpcount;

    public AudioSource JumpAudio;

    


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()//Update执行时间由设备决定，按键相关都放入其中
    {
        if(Input.GetButtonDown("Jump") && jumpcount > 0)
        {
            jumpPressed = true;
        }
        
    }

    private void FixedUpdate()//FixedUpdate执行时间固定，物理效果相关的都放入其中
    {
        
            GroundMovement();
        
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f,ground) || Physics2D.OverlapCircle(groundCheck.position, 0.1f, player);
        Jump();
    }

    void GroundMovement()
    {
        if (PlayerControl.isHurt == false)
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(horizontalMove));
            if (horizontalMove != 0)
            {
                transform.localScale = new Vector3(horizontalMove, 1, 1);
            }
            NPCControl1.Crouch();
        }
    }

    void Jump()
    {
        if(isGround )
        {
            jumpcount = 1;
        }

        if(jumpPressed == true && PlayerControl.isHurt == false && NPCControl1.triggeredcoll.enabled == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("jumping", true);
            JumpAudio.Play();
            if (!isGround)
            {
                jumpcount--;
            }
            jumpPressed = false;//在FixedUpdate中，保证一致性 
        }

    }


    


}
