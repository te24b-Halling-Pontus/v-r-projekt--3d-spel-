using UnityEngine;

public class buttomController : MonoBehaviour
{
    [SerializeField]
    GameObject ennemy;
    public void Press()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 10, Random.Range(-10f, 10f));
            Quaternion rotation = Quaternion.identity;

            Instantiate(ennemy, spawnPos, rotation);
        }
        GetComponent<Renderer>().material.color = Color.coral;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
