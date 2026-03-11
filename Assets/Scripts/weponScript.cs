using UnityEngine;
using UnityEngine.InputSystem;

public class weponScript : MonoBehaviour
{
    void Start()
    {

    }
    void OnAttack(InputValue value)
    {
        shotgunContoller shotgun = GetComponentInChildren<shotgunContoller>();

        shotgun.Fire();
    }
}
