using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Sas_Script sas_script;

    [SerializeField] private GameObject[] oxygeneSalles;

    // Start is called before the first frame update
    void Start()
    {
        sas_script = FindObjectOfType<Sas_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sas_script.Ouvert == true) oxygeneSalles[1].GetComponent<Oxygene_Script>().Oxygene = false;
        else oxygeneSalles[1].GetComponent<Oxygene_Script>().Oxygene = true;
    }
}
