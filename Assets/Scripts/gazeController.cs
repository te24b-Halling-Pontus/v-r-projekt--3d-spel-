using UnityEngine;

public class gazeController : MonoBehaviour
{

    Camera head;
    void Start()
    {
        head = GetComponentInChildren<Camera>();
    }
    void OnInteract()
    {
        RaycastHit hit;

        if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 10))
        {
            hit.transform.SendMessage("Press", SendMessageOptions.DontRequireReceiver);
        }
    } 
}
