using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SpaceshipController
{
    InputHandler inputs;

    float accelerationInput;
    float steeringInput;

    public override float AccelerationInput
    {
        get => accelerationInput;
    }

    public override float SteeringInput
    {
        get => steeringInput;
    }

    private void Awake()
    {
        inputs = new InputHandler();
    }

    private void FixedUpdate()
    {
        SetInputVector();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    void SetInputVector()
    {
        Vector2 dir = inputs.Player.Movement.ReadValue<Vector2>();
        steeringInput = dir.x;
        Debug.Log(steeringInput);
        accelerationInput = dir.y;
    }
}
