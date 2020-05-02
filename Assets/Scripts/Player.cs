using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(_bulletPrefab); //wrong way//re-use

            //communicate with the object pool
            //request bullet
            GameObject bullet =  PoolManager.Instance.RequestBullet();
            bullet.transform.position = Vector3.zero;
        }

    }

}
