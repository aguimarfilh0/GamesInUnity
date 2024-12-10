using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
{
    public GameObject GameOver;
    
    public Rigidbody2D rb;
    public float force;
    public Vector3 direction = new Vector3(0,1,0);

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(direction * force);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
             rb.AddForce(direction * force);
        }

    }
    void OnCollisionEnter2D(Collision2D colisor)
    {
       GameOver.SetActive(true);
       Time.timeScale = 0;
    }
}
