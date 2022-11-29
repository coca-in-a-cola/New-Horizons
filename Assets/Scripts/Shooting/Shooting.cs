using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    InputHandler inputs;
    Weapons weapons;
    public List<GameObject> bulletsPrefab;
    Queue<GameObject> bulletQueue;
    Queue<GameObject> missileQueue;
    float coolDown = 0;
    public float delay = 0.25f;

    private void Awake()
    {
        inputs = new InputHandler();
        weapons = GetComponent<Weapons>();
        bulletQueue = new Queue<GameObject>();
        missileQueue = new Queue<GameObject>();
    }

    private void Update()
    {
        coolDown -= Time.deltaTime;
        if(inputs.Player.ShootBullet.inProgress && coolDown <= 0)
        {
            coolDown = delay;
            weapons.Shoot(bulletsPrefab[0], bulletQueue);
        }
        
        if (inputs.Player.ShootMissile.inProgress && coolDown <= 0)
        {
            coolDown = delay;
            weapons.Shoot(bulletsPrefab[1], missileQueue);
        }
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
