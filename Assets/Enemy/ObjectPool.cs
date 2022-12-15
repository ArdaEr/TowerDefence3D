using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTimer = 1;
    GameObject[] pool;

    private void Awake() 
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        foreach(GameObject _enemy in pool)
        {
            if(!_enemy.activeInHierarchy)
            {
                _enemy.SetActive(true);
                return;
            }
        }
    }
    IEnumerator EnemySpawner()
    {
        while(true)
        {
            //Instantiate(enemyPrefab, transform);
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
