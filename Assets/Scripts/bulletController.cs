using UnityEngine;

public class bulletController : MonoBehaviour
{
    [SerializeField]
    float speed;
    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }
}
