using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Sas_Script sas_script;

    [SerializeField] private GameObject[] oxygeneSalles;

    public GameObject[] Players;

    public GameObject PopUpToucheInteraction;

    public GameObject menuDefaite;

    // Start is called before the first frame update
    void Start()
    {
        sas_script = FindObjectOfType<Sas_Script>();
        menuDefaite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sas_script != null)
        {

            if (sas_script.Ouvert == true && oxygeneSalles[0].GetComponent<Oxygene_Script>()) oxygeneSalles[0].GetComponent<Oxygene_Script>().Oxygene = 0;
            
        }

        foreach (GameObject player in Players)
        {
            if(player.GetComponent<Player>().enVie == false)
            {
                menuDefaite.SetActive(true);
            }
        }
    }
}
