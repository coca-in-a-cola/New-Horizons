using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapons : MonoBehaviour
{
    public List<Transform> barrels;
    public List<GameObject> bulletsPrefab;
    [SerializeField]
    private int bulletPoolCount = 5;

    private PlayerInput playerInput;
    private ObjectPool bulletPool;
    private ObjectPool missilePool;



    private void Awake()
    {
        missilePool = GetComponent<ObjectPool>();
        bulletPool = GetComponent<ObjectPool>();
        
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        bulletPool.Initialize(bulletPoolCount);
        missilePool.Initialize(bulletPoolCount);
    }

    private void Update()
    {
        
    }

    public void ShootBullets()
    {
        foreach (var barrel in barrels)
            {
                GameObject bullet = bulletPool.CreateObject(bulletsPrefab[0]);
                bullet.transform.position = barrel.position;
                //bullet.transform.localRotation = transform.parent.rotation; /*Quaternion.Euler(new Vector3(0, playerInput.rotationAngle, 0));*/
                bullet.GetComponent<Bullet>().Initialize(barrel.parent.forward, transform.parent.rotation);
            }
        
    }

    public void ShootMissiles()
    {
        foreach (var barrel in barrels)
        {
            GameObject bullet = bulletPool.CreateObject(bulletsPrefab[1]);
            bullet.transform.position = barrel.position;
            //bullet.transform.localRotation = transform.parent.rotation; /*Quaternion.Euler(new Vector3(0, playerInput.rotationAngle, 0));*/
            bullet.GetComponent<Bullet>().Initialize(barrel.parent.forward, transform.parent.rotation);
        }

    }


}
