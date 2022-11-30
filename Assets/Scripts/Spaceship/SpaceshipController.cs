using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceshipController : MonoBehaviour, ISpaceshipController
{
    public virtual float AccelerationInput
    {
        get => 0.0f;
    }
    public virtual float SteeringInput
    {
        get => 0.0f;
    }
    
    public virtual bool ShootInput
    {
        get => false;
    }
}
