using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField]
    public SpaceshipController controller;

    [SerializeField]
    private float accelerationFactor;
    [SerializeField]
    private float turnFactor;

    float rotationAngle;

    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
    }

    void ApplyEngineForce()
    {
        Vector3 engineForceVector = transform.forward * controller.AccelerationInput * accelerationFactor;
        rigidbody.AddForce(engineForceVector, ForceMode.Force);
    }

    void ApplySteering()
    {
        rotationAngle -= controller.SteeringInput * turnFactor;
        rigidbody.MoveRotation(Quaternion.Euler(0, -rotationAngle, 0));
    }
}
