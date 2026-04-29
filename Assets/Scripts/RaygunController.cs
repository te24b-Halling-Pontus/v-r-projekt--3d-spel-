
using UnityEngine;

public class RaygunController : MonoBehaviour
{
    Camera head;
    [SerializeField]
    GameObject ray;
    Transform spawnPoint;
    public float distance;
    void Start()
    {
        head = GetComponentInParent<Camera>();
        spawnPoint = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Fire()
    {
        RaycastHit[] hits = Physics.RaycastAll(head.transform.position, head.transform.forward, 1000);
        foreach (RaycastHit hit in hits)
        {
            float dot = Vector3.Dot(head.transform.forward, hit.transform.forward);
            hit.transform.SendMessage("Press", SendMessageOptions.DontRequireReceiver);
            hit.transform.SendMessage("Hit", dot, SendMessageOptions.DontRequireReceiver);
        }
        if (hits.Length < 1)
        {
            distance = 100;
        }
        else
        {
            distance = hits[hits.Length - 1].distance;
        }

        GameObject rayObject = Instantiate(ray, spawnPoint.position, spawnPoint.rotation * UnityEngine.Quaternion.Euler(90, 90, 90));
        rayObject.GetComponent<RayController>().distance = distance;
    }
}
