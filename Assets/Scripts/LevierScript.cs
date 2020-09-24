using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevierScript : MonoBehaviour
{
    public bool Activation = false;
    
    [SerializeField] protected Sas_Script sas_Script;
    [SerializeField] protected Laser laser;
    

    // Start is called before the first frame update
    void Start()
    {
        //sas_Script = ObjetInteragir.GetComponent<Sas_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void InteractionSas()
    {
        if(laser != null)
        {
            if (laser.activation)
            {
                laser.activation = true;

            }
            else
            {
                laser.activation = false;

            }
        }
        else if (sas_Script)
        {
            if (!sas_Script.Ouvert)
            {
                sas_Script.Ouvert = true;

            }
            else
            {
                sas_Script.Ouvert = false;

            }
        }
        

    }
}
