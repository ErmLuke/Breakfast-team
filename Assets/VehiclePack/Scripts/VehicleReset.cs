using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleReset : MonoBehaviour
{
    public Vector3 currentPosition;
    public float startRotationX;
    public float currentRotation;
    public float height = 3;
    public bool flippable = true;
    // Start is called before the first frame update
    void Start()
    {
        startRotationX = transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        currentRotation = transform.eulerAngles.y;
        if((Input.GetKey(KeyCode.R)) && flippable)
        {
            StartCoroutine("ResetCar");
        }
    }
    IEnumerator ResetCar()
    {
        flippable = false;
        gameObject.transform.position = (new Vector3(currentPosition.x, (currentPosition.y + height), currentPosition.z));
        transform.rotation = (Quaternion.Euler(new Vector3(transform.localRotation.x, currentRotation, transform.localRotation.z)));
        yield return new WaitForSeconds(2f);
        flippable = true;

    }
}
