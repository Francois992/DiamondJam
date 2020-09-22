using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pnj : MonoBehaviour
{
    
    public Vector3 position;
    public float timeDead = 2f;
    public float timerD = 0f;

    public Vector3 posDep;
    public Vector3 posArr;

    public float timeMove = 1.5f;
    public float timerM = 0f;
    public bool move = true;
    public bool right = true;

    public List<GameObject> destination;
    public List<float> stay;
    public NavMeshAgent agent;
    public int dest = 0;
    public float distReaction = 5f;
    public float distSeparation;

    public float timeWait = 3f;
    public float timerW = 0f;
    public int indexWait = 0;

    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distSeparation = Vector3.Distance(transform.position, destination[dest].transform.position);
        Move();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Oxygene"))
        {
            if (other.gameObject.GetComponent<Oxygene_Script>().Oxygene == true) Debug.Log("Vivant");
            else Death();
        }
    }


    public void Move()
    {
        
        if(distSeparation <= distReaction)
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
        if(timerD >= timeDead)
        {
            gameObject.SetActive(false);
        }
    }
    
    

    

}
