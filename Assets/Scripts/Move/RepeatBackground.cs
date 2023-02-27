using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Move
{
    public class RepeatBackground : MonoBehaviour
    {
        private float _width = 50;
        private float _speed = 20;
        private Vector3 _startPos;
        private PlayerController playerController;

        void Start()
        {
            _startPos = transform.position;
            _width = GetComponent<BoxCollider>().size.x / 2;
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            if (!playerController.gameOver)
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }

            if (transform.position.x < _startPos.x - _width)
            {
                transform.position = _startPos;
            }
        }
    }
}

