using UnityEditor.Rendering;
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
        Animator anim = GetComponent<Animator>();
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
            Animator anim = GetComponent<Animator>(); // hämtar animatioen, så man kan ändra des värden
            Vector3 shotDiraction = collision.gameObject.transform.forward; // hämtar  riktningen från skottet
            float Dot = Vector3.Dot(transform.forward, shotDiraction); // jämför kulans riktiong med fiendens
            GetComponent<Collider>().enabled = false;
            if (Dot <= 0)
            {
                anim.SetBool("killed", true);
                Destroy(gameObject, 3);
            }
            else
            {
                anim.SetBool("killedFromBehind", true);
                Destroy(gameObject, 2.4f);
            }
        }
    }
    public void Hit()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("killed", true);
        Destroy(gameObject, 3);
    }
}
