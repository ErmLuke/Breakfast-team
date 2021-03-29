using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool carNear;
    public bool boatNear;
    public bool heliNear;
    public bool near;

    public Transform spawnPoint;

    public Transform carSpawn;
    public Transform boatSpawn;
    public Transform heliSpawn;
    public GameObject spawnItem;

    public CameraTransition controller;
    public ConstantPickUp constant;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Main Camera").GetComponent<CameraTransition>();
        constant = GameObject.Find("Main Camera").GetComponent<ConstantPickUp>();
        carSpawn = GameObject.Find("CarSpawner").GetComponent<Transform>();
        boatSpawn = GameObject.Find("BoatSpawner").GetComponent<Transform>();
        heliSpawn = GameObject.Find("HeliSpawner").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isCar == false)
        {
            carNear = false;
        }
        if (controller.isBoat == false)
        {
            carNear = false;
        }
        if (controller.isHelicopter == false)
        {
            carNear = false;
        }

        if (Input.GetKeyUp(KeyCode.E) && (constant.hasItem == false) && (constant.nearItem) && (near == true) && (constant.canPickUp))
        {
            Instantiate(spawnItem, spawnPoint.position, spawnPoint.rotation);
            constant.nearItem = false;
            near = false;
            constant.hasItem = true;
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (constant.hasItem == false)
        {
            if (other.tag == ("Car"))
            {
                carNear = true;
                spawnPoint = carSpawn;
                constant.nearItem = true;
                near = true;
            }
            if (other.tag == ("Heli"))
            {
                heliNear = true;
                spawnPoint = heliSpawn;
                constant.nearItem = true;
                near = true;
            }
            if (other.tag == ("Boat"))
            {
                boatNear = true;
                spawnPoint = boatSpawn;
                constant.nearItem = true;
                near = true;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Car"))
        {
            carNear = false;
            constant.nearItem = false;
            spawnPoint = null;
            near = false;
        }
        if (other.tag == ("Heli"))
        {
            heliNear = false;
            constant.nearItem = false;
            spawnPoint = null;
            near = false;
        }
        if (other.tag == ("Boat"))
        {
            boatNear = false;
            constant.nearItem = false;
            spawnPoint = null;
            near = false;
        }
    }

}
