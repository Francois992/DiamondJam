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

    public List<Vector3> destination;
    public NavMeshAgent agent;
    public int dest = 0;
    public float distReaction = 1f;
    public float distSeparation;

    public float timeWait = 3f;
    public float timerW = 0f;

    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        distSeparation = Vector3.Distance(transform.position, destination[dest]);
        Move();
        //Death();
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

        agent.SetDestination(destination[dest]);
        if(distSeparation <= distReaction)
        {
            
            //Wait();
            dest++;
            dest = dest % (destination.Count);
        }

        /*
        if (move)
        {
            if (right)
            {
                transform.Translate(Vector3.right * Time.deltaTime);
                if (timerM >= timeMove)
                {
                   right = false;
                   timerM = 0;
                }
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime);
                if (timerM >= timeMove)
                {
                    right = true;
                    timerM = 0;
                }
            }
            timerM += Time.deltaTime;
            
        }*/
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
    
    public void Wait()
    {
        timerW += Time.deltaTime;
        if(timerW >= timeWait)
        {
            timerW = 0;
        }
    }

}
