using UnityEngine;

public class gazeController : MonoBehaviour
{

    Camera head;
    void Start()
    {
        head = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnInteract()
    {
        RaycastHit hit;

        if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 10))
        {
            print(hit.transform.name);
            hit.transform.SendMessage("Press", SendMessageOptions.DontRequireReceiver);
        }
    } 
}
