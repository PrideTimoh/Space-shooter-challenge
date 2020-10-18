using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

        public float moveSpeed;
        public GameObject bulletImpact;
        public bool hurtPlayer;

        // Start is called before the first frame update
        void Start () {

        }

        // Update is called once per frame
        void Update () {
            transform.position = new Vector3 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), 0);
        }

        void OnTriggerEnter2D (Collider2D other) {
            Instantiate (bulletImpact, transform.position, transform.rotation);
            Destroy (gameObject);

            if (other.gameObject.CompareTag ("Enemy1")) {
                Destroy (other.gameObject);
            }

            if (other.gameObject.CompareTag ("Player") && hurtPlayer)
            {
                    Destroy (other.gameObject);
                }
            }

            void OnBecameInvisible () {
                Destroy (gameObject);
            }
        }