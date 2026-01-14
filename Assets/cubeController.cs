using UnityEngine;

public class cubeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] cylinders = GameObject.FindGameObjectsWithTag("Cylinder");
        for (int i = 0; i < cylinders.Length; i++)
        {
            Renderer renderer = cylinders[i].GetComponent<Renderer>();
            renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
