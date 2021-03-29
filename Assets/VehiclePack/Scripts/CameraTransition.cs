using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    public Transform helicopterCamera;
    public Transform boatCamera;
    public Transform carCamera;

    public float transitionSpeed;

    public int cameraNumber;

    public Transform currentView;

    public GameObject boat;
    public GameObject heli;
    public GameObject car;

    public GameObject heliLean;
    public GameObject heliStrafe;

    public bool isBoat;
    public bool isCar;
    public bool isHelicopter;
    public bool onHeliPad;
    public bool canSwitch;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        canSwitch = true;
        boat = GameObject.Find("Boat");
        heli = GameObject.Find("Helicopter");
        car = GameObject.Find("Car");
        heliLean = GameObject.Find("Lean");
        heliStrafe = GameObject.Find("Strafe");

        boatCamera = GameObject.Find("BoatCameraTarget").GetComponent<Transform>();
        helicopterCamera = GameObject.Find("HelicopterCameraTarget").GetComponent<Transform>();
        carCamera = GameObject.Find("CarCameraTarget").GetComponent<Transform>();
    }

    void Update()
    {

        if ((Input.GetAxis("Mouse ScrollWheel") < 0f) && canSwitch)
        {
            
            if(cameraNumber == 0)
            {
                anim.Play("HelicopterToCar_Reversed");
                StartCoroutine("plusOne");
            }
            else if(cameraNumber == 1)
            {
                anim.Play("BoatToHelicopter_Reversed");
                StartCoroutine("plusOne");
            }
            else if(cameraNumber == 2)
            {
                anim.Play("CarToBoat_Reversed");
                StartCoroutine("minusTwo");
            }
        }

        if ((Input.GetAxis("Mouse ScrollWheel") > 0f) && canSwitch)
        {
            if (cameraNumber == 0)
            {
                anim.Play("CarToBoat");
                StartCoroutine("plusTwo");
            }
            else if(cameraNumber == 1)
            {
                anim.Play("HelicopterToCar");
                StartCoroutine("minusOne");
            }
            else if(cameraNumber == 2)
            {
                anim.Play("BoatToHelicopter");
                StartCoroutine("minusOne");
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraNumber = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameraNumber = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cameraNumber = 2;
        }
        switch (cameraNumber)
        {
            case 2:
                currentView = boatCamera;

                boat.GetComponent<BoatMovement>().boatMove = 1;
                heli.GetComponent<HelicopterMovement>().canMove = false;
                heli.GetComponent<LookTowardsMouse>().enabled = false;
                heliLean.GetComponent<HelicopterLean>().enabled = false;
                heliStrafe.GetComponent<HelicopterStrafe>().enabled = false;
                car.GetComponent<CarMovement>().carMove = 0;


                isBoat = true;
                isHelicopter = false;
                isCar = false;
                break;
            case 1:
                currentView = helicopterCamera;

                boat.GetComponent<BoatMovement>().boatMove = 0;
                heli.GetComponent<HelicopterMovement>().canMove = true;
                heli.GetComponent<LookTowardsMouse>().enabled = true;
                heliLean.GetComponent<HelicopterLean>().enabled = true;
                heliStrafe.GetComponent<HelicopterStrafe>().enabled = true;
                car.GetComponent<CarMovement>().carMove = 0;


                isBoat = false;
                isHelicopter = true;
                isCar = false;
                break;
            case 0:
                currentView = carCamera;

                boat.GetComponent<BoatMovement>().boatMove = 0;
                heli.GetComponent<HelicopterMovement>().canMove = false;
                heli.GetComponent<LookTowardsMouse>().enabled = false;
                heliLean.GetComponent<HelicopterLean>().enabled = false;
                heliStrafe.GetComponent<HelicopterStrafe>().enabled = false;
                car.GetComponent<CarMovement>().carMove = 1;


                isBoat = false;
                isHelicopter = false;
                isCar = true;
                break;
        }

    }


    void LateUpdate()
    {

        //Lerp position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;

    }
    IEnumerator plusOne()
    {
        canSwitch = false;
        cameraNumber += 1;
        yield return new WaitForSeconds(0.2f);
        canSwitch = true;
    }
    IEnumerator minusOne()
    {
        canSwitch = false;
        cameraNumber -= 1;
        yield return new WaitForSeconds(0.2f);
        canSwitch = true;
    }
    IEnumerator minusTwo()
    {
        canSwitch = false;
        cameraNumber -= 2;
        yield return new WaitForSeconds(0.2f);
        canSwitch = true;
    }
    IEnumerator plusTwo()
    {
        canSwitch = false;
        cameraNumber += 2;
        yield return new WaitForSeconds(0.2f);
        canSwitch = true;
    }
}