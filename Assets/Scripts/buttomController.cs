using UnityEditor;
using UnityEngine;

public class buttomController : MonoBehaviour
{
    [SerializeField]
    GameObject ennemy;
    public void Press()
    {
        Vector3 spawnPos = new Vector3(0, 10, 0);
        Quaternion rotation = Quaternion.identity;

    
        Instantiate(ennemy, spawnPos, rotation);
        GetComponent<Renderer>().material.color = Color.coral;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
