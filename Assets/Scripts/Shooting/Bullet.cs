using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody rb;

    [SerializeField]
    private float speed = 100;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 dir, Quaternion rot)
    {
        startPosition = transform.position;
        rb.velocity = dir * speed;
        transform.localRotation = rot;
    }

    private void Update()
    {
        CheckArea();
    }

    void CheckArea()
    {
        Vector3 point = Camera.main.WorldToViewportPoint(transform.position);
        if (point.y < 0.1f || point.y > 0.9f || point.x > 0.9f || point.x < 0.1f)
        {
            gameObject.SetActive(false);
        }
    }
}
