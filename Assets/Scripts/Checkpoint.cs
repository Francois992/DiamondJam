using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint instance;
    GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastPositionCheckpoint = transform.localPosition;
            gameObject.SetActive(false);
        }
    }
}
