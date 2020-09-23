using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using System.Runtime.ExceptionServices;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;

    [Range(100f, 500f)] public float mouseSensitivity = 100f;
    [SerializeField, Range(1f, 8f)] private float detectionLength = 4f;
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField, Range(20f, -20f)] private float gravity = -9f;

    private float initialGravValue;

    private float xRotation = 0f;

    private CharacterController controller;

    public int playerId = 0;

    public bool enVie;

    private Rewired.Player playerController ;

    private Vector3 velocity;

    private bool isGrounded = true;

    public bool inUpGrav = false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    public List<GameObject> inventairePlayer = new List<GameObject>();

    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = ReInput.players.GetPlayer(playerId);

        controller = GetComponent<CharacterController>();

        gameManager = FindObjectOfType<GameManager>();

        enVie = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamView();

        UpdatePos();

        checkForInteractible();

        if (Input.GetKeyDown(KeyCode.Space)) removeItemInventaire();
    }

    private void UpdateCamView()
    {
        float mouseX = playerController.GetAxis("LookX") * mouseSensitivity * Time.deltaTime;
        float mouseY = playerController.GetAxis("LookY") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up, mouseX);
    }

    private void UpdatePos()
    {
        if(!inUpGrav) isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        else isGrounded = false;
        

        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        float xPos = playerController.GetAxis("AxisX");
        float zPos = playerController.GetAxis("AxisZ");

        Vector3 movePos = transform.right * xPos + transform.forward * zPos;

        controller.Move(movePos * moveSpeed *Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void checkForInteractible()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, detectionLength))
        {
            if (hit.transform.GetComponent<LevierScript>())
            {
                if (playerController.GetButtonDown("Interact"))
                {
                    LevierScript interactible = hit.transform.GetComponent<LevierScript>();

                    interactible.InteractionSas();
                }
 
            }

            if (hit.transform.CompareTag("ObjetInventaire"))
            {
                Debug.Log("");
                if (playerController.GetButtonDown("Interact"))
                {
                    GameObject item = inventairePlayer.Find(x => x.name == hit.collider.gameObject.name);

                    if (item == null)
                    {
                        Debug.Log("Interaction");
                        inventairePlayer.Add(hit.collider.gameObject);
                        hit.collider.gameObject.SetActive(false);
                    }
                    else Debug.Log("Objet déjà dans l'inventaire du Player");
                }
            }
        }
    }

    //Fonction pour enlever les items de l'inventaire | il faudra simplement changer le x.name en fonction de l'item voulu
    private void removeItemInventaire()
    {
        GameObject itemCheck = inventairePlayer.Find(x => x.name == "Cube");
        if (itemCheck != null)
        {
            inventairePlayer.Remove(itemCheck);
            itemCheck.SetActive(true);
        }
        else Debug.Log("Objet non présent");
    }

    public void changeGravity(float value)
    {
        initialGravValue = gravity;
        gravity = value;
    }

    public void revertGravity()
    {
        gravity = initialGravValue;

    }
}
