
using UnityEngine;
using UnityEngine.InputSystem;

public class Lookcontroller : MonoBehaviour
{
    [SerializeField]
    Vector2 sensitivity = Vector2.one;
    Vector2 lookInput;
    Camera head;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        head = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        xRotation += lookInput.y * sensitivity.y * -1;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        head.transform.localEulerAngles = new(xRotation, 0, 0);

        transform.Rotate(Vector3.up, lookInput.x * sensitivity.x);
    }
    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
}
