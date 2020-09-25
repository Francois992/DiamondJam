using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using DG.Tweening;

public class Player_Trigger_Script : MonoBehaviour
{

    Oxygene_Script oxygene_Script;
    Porte_Script porte_Script;
    GameManager gameManager;

    Canvas canvasPlayer;

    public GameObject PopUpInteraction;

    public float maxDistance = 100f;

    Player joueur;

    // Start is called before the first frame update
    void Start()
    {
        oxygene_Script = FindObjectOfType<Oxygene_Script>();
        porte_Script = FindObjectOfType<Porte_Script>();
        gameManager = FindObjectOfType<GameManager>();

        joueur = transform.parent.GetComponent<Player>();

        canvasPlayer = GameObject.FindGameObjectWithTag(joueur.playerId == 0 ? "CanvasJ1" : "CanvasJ2").GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
        DistancePnj();

        DistancePlayer();
    }

    public void DistancePnj()
    {
        float distPnj = Vector3.Distance(joueur.transform.localPosition, GameObject.FindGameObjectWithTag("Pnj").transform.localPosition);
        float scalePnj = 0f;

        if (distPnj < maxDistance)
        {

            scalePnj = 1f - (distPnj / maxDistance);

            canvasPlayer.GetComponentInChildren<Image>().DOFade(scalePnj, 0.1f);
        }
    }

    public void DistancePlayer()
    {
        foreach (GameObject player in gameManager.Players)
        {
            if (player.GetComponent<Player>().playerId != joueur.playerId)
            {
                float distPnj = Vector3.Distance(joueur.transform.localPosition, player.transform.localPosition);
                float scalePnj = 0f;

                if (distPnj < maxDistance)
                {

                    scalePnj = 1f - (distPnj / maxDistance);

                    canvasPlayer.GetComponentInChildren<Image>().DOFade(scalePnj, 0.1f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Oxygene"))
        {
            if (other.GetComponent<Oxygene_Script>().Oxygene < 100)
            {
                transform.parent.GetComponent<Player>().enVie = false;
                transform.parent.GetComponent<Player>().animator.SetBool("isDead", true); 
            }
        }

        if (other.CompareTag("Pnj") || (other.transform.parent != null && other.transform.parent.CompareTag("Player")))
        {
            transform.parent.GetComponent<Player>().enVie = false;
            transform.parent.GetComponent<Player>().animator.SetBool("isDead", true);

            Debug.Log("mort");
        }

        if (other.CompareTag("KillZone"))
        {
            transform.parent.GetComponent<Player>().enVie = false;
            transform.parent.GetComponent<Player>().animator.SetBool("isDead", true);
        }

        if (other.CompareTag("UpGrav"))
        {
            transform.parent.GetComponent<Player>().changeGravity(9);
        }

        if (other.transform.GetComponent<InteractableObjects_Script>())
        {
            PopUpInteraction = Instantiate(gameManager.PopUpToucheInteraction, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

            PopUpInteraction.transform.localPosition = new Vector3((joueur.playerId == 0 ? -275.0f : -275.0f), 0, 0);

            PopUpInteraction.transform.GetChild(0).GetComponent<Text>().text = "Appuyer sur " + transform.parent.GetComponent<Player>().NomToucheInteraction + " pour interagir";

            if (other.transform.GetComponent<MaintainLever>()) PopUpInteraction.transform.GetChild(0).GetComponent<Text>().text = "Maintenez sur " + transform.parent.GetComponent<Player>().NomToucheInteraction + " pour interagir";
            if (other.CompareTag("Antidode")) PopUpInteraction.transform.GetChild(0).GetComponent<Text>().text = "Appuyer sur " + transform.parent.GetComponent<Player>().NomToucheInteraction + " pour utiliser la seringue";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Porte"))
        {
            other.transform.parent.GetComponent<Porte_Script>().Ouvert = true;
        }

        if (other.CompareTag("Oxygene"))
        {
            if (other.GetComponent<Oxygene_Script>().Oxygene < 100)
            {
                transform.parent.GetComponent<Player>().enVie = false;
                transform.parent.GetComponent<Player>().animator.SetBool("isDead", true);
            }
        }

        if (other.CompareTag("UpGrav"))
        {
            transform.parent.GetComponent<Player>().inUpGrav = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Porte")) other.transform.parent.GetComponent<Porte_Script>().Ouvert = false;

        if (other.CompareTag("UpGrav"))
        {

            transform.parent.GetComponent<Player>().inUpGrav = false;
            transform.parent.GetComponent<Player>().revertGravity();
        }
        if (other.transform.GetComponent<InteractableObjects_Script>())
        {
            Destroy(PopUpInteraction);
        }
    }
    
}