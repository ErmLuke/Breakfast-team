using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    public Transform parent;
    public Transform dropSpawn;
    public GameObject prefab;
    public ConstantPickUp constant;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("MainTruck").GetComponent<Transform>();
        dropSpawn = GameObject.Find("DropPoint").GetComponent<Transform>();
        constant = GameObject.Find("Main Camera").GetComponent<ConstantPickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.parent = parent;
        
        if(Input.GetKeyUp(KeyCode.E))
        {
            Instantiate(prefab, dropSpawn.position, dropSpawn.rotation);
            constant.hasItem = false;
            constant.StartCoroutine("PickUpDelay");
            Destroy(gameObject);
        }
    }
}
