using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevierScript : MonoBehaviour
{
    public bool Activation;
    [SerializeField] private Transform Sas;
    Sas_Script sas_Script;

    // Start is called before the first frame update
    void Start()
    {
        sas_Script = FindObjectOfType<Sas_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Activation)
        {
            Sas.DOMoveY(70f, 0.5f);
            sas_Script.Ouvert = true;
        }

        else 
        { 
            Sas.DOMoveY(20f, 0.5f);
            sas_Script.Ouvert = false;
        }
    }
}
