using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassSet : MonoBehaviour
{
    public Vector3 com;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = com;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
