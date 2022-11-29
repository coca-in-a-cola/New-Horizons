using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapons : MonoBehaviour
{
    public List<Transform> barrels;
    [SerializeField]
    private int bulletPoolCount = 10;

    private PlayerInput playerInput;
    private ObjectPool bulletPool;


    private void Awake()
    {
        bulletPool = GetComponent<ObjectPool>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        bulletPool.Initialize(bulletPoolCount);
    }

    public void Shoot(GameObject bulletPrefab, Queue<GameObject> bullets)
    {
        foreach (var barrel in barrels)
            {
                GameObject bullet = bulletPool.CreateObject(bulletPrefab, bullets);
                bullet.transform.position = barrel.position;
                bullet.GetComponent<Bullet>().Initialize(barrel.parent.forward, transform.parent.rotation);
            }
        
    }
}
