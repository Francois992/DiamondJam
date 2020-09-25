using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnj_Trigger : MonoBehaviour
{
    public Pnj pnj;                 //Choix du pnj 
    public SphereCollider sphere;   //Collider désigné
    public Vector3 scale;           //Taille de la zone dangereuse
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(pnj.transform.position.x, pnj.transform.position.y-0.97f, pnj.transform.position.z);
        sphere = GetComponent<SphereCollider>();
        this.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }


    public void Follow()
    {
        transform.position = new Vector3(pnj.transform.position.x, pnj.transform.position.y -0.97f, pnj.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Oxygene"))
        {
            if (other.GetComponent<Oxygene_Script>().Oxygene < 100) transform.parent.GetComponent<Pnj>().Death();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Oxygene"))
        {
            if (other.GetComponent<Oxygene_Script>().Oxygene < 100) transform.parent.GetComponent<Pnj>().Death();

        }
    }
}
