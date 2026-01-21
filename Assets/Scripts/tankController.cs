using UnityEngine;
using UnityEngine.InputSystem;
public class tankController : MonoBehaviour
{
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
        timeIdle += Time.deltaTime;
        if (timeIdle >= 10)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetBool("dancing", true);
        }
    }
}
