using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopNPC : MonoBehaviour
{
    public NPCControl NPCControl;
    public NPCFinalMovement NPCFinalMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            NPCControl.enabled = false;
            NPCFinalMovement.enabled = false;
        }
        else if(Input.GetKeyUp(KeyCode.J))
        {
            NPCControl.enabled = true;
            NPCFinalMovement.enabled = true;

        }
        
    }
}
