using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SpaceshipController
{
    InputHandler inputs;

    float accelerationInput;
    float steeringInput;

    bool shootingInput;
    bool shootingInputAlt;

    public override float AccelerationInput
    {
        get => accelerationInput;
    }

    public override float SteeringInput
    {
        get => steeringInput;
    }

    public override bool ShootingInput
    {
        get => shootingInput;
    }
    public override bool ShootingInputAlt
    {
        get => shootingInputAlt;
    }

    private void Awake()
    {
        inputs = new InputHandler();
    }

    private void FixedUpdate()
    {
        SetInputVector();
        SetShooting();
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
        accelerationInput = dir.y;
    }

    void SetShooting()
    {
        shootingInput = inputs.Player.ShootBullet.inProgress;
        shootingInputAlt = inputs.Player.ShootMissile.inProgress;
    }
}
