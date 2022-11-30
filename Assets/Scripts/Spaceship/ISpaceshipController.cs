using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpaceshipController
{
    float AccelerationInput { get; }
    float SteeringInput { get; }

    bool ShootInput { get; }
}