using UnityEngine;

public class crearenemigos : MonoBehaviour
{
    public float timeTiCreate = 5;
    public float currentTimetuCreate;

    void Update()
    {
        currentTimetuCreate = currentTimetuCreate + Time.deltaTime;
        if (currentTimetuCreate >= timeTiCreate)
        {
           /* ShootBullet1();*/


            currentTimetuCreate = 0;
        }

    }
   /* private void ShootBullet1()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = spawner1.position;
        bullet.transform.rotation = transform.rotation;
    }*/
}
