using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float TimeToSpawnNewEnemy;

    [SerializeField] private GameObject[] Enemys;

    private void Start()
    {
        StartCoroutine(SpawnLowEnemyCoroutine());
        StartCoroutine(SpawnHighEnemyCoroutine());
    }

    private IEnumerator SpawnHighEnemyCoroutine()
    {
        new WaitForSeconds(TimeToSpawnNewEnemy);

        for (int i = 0; i < Enemys.Length; i++)
        {
            int randomEnemyInArray = Random.Range(0, Enemys.Length);
            Instantiate(Enemys[randomEnemyInArray]);
        }
        yield break;
    }

    private IEnumerator SpawnLowEnemyCoroutine()
    {
        new WaitForSeconds(TimeToSpawnNewEnemy);

        for (int i = 0; i < Enemys.Length; i++)
        {
            int randomEnemyInArray = Random.Range(0, Enemys.Length);
            Instantiate(Enemys[randomEnemyInArray]);
        }
        yield break;
    }


}