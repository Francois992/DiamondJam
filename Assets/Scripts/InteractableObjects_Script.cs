using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects_Script : MonoBehaviour
{
    GameManager gameManager;


    public float maxDistance = 250f;

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
                GetComponent<Renderer>().material.SetFloat("_Outline", scale);
            }
        }
    }
}
