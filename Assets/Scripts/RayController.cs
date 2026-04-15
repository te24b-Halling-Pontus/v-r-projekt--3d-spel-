using UnityEngine;

public class RayController : MonoBehaviour
{
    public float distance;
 
    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, distance, transform.localScale.z);
        print("bra2");
        transform.Translate(0, 0, 0);
        Destroy(gameObject, 1);
    }
}