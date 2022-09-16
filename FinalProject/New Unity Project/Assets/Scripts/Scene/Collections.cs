using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collections : MonoBehaviour
{
    public Collider2D coll;
    public int Cherry;
    public AudioSource CollectAudio;
    public Text CherryNum;
    private Animator anima;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")//收集物品
        {
            CollectAudio.Play();
            anima.SetBool("isGot",true);
        }    

    }

    void isGot()
    {
            
            Cherry += 1;
            CherryNum.text = Cherry.ToString();//转换Cherry为字符
            Destroy(gameObject);
    }
}
