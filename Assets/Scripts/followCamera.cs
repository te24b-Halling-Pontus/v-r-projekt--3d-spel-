using UnityEngine;

public class followCamera : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
