using UnityEngine;
using UnityEngine.InputSystem;


public class weponScript : MonoBehaviour
{
    public int whichWepon = 0;

    GameObject shotgun;
    GameObject rightPistol;
    GameObject leftPistol;
    void Start()
    {

    }
    void OnAttack(InputValue value)
    {
        shotgunContoller shotgun = GetComponentInChildren<shotgunContoller>();
        shotgun.Fire();
    }
    public void OnScrollWheel(InputValue value)
    {
        Vector2 scroll = value.Get<Vector2>();
        if (whichWepon <= 2 && whichWepon >= 1)
        {
            whichWepon += (int)scroll.y;
        }
        if (whichWepon == 1)
        {
            
        }
        if (whichWepon == 2)
        {
            shotgu
        }
    }
}
