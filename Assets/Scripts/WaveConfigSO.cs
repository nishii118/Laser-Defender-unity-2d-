using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Way Config", menuName = "Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float moveSpeed;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0.5f;
    [SerializeField] float miniumSpawnTime = 0.2f;

    public Transform PathPrefabs
    {
        get { return pathPrefabs; }
        set { pathPrefabs = value; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    void Start()
    {
        MoveSpeed = 5f;
    }

    void Update()
    {

    }
    public Transform GetStartingWayPoint()
    {
        return pathPrefabs.GetChild(0);
    }

    public List<Transform> getWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform t in PathPrefabs)
        {
            waypoints.Add(t);
        }
        return waypoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime() {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, miniumSpawnTime, float.MaxValue);
    }
}
