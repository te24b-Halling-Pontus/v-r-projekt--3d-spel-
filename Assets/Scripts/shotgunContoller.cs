using UnityEngine;

public class shotgunContoller : MonoBehaviour
{
    [SerializeField]
    GameObject Bulletprefab;
    Transform spawnPoint;
    float timeBetwenShot = 1;
    float timeSinceshot = 0.05f;
    void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
    }

    public void Fire()
    {
        timeSinceshot += Time.deltaTime;
        if (timeBetwenShot <= timeSinceshot)
        {
            GameObject b = Instantiate(Bulletprefab, spawnPoint.position, spawnPoint.rotation);
            timeSinceshot = 0;
        }
    }

    void Update()
    {
        Fire();
    }
}
