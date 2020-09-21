using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnj : MonoBehaviour
{
    
    public Vector3 position;
    public float timeDead = 2f;
    public float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public void Death()
    {
        timer += Time.deltaTime;
        if(timer >= timeDead)
        {
            this.gameObject.SetActive(false);
        }
    }

}
