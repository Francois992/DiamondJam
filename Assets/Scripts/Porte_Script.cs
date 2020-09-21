using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Porte_Script : MonoBehaviour
{
    public bool Ouverte;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ouverte) transform.DOMoveY(70f, 0.5f);
        else transform.DOMoveY(20f, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Porte");
        if (other.CompareTag("Player")) Ouverte = true;
    }
}
