using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    //public List<GameObject> _seekers;
    public List<GameObject> _enemies;
    public GameObject _player;
    public bool chase;
    public Transform[] _spawnArea;
    public bool _startSpawn;
    public GameObject _enemyPrefab;

    private void Start()
    {
        chase = true;
        _startSpawn = true;
    }

    private void Update()
    {
        if (_startSpawn)
        {
            _startSpawn = false;
            StartCoroutine(CO_SpawnEnemy());
        }
    }

    private IEnumerator CO_SpawnEnemy()
    {
        int i = Random.Range(0, 4);
        GameObject enemy = Instantiate(_enemyPrefab, _spawnArea[i].position, Quaternion.identity);
        enemy.GetComponent<AIControl>()._player = _player;
        enemy.GetComponent<AIControl>()._origin = _spawnArea[i].transform;
        enemy.GetComponent<AIControl>()._aM = this;
        _enemies.Add(enemy);
        yield return new WaitForSeconds(8);
        StartCoroutine(CO_SpawnEnemy());
    }
}
