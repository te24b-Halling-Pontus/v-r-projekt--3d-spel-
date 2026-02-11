using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    float walkSpeed;
    Vector2 moveInput;
    CharacterController controller;

    [SerializeField]
    float gravityMuilt = 2;
    [SerializeField]
    float jumpForce = 200;

    float velocetyY = 0;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        velocetyY += Physics.gravity.y * gravityMuilt * Time.deltaTime;

        if (controller.isGrounded && velocetyY < 0)
        {
            velocetyY--;
        }

        Vector3 movement = transform.forward * moveInput.y + transform.right * moveInput.x;

        movement *= walkSpeed;

        movement.y = velocetyY;

        controller.Move(movement * Time.deltaTime);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if (controller.isGrounded)
        {
            velocetyY = jumpForce;
        }
    }
}
