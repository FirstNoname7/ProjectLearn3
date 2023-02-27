using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class SpawnManager : MonoBehaviour
{
    private float _speed = 10;
    private PlayerController playerController;
    private Vector3 _spawnPos = new Vector3(20, 0, 0);
    public GameObject prefab;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", 1, 2);
    }

    void SpawnObstacle()
    {
        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
            Instantiate(prefab, _spawnPos, prefab.transform.rotation);
        }        
    }

}
