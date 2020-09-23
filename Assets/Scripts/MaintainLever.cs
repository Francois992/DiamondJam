using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainLever : LevierScript
{
    private bool Activated = false;


    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            sas_Script.Ouvert = true;

        }
        else
        {
            sas_Script.Ouvert = false;

        }
    }

    public override void InteractionSas()
    {
        Activated = true;
    }
    public void StopInteractionSas()
    {
        Activated = false;
    }
}
