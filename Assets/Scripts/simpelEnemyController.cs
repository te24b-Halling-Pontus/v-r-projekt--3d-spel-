using UnityEngine;

public class simpelEnemyController : MonoBehaviour
{

    CharacterController controller;
    float gravityMuilt = 2;
    float velocetyY = 0;
    float timeIdle = 0;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        velocetyY += Physics.gravity.y * gravityMuilt * Time.deltaTime;

        if (controller.isGrounded && velocetyY < 0)
        {
            velocetyY--;
        }

        Vector3 movement = transform.forward * 0 + transform.right * 0;
        movement.y = velocetyY;

        controller.Move(movement * Time.deltaTime);

        timeIdle += Time.deltaTime;
        if (timeIdle >= 10)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetBool("dancing", true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
