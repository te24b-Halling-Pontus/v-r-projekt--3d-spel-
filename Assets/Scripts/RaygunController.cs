using UnityEngine;

public class RaygunController : MonoBehaviour
{
    Camera head;
    void Start()
    {
        head = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 1000))
        {
            hit.transform.SendMessage("Press", SendMessageOptions.DontRequireReceiver);
            hit.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);

        }
    }
}
