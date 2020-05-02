using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
  
    private static PoolManager _instance;
    [SerializeField]
    private GameObject _bulletContainer;
    [SerializeField]
    private GameObject _bulltetPrefab;
    [SerializeField]
    private List<GameObject> _bulletPoolList;

    //turn this class into a singleton for easy accessbility
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The PoolManager is NULL");
            }
         

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _bulletPoolList = GenerateBullets(10);
    }

    // pregenerate a list of bullets using the bullet prefab

    List<GameObject> GenerateBullets(int amountOfBullets)
    {
        for(int i = 0; i< amountOfBullets; i++)
        {
            GameObject bullet = Instantiate(_bulltetPrefab);
            bullet.transform.parent = _bulletContainer.transform;
            bullet.SetActive(false);
            _bulletPoolList.Add(bullet);
        }
       

        return _bulletPoolList;
    }


    public GameObject RequestBullet()
    {
        //loop throught the bullet list
        foreach(var bullet in _bulletPoolList)
        {
            if(bullet.activeInHierarchy == false)
            {
                //bullet is available
                bullet.SetActive(true);
                return bullet;
            }
        }

        //need to create a new bullet
        GameObject newBullet = Instantiate(_bulltetPrefab);
        newBullet.transform.parent = _bulletContainer.transform;
        // newBullet.SetActive(true);
        _bulletPoolList.Add(newBullet);
        
        //cheking for in-active bullet
        //found one? Set it active and return it to player
        //if no bullet avaible ( all turned on)
        //generate x amount of bukkets and run the request bullet method
        return newBullet;
    }

}
