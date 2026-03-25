using UnityEngine;
public class ShotgunBulletController : MonoBehaviour
{
    [SerializeField]
    float speed;
    void Start()
    {
        Destroy(gameObject, 0.5f);
        GetComponent<Rigidbody>().AddForce(transform.forward * 1000 * speed);
    }
}
