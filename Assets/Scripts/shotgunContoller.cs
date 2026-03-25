using Unity.VisualScripting;
using UnityEngine;

public class shotgunContoller : MonoBehaviour
{
    [SerializeField]
    GameObject ShotgunBulletprefab;
    public Transform spawnPoint;
    float timeBetwenShot = 0.1f;
    float timeSinceshot = 0.05f;
    Vector3 posOffset;
    float rotationffset;
    float rotationffset1;
    float rotationffset2;
  
    void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
    }

    public void Fire()
    {
        if (timeBetwenShot <= timeSinceshot)
        {
            for (int i = 0; i <= 9; i++)
            {

                // posOffset =  new Vector3 (Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                rotationffset = Random.Range(-15f, 15f);
                rotationffset1 = Random.Range(-15f, 15f);
                rotationffset2 = Random.Range(-15f, 15f);
                
                GameObject b = Instantiate(ShotgunBulletprefab, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(rotationffset, 180 + rotationffset1,rotationffset2)) ;

            }
            timeSinceshot = 0;
        }
    }

    void Update()
    {
        timeSinceshot += Time.deltaTime;
    }
}
