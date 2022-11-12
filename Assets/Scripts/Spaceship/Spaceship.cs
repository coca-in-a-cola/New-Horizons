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
        if (controller.AccelerationInput == 0)
            rigidbody.drag = Mathf.Lerp(rigidbody.drag, 2f, Time.fixedDeltaTime * 2f);
        else
            rigidbody.drag = 0;

        Vector3 engineForceVector = transform.forward * controller.AccelerationInput * accelerationFactor;
        rigidbody.AddForce(engineForceVector, ForceMode.Force);
    }

    void ApplySteering()
    {
        rotationAngle -= controller.SteeringInput * turnFactor;
        rigidbody.MoveRotation(Quaternion.Euler(0, -rotationAngle, 0));
    }
}
