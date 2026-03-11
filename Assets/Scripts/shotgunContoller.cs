using UnityEngine;

public class shotgunContoller : MonoBehaviour
{
    [SerializeField]
    GameObject Bulletprefab;
    public Transform spawnPoint;
    float timeBetwenShot = 0.1f;
    float timeSinceshot = 0.05f;
    void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
    }

    public void Fire()
    {
        if (timeBetwenShot <= timeSinceshot)
        {
            GameObject b = Instantiate(Bulletprefab, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0,180,0));
            timeSinceshot = 0;
        }
    }

    void Update()
    {
        timeSinceshot += Time.deltaTime;
    }
}
