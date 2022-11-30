using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spaceship : MonoBehaviour
{
    [SerializeField]
    public SpaceshipController controller;

    [SerializeField, Range(0f, 1f)]
    private float controllerInputEpsilon = 0.1f;


    /// <summary>
    /// Movement settings for spaceship
    /// </summary>
    [System.Serializable]
    class Movement
    {
        /// <summary>
        /// Movement speed settings
        /// </summary>
        [System.Serializable]
        public class Speed
        {
            [Range(0f, 5000f)]
            public float thrust = 2000f;

            [Range(0f, 3000f)]
            public float turn = 1000f;
        }

        [SerializeField]
        public Speed speed;

        [SerializeField, Range(0f, 1f)]
        public float thrustReduction = 0.95f;
    }

    [SerializeField]
    private Movement movement;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
    }

    void ApplyEngineForce()
    {
        if (Mathf.Abs(controller.AccelerationInput) > controllerInputEpsilon)
        {
            // We have input
            Vector3 engineForceVector = Vector3.forward  * movement.speed.thrust 
                * controller.AccelerationInput * Time.deltaTime;
            rb.AddRelativeForce(engineForceVector);
        }
    }

    void ApplySteering()
    {
        if (Mathf.Abs(controller.SteeringInput) > controllerInputEpsilon)
        {
            Vector3 engineTorqueVector = Vector3.up * controller.SteeringInput 
                * movement.speed.turn * Time.deltaTime;
            rb.AddRelativeTorque(engineTorqueVector);
        }
    }
}
