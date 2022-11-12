using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : SpaceshipController
{
    float accelerationInput;
    float steeringInput;

    
    [SerializeField]
    public Transform Target;
    public float angleTurnThreshold = 0.05f;
    public float angleGoThreshold = 20f;

    [System.Serializable]
    class DebugConfig
    {
        public bool enableDebug;
        public float directionVectorLength = 2;
    }

    [SerializeField]
    private DebugConfig debugConfig;


    public override float AccelerationInput
    {
        get => accelerationInput;
    }

    public override float SteeringInput
    {
        get => steeringInput;
    }

    private void FixedUpdate()
    {
        Vector3 dir = getDirectionToTarget();

        float angle = Vector3.SignedAngle(transform.forward, dir, Vector3.up);

        TurnToTarget(dir, angle);
        GoToTarget(dir, angle);
    }

    void TurnToTarget(Vector3 dir, float angle)
    {

        steeringInput = Mathf.Abs(angle) < angleTurnThreshold ? 0.0f
            : angle > 0 ? 1.0f : -1.0f;
    }

    void GoToTarget(Vector3 dir, float angle)
    {
        accelerationInput = Mathf.Abs(angle) > angleGoThreshold ? 0.0f
            : 1.0f;
    }

    private Vector3 getDirectionToTarget() 
        => Vector3.Normalize(Target.position - transform.position);

    
    void OnDrawGizmos()
    {
        if (!debugConfig.enableDebug)
            return;

        if (Target)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(Target.position, 3f);

            Gizmos.color = Color.red;
            Vector3 dir = getDirectionToTarget();


            Gizmos.DrawRay(transform.position, dir * debugConfig.directionVectorLength);
            Gizmos.DrawIcon(transform.position + dir * debugConfig.directionVectorLength, "arrow", true);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.forward * debugConfig.directionVectorLength);
        }
    }
}
