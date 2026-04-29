
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class weponScript : MonoBehaviour
{

    public int whichWepon = 1;
    [SerializeField]
    GameObject shotgun;
    [SerializeField]
    GameObject rightPistol;
    [SerializeField]
    GameObject leftPistol;
    [SerializeField]
    GameObject rayGun;
    bool mouseIsDown = false;
    int timeToWait = 2;
    float timeWaited;
    void Start()
    {
        leftPistol.SetActive(false);
        rightPistol.SetActive(false);
        rayGun.SetActive(false);
    }
    void Update()
    {
        // if (mouseIsDown)
        // {
        //     timeWaited += Time.deltaTime;
        //     if (timeWaited > timeToWait)
        //     {
        //         RaygunController rayGun = GetComponentInChildren<RaygunController>();
        //         rayGun.Fire();
        //         timeToWait = 0;
        //     }
        // }
        // else if (!mouseIsDown)
        // {
        //     timeWaited = 0;
        // }
    }
    void OnAttack(InputValue value)
    {
        switch (whichWepon)
        {
            case 1:
                shotgunContoller shotgun = GetComponentInChildren<shotgunContoller>();
                shotgun.Fire();
                break;
            case 2:
                pistolController pistol = GetComponentInChildren<pistolController>();
                pistol.Fire();
                break;
            case 3:
                mouseIsDown = true;
                break;
        }
    }
    void OnMouseHoldingDown(InputValue value)
    {
        if (whichWepon == 3)
        {
            RaygunController rayGun = GetComponentInChildren<RaygunController>();
            rayGun.Fire(); 
        }
    }
    public void OnScrollWheel(InputValue value)
    {
        Vector2 scroll = value.Get<Vector2>();
        if ((int)scroll.y < 0)
        {
            if (whichWepon > 1)
            {
                whichWepon--;
            }
            else
            {
                whichWepon = 3;
            }
        }
        else if ((int)scroll.y > 0)
        {
            if (whichWepon < 3)
            {
                whichWepon++;
                print("hej");
            }
            else
            {
                print("gå");
                whichWepon = 1;
            }
        }

        switch (whichWepon)
        {
            case 1:
                leftPistol.SetActive(false);
                rightPistol.SetActive(false);
                shotgun.SetActive(true);
                rayGun.SetActive(false);
                break;
            case 2:
                shotgun.SetActive(false);
                leftPistol.SetActive(true);
                rightPistol.SetActive(true);
                rayGun.SetActive(false);
                break;
            case 3:
                shotgun.SetActive(false);
                leftPistol.SetActive(false);
                rightPistol.SetActive(false);
                rayGun.SetActive(true);
                break;
        }

    }
}
