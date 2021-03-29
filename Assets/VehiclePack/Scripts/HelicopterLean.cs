using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterLean : MonoBehaviour
{
    public Animator anim;
    public bool isFwd;
    public bool isBck;
    public bool isNormal;
    public HelicopterMovement hMove;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hMove = GameObject.Find("Helicopter").GetComponent<HelicopterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hMove.grounded == true)
        {
            anim.Play("Idle");
        }
        else
        {
            if ((Input.GetAxis("Vertical") > 0) && (isFwd))
            {
                return;
            }

            if ((Input.GetAxis("Vertical") > 0) && (isNormal))
            {
                isNormal = false;
                anim.Play("LeanFwd");
                isFwd = true;
            }

            if ((Input.GetAxis("Vertical") > 0) && (isBck))
            {
                isBck = false;
                anim.Play("LeanBck_Reversed");
                isNormal = true;
            }



            if ((Input.GetAxis("Vertical") < 0) && (isFwd))
            {
                isFwd = false;
                anim.Play("LeanFwd_Reversed");
                isNormal = true;
            }

            if ((Input.GetAxis("Vertical") < 0) && (isNormal))
            {
                isNormal = false;
                anim.Play("LeanBck");
                isBck = true;
            }

            if ((Input.GetAxis("Vertical") == 0) && (isFwd))
            {
                isFwd = false;
                anim.Play("LeanFwd_Reversed");
                isNormal = true;
            }

            if ((Input.GetAxis("Vertical") == 0) && (isBck))
            {
                isBck = false;
                anim.Play("LeanBck_Reversed");
                isNormal = true;
            }
        }
    }

}
