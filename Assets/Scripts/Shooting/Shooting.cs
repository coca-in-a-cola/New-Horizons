using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    public SpaceshipController controller;

    Weapons weapons;
    public List<GameObject> bulletsPrefab;
    Queue<GameObject> bulletQueue;
    Queue<GameObject> missileQueue;
    float coolDown = 0f;
    float coolDownAlt = 0f;
    public float delay = 0.25f;

    private void Awake()
    {
        weapons = GetComponent<Weapons>();
        bulletQueue = new Queue<GameObject>();
        missileQueue = new Queue<GameObject>();
    }

    private void Update()
    {
        coolDown -= Time.deltaTime;
        coolDownAlt -= Time.deltaTime;
        if (controller.ShootingInput && coolDown <= 0)
        {
            coolDown = delay;
            weapons.Shoot(bulletsPrefab[0], bulletQueue);
        }
        
        if (controller.ShootingInputAlt && coolDownAlt <= 0)
        {
            coolDownAlt = delay;
            weapons.Shoot(bulletsPrefab[1], missileQueue);
        }
    }

    private void OnEnable()
    {
        // inputs.Enable();
    }

    private void OnDisable()
    {
        // inputs.Disable();
    }
}
