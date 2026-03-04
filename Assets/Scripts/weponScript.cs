using UnityEngine;

public class weponScript : MonoBehaviour
{
    void Start()
    {

    }
    void OnAttack()
    {
        shotgunContoller shotgun = GetComponentInChildren<shotgunContoller>();

        shotgun.Fire();
    }
}
