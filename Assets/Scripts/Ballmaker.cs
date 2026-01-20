using UnityEngine;

public class Ballmaker : MonoBehaviour
{
    [SerializeField]
    GameObject ball;
    void Update()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(ball);
        }
    }
}
