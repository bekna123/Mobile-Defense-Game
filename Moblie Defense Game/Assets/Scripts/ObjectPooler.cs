using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int poolcount = 28;
    public bool more = true;

    private List<GameObject> poolList;


    // Start is called before the first frame update
    void Start()
    {
        poolList = new List<GameObject>();
        while (poolcount > 0)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            poolList.Add(obj);
            poolcount--;
        }
    }

    public GameObject getObject()
    {
        foreach(GameObject obj in poolList)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        if (more)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            poolList.Add(obj);
            return obj;
        }

        return null;
    }
}
