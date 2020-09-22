using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Trigger_Script : MonoBehaviour
{

    Oxygene_Script oxygene_Script;
    Porte_Script porte_Script;

    // Start is called before the first frame update
    void Start()
    {
        oxygene_Script = FindObjectOfType<Oxygene_Script>();
        porte_Script = FindObjectOfType<Porte_Script>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Antidode")) SceneManager.LoadScene("Scene_Victoire");

        if (other.CompareTag("Oxygene"))
        {
            if (other.gameObject.GetComponent<Oxygene_Script>().Oxygene == true) UnityEngine.Debug.Log("Vivant");
            else gameObject.GetComponent<Player>().enVie = false;
        }

        if (other.CompareTag("Pnj") || (other.CompareTag("Player") && gameObject.GetComponent<Player>().playerId != other.GetComponent<Player>().playerId))
        {
            gameObject.GetComponent<Player>().enVie = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Porte")) porte_Script.Ouvert = true;

        if (other.CompareTag("Oxygene"))
        {
            if (other.gameObject.GetComponent<Oxygene_Script>().Oxygene == true) UnityEngine.Debug.Log("Vivant");
            else gameObject.GetComponent<Player>().enVie = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Porte")) porte_Script.Ouvert = false;
    }
    
}