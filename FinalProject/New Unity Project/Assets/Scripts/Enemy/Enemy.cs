using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator anima;
    protected AudioSource DeathAudio;
    protected Rigidbody2D rb;
    protected virtual void Start()
    {
        anima = GetComponent<Animator>();
        DeathAudio = GetComponent<AudioSource>();
    }
    public void DeathAnima()
    {
        GetComponent<Collider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        anima.SetTrigger("death");
        DeathAudio.Play();
    }

    public void Jumped()
    {

        Destroy(gameObject);
    }

}
