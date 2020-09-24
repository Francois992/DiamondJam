using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_zone : MonoBehaviour
{

    public Player player;           //Choix de Player
    public Camera camera;
    public SphereCollider sphere;   //Collider désigné
    public Vector3 scale;           //Taille de la zone dangereuse

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        sphere = GetComponent<SphereCollider>();
        this.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    public void Follow()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }



}
