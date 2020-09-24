using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainLever : LevierScript
{
    private bool Activated = false;

    public Player user = null;

    // Update is called once per frame
    void Update()
    {
        

        if(user != null && Vector3.Distance(transform.position, user.transform.position) > 2)
        {
            StopInteractionSas();
            user = null;
        }
    }

    public override void InteractionSas()
    {
        sas_Script.Ouvert = true;
    }
    public void StopInteractionSas()
    {
        
        sas_Script.Ouvert = false;
    }
}
