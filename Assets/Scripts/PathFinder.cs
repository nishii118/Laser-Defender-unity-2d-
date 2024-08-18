using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> wayspoints;
    int waypointsIndex = 0;

    private void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrenWave();
        wayspoints = waveConfig.getWaypoints();
        // waypointsIndex = 0;
        transform.position = wayspoints[waypointsIndex].position;
        // Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath() {
        if(waypointsIndex < wayspoints.Count) {
            Vector3 targetPosition = wayspoints[waypointsIndex].position;
            float delta = waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition) {
                waypointsIndex++;
            }
        } else {
            // Debug.Log("Destroy gameObject");
            Destroy(gameObject);
            // Debug.Log("Why");
        }
    }
}
