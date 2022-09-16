using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    
    public EnterDialog EnterDialog;
    public GameObject npc;
    public GameObject npcSprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            npc.SetActive(true);
            gameObject.SetActive(false);
            Destroy(npcSprite);
        }
    }
}
