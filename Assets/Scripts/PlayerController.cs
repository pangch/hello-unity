using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f, verticalSpeed = 0;

    private CharacterController charController;
    
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = Vector3.zero;
        if (!charController.isGrounded)
        {
            verticalSpeed += gravity * Time.deltaTime;
        } else
        {
            verticalSpeed = 0;
        }

        move.y = -verticalSpeed;
        charController.Move(move * Time.deltaTime);
    }
}
