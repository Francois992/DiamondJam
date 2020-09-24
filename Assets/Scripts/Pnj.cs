using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pnj : MonoBehaviour
{

    public Vector3 position;
    public float timeDead = 2f;
    public float timeLaserDeath = 0.5f;
    public float timerD = 0f;

    public float timeMove = 1.5f;
    private float timerM = 0f;
    public bool move = true;
    public bool right = true;

    public List<GameObject> destination;
    public List<float> stay;
    public NavMeshAgent agent;
    private int dest = 0;
    public float distReaction = 2f;
    private float distSeparation;

    private float timerW = 0f;
    private int indexWait = 0;

    public bool attracted = false;
    
    public bool dead = false;
    public bool laser = false;

   [SerializeField] private Material material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        distSeparation = Vector3.Distance(transform.position, destination[dest].transform.position);
        if (!attracted)
        {
            Move();
        }

        if (laser)
        {
            rend.sharedMaterial = material;
            Death();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Oxygene"))
        {
            if (other.gameObject.GetComponent<Oxygene_Script>().Oxygene < 100) Death();
        }
    }


    public void Move()
    {
        if (distSeparation <= distReaction)
        {
            timerW += Time.deltaTime;
            if (timerW >= stay[indexWait])
            {
                indexWait = (indexWait + 1) % (stay.Count);
                dest = (dest + 1) % (destination.Count);
                timerW = 0;
            }
        }
        else
        {
            agent.SetDestination(destination[dest].transform.position);
        }
    }

        
    

    public void Death()
    {
        move = false;
        dead = true;
        timerD += Time.deltaTime;

        agent.speed = 0;

        if (laser)
        {
            //material.color = Color.black;
            //Debug.Log("Pnj grillé");
        }

            if (timerD >= timeDead)
        {
            gameObject.SetActive(false);
            timerD = 0;
        }
        
    }
    
    
    public void Attract(Vector3 position)
    {
        attracted = true;
        agent.SetDestination(position);
    }
    
    public void EndAttract()
    {
        attracted = false;
    }

}
