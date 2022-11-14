using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    InputHandler inputs;
    Weapons weapons;
    float coolDown = 0;
    public float delay = 0.25f;

    private void Awake()
    {
        inputs = new InputHandler();
        weapons = GetComponent<Weapons>();
    }

    private void Update()
    {
        coolDown -= Time.deltaTime;
        if(inputs.Player.ShootBullet.inProgress && coolDown <= 0)
        {
            coolDown = delay;
            weapons.ShootBullets();
        }
        
        if (inputs.Player.ShootMissile.inProgress && coolDown <= 0)
        {
            coolDown = delay;
            weapons.ShootMissiles();
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
