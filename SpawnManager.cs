using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    private float spawnRange = 9;
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPoint(), powerupPrefab.transform.rotation);
        SpawnEnemeyWave(waveNumber);
    }

    
    void Update()
    {
        //Enemy Spawn sistemi
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemeyWave(waveNumber);
        }

        //Powerup Spawn sistemi (Düşman saısı 0' a inince yeni bir tane spawn olur)
        if(enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPoint(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPoint()
    {
        //Enemy objesinin random spawn olacağı aralıkları belirtiyoruz.
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);   
        //Enemy objesinin spawn olacağı pozisyonu belirtiyoruz.
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemeyWave(int enemiesToSpawn)
    {
        for(int i = 0; i <enemiesToSpawn; i++) 
        {
            //Spawn olması için gerekli komut.
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }
}
