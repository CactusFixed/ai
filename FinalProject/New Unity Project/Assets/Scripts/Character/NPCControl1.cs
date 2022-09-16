using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCControl1 : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    private Animator anima;

    public Collider2D coll;
    public Collider2D triggeredcoll;

    public float speed;
    public float jumpforce;
    public Transform Celling;
    public LayerMask Ground,Player;
    public AudioSource JumpAudio, HurtAudio,FallAudio,CollectAudio;

    

    public static bool isHurt;//默认false

    public int Cherry;
    public Text CherryNum;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
        SwitchAnima();
        
    }
    void Movement()//移动
    {
        if (isHurt == false)
        {
            float horizontalmove = Input.GetAxis("Horizontal");
            float facedirection = Input.GetAxisRaw("Horizontal");


            anima.SetFloat("running", Mathf.Abs(facedirection));
            if (facedirection != 0)
            {
                transform.localScale = new Vector3(facedirection, 1, 1);
            }
            if (horizontalmove != 0)
            {
                rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);

            }

            //跳跃
            if (Input.GetButton("Jump") && coll.IsTouchingLayers(Ground) && triggeredcoll.enabled == true)
            //不能多次跳跃，不能蹲下时跳跃
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anima.SetBool("jumping", true);
                JumpAudio.Play();
            }
            Crouch();
        }

    }


    void SwitchAnima()//切换动画
    {
        anima.SetBool("idle", false);
        if(anima.GetBool("jumping"))
        {
            if(rb.velocity.y < 0.2f)
            {
                anima.SetBool("jumping", false);
                anima.SetBool("falling", true);
            }
            if (rb.velocity.y > 0)
            {
                anima.SetBool("falling", false);
            }
        }
        if (coll.IsTouchingLayers(Ground) || coll.IsTouchingLayers(Player))
        {
            anima.SetBool("falling", false);
            anima.SetBool("idle", true);
        }
        if(rb.velocity.y < 0.2f && !rb.IsTouchingLayers(Ground) && !rb.IsTouchingLayers(Player))
        {
            anima.SetBool("falling", true);
        }

        if (isHurt)
        {
            anima.SetBool("isHurt", true);
            if (Mathf.Abs(rb.velocity.x) < 2)
            {
                isHurt = false;
                anima.SetBool("isHurt", false);
            }
        }
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Collection")//收集物品
        {
            CollectAudio.Play();
            Destroy(collision.gameObject);
            Cherry += 1;
            CherryNum.text = Cherry.ToString();//转换Cherry为字符
        }
        if(collision.tag == "Respawn")//掉落后重新开始
        {
            GetComponent<AudioSource>().enabled = false;
            FallAudio.Play();
            Invoke("Restart", 2f);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)//消灭敌人,受伤
    {
        
        if (collision.gameObject.tag == "Enemies")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (anima.GetBool("falling") && gameObject.transform.position.y > collision.gameObject.transform.position.y)
            {
                enemy.DeathAnima();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anima.SetBool("jumping", true);
            }
            else if(transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                isHurt = true;
                HurtAudio.Play();
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                isHurt = true;
                HurtAudio.Play();
            }
        }
        /*
        if (collision.gameObject.tag == "Spike")//碰到陷阱后重新开始
        {
            GetComponent<AudioSource>().enabled = false;
            FallAudio.Play();
            Invoke("Restart", 1f);
        }
        */
    }

    public void Crouch()//蹲伏，Movement中引用
    {
        if (Input.GetButtonDown("Crouch") && rb.velocity.y == 0)
        {
            anima.SetBool("crouching", true);
            triggeredcoll.enabled = false;
        }
        if (!Physics2D.OverlapCircle(Celling.position,0.1f,Ground))
        {
            
            if (!Input.GetButton("Crouch"))
                //不用GetButtonUp是为了保证离开障碍物后自动站起
            {
                anima.SetBool("crouching", false);
                triggeredcoll.enabled = true;
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
