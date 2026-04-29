using UnityEngine;

public class RayController : MonoBehaviour
{
    public float distance;
 
    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, distance / 2, transform.localScale.z);
        transform.Translate(0, distance / 2, 0);
        Destroy(gameObject, 0.5f);
    }
}