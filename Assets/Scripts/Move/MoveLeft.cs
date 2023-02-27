using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Move
{
    public class MoveLeft : MonoBehaviour
    {
        private float _speed = 20;
        private PlayerController playerController;
        private int _leftBound = -15;

        void Start()
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }
        void Update()
        {
            if (playerController.gameOver == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }

            if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }

        }
    }
}

