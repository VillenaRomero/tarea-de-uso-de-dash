using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    #region References
    public Transform PlayerSpawnPoint;
    public playermoved PlayerPrefab;

    public playermoved currentPlayer;

    public List<EnemySpawner> spawners = new List<EnemySpawner>();
    #endregion
    #region Getters
    public playermoved CurrentPlayer => currentPlayer;
    #endregion
    public static int Score = 0;

    void Start()
    {
        SetPlayer();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetPlayer()
    {
        currentPlayer = Instantiate(PlayerPrefab);

        currentPlayer.transform.position = PlayerSpawnPoint.position;


        SetSpawners();
    }
    private void SetSpawners()
    {
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.SetSpawner(currentPlayer);
        }
    }

}
