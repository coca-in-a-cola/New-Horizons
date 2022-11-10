using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    /// <summary>
    /// Weapon
    /// This class implements a weapon system.
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        [Header("Bullet prafab")]
        [SerializeField]
        Bullet prefabBullet;

        [Header("Interval between each fire")]
        [SerializeField]
        float interval = 1f;

        [Header("Bullet speed")]
        [SerializeField]
        float speed = 40.0f;

        [Header("Fire direction")]
        [SerializeField]
        Vector3 direction = new Vector3(0, 0, 1);

        [Header("Fire to player or not")]
        // If this sets true, bullets will be shoot towards to player.
        // If this sets false, it will be use the direction variable above.
        [SerializeField]
        bool toPlayer = false;

        [Header("Missile")]
        // If this sets true, bullets will be shoot towards to enemies.
        [SerializeField]
        bool isMissile = false;

    InputHandler inputs;

    private void Awake()
    {
        inputs = new InputHandler();
    }



    private void OnEnable()
        {
            //StartCoroutine(FireLoop());
        inputs.Enable();
        inputs.Player.Shoot.started += ctx => StartCoroutine(FireLoop());
        inputs.Player.Shoot.performed += ctx => StartCoroutine(FireLoop());
        inputs.Player.Shoot.canceled += ctx => StartCoroutine(FireLoop());

    }

    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Shoot.started -= ctx => StartCoroutine(FireLoop());
        inputs.Player.Shoot.performed -= ctx => StartCoroutine(FireLoop());
        inputs.Player.Shoot.canceled -= ctx => StartCoroutine(FireLoop());
    }

    IEnumerator FireLoop()
        {
            GameObject player = GameObject.Find("Player");
        Debug.Log(inputs.Player.Shoot.activeControl.name);
        while (inputs.Player.Shoot.IsPressed())
        {
            yield return new WaitForSeconds(this.interval);

            // Instantiate a bullet, position.
            Bullet bullet = GameObject.Instantiate(this.prefabBullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            // Set bullet properties.
            bullet.SetDirection(transform.forward);
            bullet.SetSpeed(this.speed);

            // Calculate fire direction.
            if (this.toPlayer)
            {
                if (player != null)
                {
                    this.direction = (player.transform.position - transform.position).normalized;
                    bullet.transform.rotation = Quaternion.LookRotation(this.direction);
                    bullet.SetDirection(this.direction);
                }
            }

            // Missile.
            if (this.isMissile)
            {
                bullet.SetFollowTarget();
            }
        }
        }
    }

