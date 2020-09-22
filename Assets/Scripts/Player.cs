﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;

    [Range(100f, 500f)] public float mouseSensitivity = 100f;
    [Range(1f, 8f)] private float detectionLength = 4f;
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField, Range(-1f, -20f)] private float gravity = -9f;

    private float xRotation = 0f;

    private CharacterController controller;

    private Rewired.Player playerController ;

    private Vector3 velocity;

    private bool isGrounded = true;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = ReInput.players.GetPlayer(0);

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamView();

        UpdatePos();

        checkForInteractible();
    }

    private void UpdateCamView()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up, mouseX);
    }

    private void UpdatePos()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

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

            if (hit.transform.GetComponent<Interactibles>())
            {
                if (playerController.GetButtonDown("Interact"))
                {
                    Interactibles interactible = hit.transform.GetComponent<Interactibles>();

                    interactible.OnActivate();
                }
 
            }
        }
    }
}