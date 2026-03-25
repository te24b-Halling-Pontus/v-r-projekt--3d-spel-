using UnityEngine;
public class bulletController : MonoBehaviour
{
    [SerializeField]
    float speed;
    void Start()
    {
        Destroy(gameObject, 5);
        GetComponent<Rigidbody>().AddForce(transform.forward * 1000 * speed);
    }
}
