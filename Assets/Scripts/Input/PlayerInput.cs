using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    InputHandler inputs;
 
    [SerializeField]
    private float accelerationFactor;
    [SerializeField]
    private float turnFactor;

    float accelerationInput;
    float steeringInput;

    float rotationAngle;

    Rigidbody rigidbody;

    private void Awake()
    {
        inputs = new InputHandler();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        SetInputVector();
        ApplyEngineForce();
        ApplySteering();
    }

    private void OnEnable()
    {
        inputs.Enable();

    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    void ApplyEngineForce()
    {
        if (accelerationInput == 0)
            rigidbody.drag = Mathf.Lerp(rigidbody.drag, 2f, Time.fixedDeltaTime * 2f);
        else
            rigidbody.drag = 0;

        Vector3 engineForceVector = transform.forward * accelerationInput * accelerationFactor;
        rigidbody.AddForce(engineForceVector, ForceMode.Force);
    }

    void ApplySteering()
    {
        rotationAngle -= steeringInput * turnFactor;
        rigidbody.MoveRotation(Quaternion.Euler(0, -rotationAngle, 0));
    }

    void SetInputVector()
    {
        Vector2 dir = inputs.Player.Movement.ReadValue<Vector2>();
        steeringInput = dir.x;
        accelerationInput = dir.y;
    }
}
