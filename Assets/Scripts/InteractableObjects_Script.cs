using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects_Script : MonoBehaviour
{
    GameManager gameManager;


    public float maxDistance = 250f;

    public bool ObjetInteractible;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject player in gameManager.Players)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            float scale = 0f;
            if (dist < maxDistance)
            {

                scale = 1f - (dist / maxDistance);
                
                if (scale <= 0.03f) GetComponent<Renderer>().material.SetFloat("_Outline", scale);
            }
        }

        if(ObjetInteractible == false) GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.clear);
        else GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.red);

    }
}
