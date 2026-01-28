
using UnityEngine;
using UnityEngine.InputSystem;
public class normalController : MonoBehaviour
{
    Vector2 move = Vector2.zero;
    [SerializeField]
    float walkingSpeed = 5;
    float timeIdle = 0;
    // Update is called once per frame
    void Update()
    {
        Vector3 mv = Camera.main.transform.forward * move.y + Camera.main.transform.right * move.x;
        mv.y = 0;
        mv.Normalize();

       
       
        transform.Translate(mv * Time.deltaTime * walkingSpeed);

        GameObject model = transform.GetChild(0).gameObject;
        if (mv.magnitude > 0.1f)
        {
            model.transform.forward = mv;
        }
    }
    public void OnMove(InputValue value)
    {
        Animator anim = GetComponentInChildren<Animator>();
        move = value.Get<Vector2>();
        if (move.magnitude > 0.1f)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }

        if (move.magnitude < 0.1f)
        {
            timeIdle += Time.deltaTime;
            if (timeIdle >= 10)
            {
                anim = GetComponent<Animator>();
                anim.SetBool("dancing", true);
            }
        }
        else
        {
            timeIdle = 0;
        }
    }
}
