using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        //то, что закомментировано - это доп. варик ограничения прыжка (тип если перс какое-то время находится в воздухе, то ему в течении времени прыжка нельзя повторно прыгать)
        public AudioClip jumpSound;
        public AudioSource playerAudio;
        public AudioClip boomSound;
        public ParticleSystem explosionParticle;

        private Rigidbody rigidBody;
        private float jumpForce = 10;
        public bool gameOver = false;
        private bool _onGrounded;
        //private bool _stopJump = false;

        private Animator playerAnim;

        void Start()
        {
            playerAnim = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _onGrounded && !gameOver)
            {
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                _onGrounded = false;
                playerAnim.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jumpSound);
            }
            //if (Input.GetKeyDown(KeyCode.Space) && !_stopJump && !gameOver)
            //{
            //    rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //    _onGrounded = false;
            //    playerAnim.SetTrigger("Jump_trig");
            //    playerAudio.PlayOneShot(jumpSound);
            //    StartCoroutine(StopJump());
            //}

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Game Over!");
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                playerAudio.PlayOneShot(boomSound);
            }

            if (collision.gameObject.CompareTag("Ground"))
            {
                _onGrounded = true;
            }
        }

        //IEnumerator StopJump()
        //{
        //    _stopJump = true;
        //    yield return new WaitForSeconds(2);
        //    _stopJump = false;
        //}

    }
}

