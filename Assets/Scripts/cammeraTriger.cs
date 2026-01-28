using UnityEngine;

public class cammeraTriger : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    void OnTriggerEnter(Collider other)
    {
        GameObject[] = GameObject.FindGameObjectsWithTag("mainCamera");
    }
}
