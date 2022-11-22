using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarDespawner : MonoBehaviour
{
    Transform player;
    float yDistanceFromPlayer {get => player.position.y - transform.position.y;}
    [SerializeField] float despawnDistance = 10f;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(yDistanceFromPlayer > despawnDistance) {
            Destroy(gameObject);
        }
    }
}
