using UnityEngine;

public class pistolController : MonoBehaviour
{
    [SerializeField]
    GameObject pistolBulletPrefab;
    [SerializeField]
    public Transform bulletSpawnPointRight;
    [SerializeField]
    public Transform bulletSpawnPointLeft;
    bool rightsTurneToFire = true;

    public void Fire()
    {
        if (rightsTurneToFire)
        {
            GameObject b = Instantiate(pistolBulletPrefab, bulletSpawnPointRight.position, bulletSpawnPointRight.rotation * Quaternion.Euler(0, 1800, 0));
        }
        else if (!rightsTurneToFire)
        {
            GameObject t = Instantiate(pistolBulletPrefab, bulletSpawnPointLeft.position, bulletSpawnPointLeft.rotation * Quaternion.Euler(0, 1800, 0));
        }
        rightsTurneToFire = !rightsTurneToFire;
    }
}
