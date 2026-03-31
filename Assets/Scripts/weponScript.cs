
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
    void Start()
    {
        leftPistol.SetActive(false);
        rightPistol.SetActive(false);
        rayGun.SetActive(false);
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
                RaygunController rayGun = GetComponentInChildren<RaygunController>();
                rayGun.Fire();
                break;
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
            if (whichWepon <= 3)
            {
                whichWepon++;
            }
            else
            {
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
