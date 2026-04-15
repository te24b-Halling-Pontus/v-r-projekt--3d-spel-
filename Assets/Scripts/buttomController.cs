using UnityEngine;

public class buttomController : MonoBehaviour
{
    [SerializeField]
    GameObject ennemy;
    public void Press()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-50f, 50f), 10, Random.Range(-50f, 50f));
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
