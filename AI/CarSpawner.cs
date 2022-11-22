using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] float roadWidth, distanceFromPlayer;
    [SerializeField] int laneCount, carsPerWave;
    [SerializeField] float yRange = 5;

    [SerializeField] GameObject carPrefab;
    [SerializeField] Transform player;
    GameObject leadingCar;
    Vector2[] spawnPoints;

    private void Awake() {
        spawnPoints = new Vector2[laneCount];
        for(int i = 0; i < laneCount; i++) {
            spawnPoints[i] = new Vector2(transform.position.x + (roadWidth / laneCount) * i - roadWidth / 2 + (roadWidth / laneCount) / 2, 0);
        }
        SpawnWave();
    }
    
    private void Update() {
        if(leadingCar.transform.position.y < player.position.y) {
            SpawnWave();
        }
    }
    void SpawnWave() {
        bool[] lanes = new bool[laneCount];
        int carsLeft = carsPerWave;
        GameObject frontMostCar = null;
        while(carsLeft > 0) {
            int lane = Random.Range(0, laneCount);
            if(!lanes[lane]) {
                lanes[lane] = true;
                carsLeft--;
                float randomYOffset = Random.Range(-yRange / 2, yRange / 2);
                Vector2 spawnPosition = spawnPoints[lane] + Vector2.up * (randomYOffset + distanceFromPlayer + player.position.y);
                GameObject car = Instantiate(carPrefab, spawnPosition, Quaternion.identity);
                if(frontMostCar == null || car.transform.position.y > frontMostCar.transform.position.y) {
                    frontMostCar = car;
                }
            }
        }
        leadingCar = frontMostCar;
    }


}
