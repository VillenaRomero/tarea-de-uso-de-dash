using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public BaseEnemy BaseEnemyPrefab;

    public Transform spawnPoint;
    public float spawnRate;
    public float spread;

    public playermoved Target;
    private List<BaseEnemy> enemys = new List<BaseEnemy>();
    public void SetSpawner(playermoved _target)
    {
        Target = _target;

        StartCoroutine(SpawnObjects());
    }
    void Start()
    {

    }
    void Update()
    {

    }
    private IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(spawnRate);

        BaseEnemy enemy = Instantiate(BaseEnemyPrefab, transform);
        //-TU LOGICA DE TU PERSONAJE
        enemy.Set(10, 10, Target.gameObject);

        //<-

        enemy.transform.position = ReturnRandomPos(spawnPoint, spread);
        enemys.Add(enemy);
        StartCoroutine(SpawnObjects());
    }

    private Vector3 ReturnRandomPos(Transform _origin, float _spread, bool randomY = true)
    {
        Vector3 randomPos = Vector3.zero;
        if (randomY)
        {
            randomPos = new Vector3(
                _origin.position.x + Random.Range(-_spread, _spread), 0, _origin.position.z + Random.Range(-_spread, _spread));
        }
        else
        {
            randomPos = new Vector3(
                _origin.position.x + Random.Range(-_spread, _spread),
                _origin.position.y + Random.Range(-_spread, _spread),
                _origin.position.z + Random.Range(-_spread, _spread));
        }


        return randomPos;
    }
    public void StopAll()
    {
        StopAllCoroutines();
        foreach (BaseEnemy enemy in enemys)
        {
            Destroy(enemy);
        }
        enemys.Clear();
    }

}


