using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    InputHandler inputs;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    private void Awake()
    {
        inputs = new InputHandler();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        inputs.Player.Movement.Enable();

    }

    private void OnDisable()
    {
        inputs.Player.Movement.Disable();

    }

    private void Move()
    {
        Vector2 dir = inputs.Player.Movement.ReadValue<Vector2>();
        transform.Translate(new Vector3(0, 0, dir.y) * moveSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(0, dir.x * rotationSpeed * Time.deltaTime, 0, Space.Self);
    }

    
}
