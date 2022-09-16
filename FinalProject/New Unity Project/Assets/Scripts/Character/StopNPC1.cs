using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopNPC1 : MonoBehaviour
{
    public NPCControl1 NPCControl1;
    public NPCFinalMovement1 NPCFinalMovement1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            NPCControl1.enabled = false;
            NPCFinalMovement1.enabled = false;
        }
        else if(Input.GetKeyUp(KeyCode.J))
        {
            NPCControl1.enabled = true;
            NPCFinalMovement1.enabled = true;

        }
        
    }
}
