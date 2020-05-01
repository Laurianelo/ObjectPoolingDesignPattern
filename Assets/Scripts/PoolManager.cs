using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //turn this class into a singleto for easy accessibility
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null) ;
            Debug.LogError("The Pool Manager is NULL");

            return _instance;
        }
    }


    private void Awake()
    {
        
    }

    // pregenerate a list of bullets using the bullet prefab

    List<GameObject> GenerateBullets()
    {
        return null;
    }
}
