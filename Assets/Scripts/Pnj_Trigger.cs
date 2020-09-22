using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnj_Trigger : MonoBehaviour
{
    public Pnj pnj;
    public SphereCollider sphere;
    public Vector3 scale;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(pnj.transform.position.x, 0, pnj.transform.position.z);
        sphere = GetComponent<SphereCollider>();
        this.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pnj.transform.position.x, 0, pnj.transform.position.z);
    }

    

}
