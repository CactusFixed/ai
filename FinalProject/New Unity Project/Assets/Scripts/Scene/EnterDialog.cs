using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialog1 : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public GameObject enterDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "NPC")
        {
            enterDialog.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "NPC")
        {
            enterDialog.SetActive(false);
        }
    }
}
