using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour {
    private Rigidbody2D theRB;
    public float rotateSpeed;
    public float moveSpeedX;
    public float moveSpeedY;

    // Start is called before the first frame update
    void Start () {
        theRB = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {
        theRB.velocity = new Vector2 (moveSpeedX,moveSpeedY);
        transform.rotation = Quaternion.Euler (0, 0, transform.rotation.eulerAngles.z + (Random.Range (rotateSpeed / 2, rotateSpeed) * Time.deltaTime));
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}