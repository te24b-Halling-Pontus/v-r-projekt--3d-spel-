using UnityEngine;
using UnityEngine.InputSystem;

public class weponScript : MonoBehaviour
{

    int whichWepon = 1;
    [SerializeField]
    GameObject shotgun;
    [SerializeField]
    GameObject rightPistol;
    [SerializeField]
    GameObject leftPistol;
    void Start()
    {
        leftPistol.SetActive(false);
        rightPistol.SetActive(false);
    }
    void OnAttack(InputValue value)
    {
        shotgunContoller shotgun = GetComponentInChildren<shotgunContoller>();
        shotgun.Fire();

        // pistolController pistol = GetComponentInChildren<pistolController>();
        // pistol.Fire();
    }
    public void OnScrollWheel(InputValue value)
    {
        Vector2 scroll = value.Get<Vector2>();
        if (whichWepon <= 3 && (int)scroll.y < 0 && whichWepon > 1)
        {
            whichWepon += (int)scroll.y;
        }
        else if (whichWepon >= 1 && (int)scroll.y > 0 && whichWepon < 3)
        {
            whichWepon += (int)scroll.y;
        }

        if (whichWepon == 1)
        {
            leftPistol.SetActive(false);
            rightPistol.SetActive(false);
            shotgun.SetActive(true);
        }
        else if (whichWepon == 2)
        {
            shotgun.SetActive(false);
            leftPistol.SetActive(true);
            rightPistol.SetActive(true);
        }
    }
}
