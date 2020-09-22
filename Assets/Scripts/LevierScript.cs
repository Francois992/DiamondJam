using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevierScript : MonoBehaviour
{
    public bool Activation;
    [SerializeField] private Transform ObjetInteragir;
    Sas_Script sas_Script;

    // Start is called before the first frame update
    void Start()
    {
        sas_Script = FindObjectOfType<Sas_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        InteractionSas();
    }

    public void InteractionSas()
    {
        if (Activation)
        {
            ObjetInteragir.DOMoveY(70f, 0.5f);
            sas_Script.Ouvert = true;
        }

        else
        {
            ObjetInteragir.DOMoveY(20f, 0.5f);
            sas_Script.Ouvert = false;
        }
    }
}
