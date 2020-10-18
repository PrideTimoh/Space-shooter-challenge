using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D theRB;
    public float moveSpeed;
    private Vector2 moveInput;
    public Transform topRight;
    public Transform bottomLeft;
    private Animator anim;
    public GameObject bullet;
    public Transform bulletPoint;
    public float shotDelay;
    private float shotCounter;

    // Start is called before the first frame update
    void Start () {
        theRB = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {
        moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

        theRB.velocity = moveInput * moveSpeed;

        transform.position = new Vector3 (Mathf.Clamp (transform.position.x, bottomLeft.position.x, topRight.position.x), Mathf.Clamp (transform.position.y, bottomLeft.position.y, topRight.position.y), transform.position.z);
        anim.SetFloat ("Movement", moveInput.x);

        if (Input.GetButtonDown ("Fire1")) {
            Instantiate (bullet, bulletPoint.position, bulletPoint.rotation);
            shotCounter = shotDelay;
        }

        if (Input.GetButton("Fire1")) {
             shotCounter -= Time.deltaTime;

             if(shotCounter <= 0)
             {
                 Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
                 shotCounter = shotDelay;
             }
        }
    }
}