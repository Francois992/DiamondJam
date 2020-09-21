using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnj_Trigger : MonoBehaviour
{
    public Pnj pnj;
    public SphereCollider sphere;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pnj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pnj.transform.position;
    }

    

}
