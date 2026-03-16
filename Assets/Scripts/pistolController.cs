using UnityEngine;

public class pistolController : MonoBehaviour
{
    [SerializeField]
    GameObject pistolBulletPrefab;
    public Transform bulletSpawnPoint;
    void Start()
    {
        bulletSpawnPoint = transform.GetChild(0).transform;
    }
    public void Fire()
    {
        GameObject b = Instantiate(pistolBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation * Quaternion.Euler(0,180,0));
    }
    void Update()
    {
        
    }
}
