using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCamera : MonoBehaviour
{
    [Header("Rocket Camera")]
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    [Space(10)]
    [SerializeField] private Transform target;

    private void FixedUpdate()
    {
        Vector3 cameraDistance = new Vector3(0, 0, -distance);

        transform.position = cameraDistance + Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }
}
