using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float maxGravity = -1;
    [SerializeField]
    private float gravityRate = 0.1f;

    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public Vector2 moveInput;
    [HideInInspector]
    public float currentY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentY = maxGravity;
    }

    void Update()
    {
        ApplyGravity();
        MovePlayer();
    }

    void OnMove(InputValue moveValue)
    {
        moveInput = moveValue.Get<Vector2>();
    }

    public void ApplyGravity()
    {
        currentY -= gravityRate;
        currentY = Mathf.Clamp(currentY, maxGravity, 1);
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(moveInput.x, currentY, moveInput.y);

        if (moveInput != Vector2.zero)
        {
            Vector3 lookVector = new Vector3(movement.x, 0, movement.z);
            Quaternion toRotation = Quaternion.LookRotation(lookVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 10f);
        }

        controller.Move(movement * Time.deltaTime * speed);
    }
}
