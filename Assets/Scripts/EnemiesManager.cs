using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] StageProgress stageProgress;
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    GameObject player;

    private void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;

    }

    public void SpawnEnemy(EnemyData enemyToSpawn)
    {
        Vector3 position = UtilityTools.GenerateRandomPositionSquarePatterns(spawnArea);

        position += player.transform.position;

        //spawning main enemy object
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.SetTarget(player);
        newEnemyComponent.SetStats(enemyToSpawn.stats);
        newEnemyComponent.UpdateStatsForProgress(stageProgress.Progress);
        newEnemy.transform.parent = transform;

        //spawning sprite object of the enemy
        GameObject spriteObject = Instantiate(enemyToSpawn.animatedPrefab);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = Vector3.zero;
    }


}
