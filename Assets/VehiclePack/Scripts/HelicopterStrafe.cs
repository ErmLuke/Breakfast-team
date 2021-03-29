using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterStrafe : MonoBehaviour
{
    public Animator anim;
    public bool isRight;
    public bool isLeft;
    public bool isNormal;
    public HelicopterMovement hMove;
    void Start()
    {
        anim = GetComponent<Animator>();
        hMove = GameObject.Find("Helicopter").GetComponent<HelicopterMovement>();
    }

    void Update()
    {
        if (hMove.grounded == true)
        {
            anim.Play("StrafeIdle");
        }
        else
        {

            if ((Input.GetAxis("Horizontal") > 0) && (isNormal))
            {
                isNormal = false;
                anim.Play("StrafeRight");
                isRight = true;
            }
            if ((Input.GetAxis("Horizontal") > 0) && (isLeft))
            {
                isLeft = false;
                anim.Play("StrafeLeft_Reversed");
                isNormal = true;
            }

            if ((Input.GetAxis("Horizontal") < 0) && (isNormal))
            {
                isNormal = false;
                anim.Play("StrafeLeft");
                isLeft = true;
            }
            if ((Input.GetAxis("Horizontal") < 0) && (isRight))
            {
                isRight = false;
                anim.Play("StrafeRight_Reversed");
                isNormal = true;
            }

            if ((Input.GetAxis("Horizontal") == 0) && (isLeft))
            {
                isLeft = false;
                anim.Play("StrafeLeft_Reversed");
                isNormal = true;
            }
            if ((Input.GetAxis("Horizontal") == 0) && (isRight))
            {
                isRight = false;
                anim.Play("StrafeRight_Reversed");
                isNormal = true;
            }
        }

    }
}
