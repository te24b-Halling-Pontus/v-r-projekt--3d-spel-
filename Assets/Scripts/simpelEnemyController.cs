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
            float dot = Vector3.Dot(transform.forward, shotDiraction); // jämför kulans riktiong med fiendens
            GetComponent<Collider>().enabled = false;
            if (dot <= 0)
            {
                anim.SetBool("killed", true);
                Destroy(gameObject, 3);
            }
            else
            {
                anim.SetBool("killedFromBehind", true);
                Destroy(gameObject, 2.3f);
            }
        }
    }
    public void Hit(float dot)
    {
        Animator anim = GetComponent<Animator>();
        if (dot <= 0)
        {

            anim.SetBool("killed", true);
            Destroy(gameObject, 3);
        }
        else
        {
            anim.SetBool("killedFromBehind", true);
            Destroy(gameObject, 2.3f);
        }
    }
}

