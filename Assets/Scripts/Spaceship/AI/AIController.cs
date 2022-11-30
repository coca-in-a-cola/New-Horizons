using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : SpaceshipController
{
    /******************
     * HELPER CLASSES *
     ******************/
    [System.Serializable]
    class DebugConfig
    {
        public bool drawGizmos;
        public float directionVectorLength = 2;
    }

    class AIBehavior
    {

    }
     

    /***********************
     * INSPECTOR VARIABLES *  
     ***********************/
    [SerializeField]
    private DebugConfig debugConfig;

    [SerializeField]
    private Transform InitialTarget;

    [SerializeField]
    private float angleGoThreshold = 20f;


    /******************
     * PRIVATE FIELDS *
     ******************/
    private Transform target;
    private float accelerationInput;
    private float steeringInput;


    /**************
     * PROPERTIES *
     **************/
    public override float AccelerationInput
    {
        get => accelerationInput;
    }

    public override float SteeringInput
    {
        get => steeringInput;
    }

    /*******************
     * UNITY GAME LOOP *
     *******************/
    private void FixedUpdate()
    {
        Vector3 dir = getDirectionToTarget();

        float angle = Vector3.SignedAngle(transform.forward, dir, Vector3.up);

        TurnToTarget(dir, angle);
        ThrustToTerget(dir, angle);
    }

    void GoToTarget(Vector3 dir, float angle) { 
        TurnToTarget(dir, angle);
        ThrustToTerget(dir, angle);
    }

    void TurnToTarget(Vector3 dir, float angle)
    {
        float sign = angle > 0 ? 1.0f : -1.0f;
        float value = Mathf.Clamp01(angle * angle * Time.deltaTime);

        steeringInput =  sign *value;
    }

    void ThrustToTerget(Vector3 dir, float angle)
    {
        accelerationInput = Mathf.Abs(angle) > angleGoThreshold ? 0.0f
            : 1.0f;
    }

    private Vector3 getDirectionToTarget() 
        => Vector3.Normalize(InitialTarget.position - transform.position);

    
    void OnDrawGizmos()
    {
        if (!debugConfig.drawGizmos)
            return;

        if (InitialTarget)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(InitialTarget.position, 3f);

            Gizmos.color = Color.red;
            Vector3 dir = getDirectionToTarget();


            Gizmos.DrawRay(transform.position, dir * debugConfig.directionVectorLength);
            Gizmos.DrawIcon(transform.position + dir * debugConfig.directionVectorLength, "arrow", true);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.forward * debugConfig.directionVectorLength);
        }
    }
}
