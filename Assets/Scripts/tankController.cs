
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class tankController : MonoBehaviour
{
    [SerializeField]
    float walikingSpeed = 5;
    [SerializeField]
    float rotatetionSpeed = 30;
    float timeIdle;
    Vector2 move = Vector2.zero;
    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
        Animator anim = GetComponent<Animator>();
        if (move.magnitude > 0.1f)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }
    public void OnJump(InputValue value)
    {
    }
    void Update()
    {
        Vector3 mv = Vector3.forward * move.y * walikingSpeed;
        transform.Translate(mv * Time.deltaTime);

        float angel = rotatetionSpeed * move.x;
        transform.Rotate(Vector3.up, angel * Time.deltaTime);


        if (move.magnitude < 0.1f)
        {
            timeIdle += Time.deltaTime;
            if (timeIdle >= 10)
            {
                Animator anim = GetComponent<Animator>();
                anim.SetBool("dancing", true);
            }
        }
        else
        {
            timeIdle = 0;
        }
    }
}
