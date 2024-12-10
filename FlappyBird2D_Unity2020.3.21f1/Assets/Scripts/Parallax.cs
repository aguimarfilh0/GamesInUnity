using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initialSpeed = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.right * initialSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
