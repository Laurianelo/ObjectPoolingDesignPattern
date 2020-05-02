using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
  
    private static PoolManager _instance;
    [SerializeField]
    private GameObject _bulletContainer;
    [SerializeField]
    private GameObject _bullterPrefab;
    [SerializeField]
    private List<GameObject> _bulletPoolList;

    //turn this class into a singleto for easy accessibility
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null) ;
            Debug.LogError("The PoolManager is NULL");

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
            GameObject bullet = Instantiate(_bullterPrefab);
            bullet.transform.parent = _bulletContainer.transform;
            bullet.SetActive(false);
            _bulletPoolList.Add(bullet);
        }
       

        return _bulletPoolList;
    }
}
