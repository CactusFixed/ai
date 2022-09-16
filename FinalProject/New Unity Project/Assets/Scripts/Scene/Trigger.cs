using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Wall;
    public Collider2D wallColl;
    public GameObject crankDown, crankUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            wallColl.enabled = false;
            Invoke("Destroy", 1f);
            crankDown.SetActive(true);
            crankUp.SetActive(false);
        }
    }
    private void Destroy()
    {
        Destroy(Wall);
    }
}
