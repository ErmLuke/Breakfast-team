using UnityEngine;
using System.Collections;

public class HelicopterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardSpeed;
    public float strafeSpeed;
    public float liftSpeed;
    public float propSpeed;
    public bool grounded;
    public bool canFly;
    public GameObject propeller;
    public GameObject body;
    public Vector3 currentRotation;
    public Vector3 OriginalRotation;
    public float fwdRotation;
    public float bckRotation;
    public float smoothness;
    public float floatSpeed;
    public bool canBob = true;
    public bool canMove;
    public float bobable;
    public GameObject gCheck;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        OriginalRotation = transform.eulerAngles;
        gCheck = GameObject.Find("GroundCheck");
    }

    void Update()
    {
        if (canMove)
        {
            grounded = Physics.Raycast(gCheck.transform.position, Vector3.down, 1f);
            propeller.transform.Rotate(Vector3.forward * propSpeed * 3);
            if (Input.GetAxis("Height") == 0)
            {
                floatSpeed = (rb.velocity.y * -10f) + 15f;
            }
            else
            {
                floatSpeed = 0;
            }


            if (canFly)
            {
                transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * forwardSpeed));
                transform.Translate(Vector3.right * (Input.GetAxis("Horizontal") * strafeSpeed));
                if (Input.GetAxis("Height") > 0)
                {
                    rb.AddForce(Vector3.up * (Input.GetAxis("Height") * liftSpeed));
                }
                currentRotation = transform.eulerAngles;
                if (Input.GetAxis("Vertical") > 0)
                {
                    currentRotation.z = Mathf.Lerp(currentRotation.z, fwdRotation, Time.deltaTime * smoothness);
                }
                if (Input.GetAxis("Vertical") < 0)
                {
                    currentRotation.z = Mathf.Lerp(currentRotation.z, bckRotation, Time.deltaTime * smoothness);
                }

            }

            if (propSpeed > 3)
            {
                canFly = true;
                propSpeed = 3;
            }
            if (propSpeed < 1.5f)
            {
                canFly = false;
            }

            if (propSpeed < 0)
            {
                propSpeed = 0;
            }
            if (grounded)
            {
                if (Input.GetAxis("Height") > 0)
                {
                    propSpeed += 0.01f;
                }
                if (Input.GetAxis("Height") <= 0)
                {
                    if (propSpeed != 0)
                    {
                        propSpeed -= 0.01f;
                    }
                }
            }
            if (!grounded && canBob)
            {
                StartCoroutine("FloatBob");
            }
            if (!grounded)
            {
                rb.AddForce(Vector3.up * floatSpeed * bobable);
            }
        }
    }

    IEnumerator FloatBob()
    {
        canBob = false;
        bobable = 1;
        yield return new WaitForSeconds(0.1f);
        bobable = 0;
        yield return new WaitForSeconds(0.3f);
        canBob = true;
    }
}