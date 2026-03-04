using UnityEngine;

public class buttomController : MonoBehaviour
{
    public void Press()
    {
        print("nice");
        GetComponent<Renderer>().material.color = Color.coral;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
