using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontos : MonoBehaviour
{
    public ControladorJogo controller;
    
    void Start()
    {
        controller = FindObjectOfType<ControladorJogo>();
    }
    
    void OnTriggerEnter2D(Collider2D colisor)
    {
        controller.Score++;
        controller.scoreText.text = controller.Score.ToString();
    }
}
