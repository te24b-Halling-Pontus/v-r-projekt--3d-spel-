using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Principal;
using UnityEngine;

public class simpelEnemyController : MonoBehaviour
{

    CharacterController controller;
    float gravityMuilt = 2;
    float velocetyY = 0;
    float timeIdle = 0;
    int actionNumber = 0;
    float duration = 1.5f;
    float durationTime = 0;
    bool RotationDone = false;
    int movementSpeed = 4;
    float angel;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = GetComponent<Animator>();

        velocetyY += Physics.gravity.y * gravityMuilt * Time.deltaTime;

        if (controller.isGrounded && velocetyY < 0)
        {
            velocetyY = -1;
        }
        Vector3 movement = transform.forward * 0 + transform.right * 0;
        movement.y = velocetyY;

        timeIdle += Time.deltaTime;
        if (timeIdle >= 10)
        {
            actionNumber = Random.Range(1, 3);
            if (actionNumber == 2)
            {
                angel = Random.Range(60, 300);
                anim.SetBool("dancing", false);
                anim.SetBool("moving", true);
                RotationDone = false;
                durationTime = 0;
            }
            else
            {
                anim.SetBool("dancing", true);
                anim.SetBool("moving", false);
            }
            timeIdle = 0;
        }
        if (actionNumber == 2) { EnemyMover(); }
        if (GetComponent<CharacterController>().enabled) // kollar så den är aktive för anars krashar programet om den är inaktive, negativt är att den har ingen gravitation under döts animationen
        {
            controller.Move(movement * Time.deltaTime);
        }
    }
    void EnemyMover()
    {
        if (RotationDone)
        {
            Vector3 movment = transform.forward * movementSpeed * Time.deltaTime;
            controller.Move(movment);
        }
        else
        {
            if (duration > durationTime)
            {
                durationTime += Time.deltaTime;
                float step = ((angel / duration) * Time.deltaTime);
                transform.Rotate(Vector3.up, step);
            }
            else
            {
                RotationDone = true;
            }
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Animator anim = GetComponent<Animator>(); // hämtar animatioen, så man kan ändra des värden
            Vector3 shotDiraction = collision.gameObject.transform.forward; // hämtar  riktningen från skottet
            float dot = Vector3.Dot(transform.forward, shotDiraction); // jämför kulans riktiong med fiendens
            KillDiraction(dot);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border") // stopar den från att gå över kanten
        {
            durationTime = 0;
            angel += 180;
            timeIdle = 0;
            RotationDone = false;
        }
    }
    public void KillDiraction(float dot)
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
        GetComponent<Collider>().enabled = false;
    }
}

