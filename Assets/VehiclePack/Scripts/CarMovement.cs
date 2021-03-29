using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	private WheelCollider[] wheels;

	private float maxAngle = 40;
	public float speed = 300;
	public float brakeForce = 300;
	public GameObject wheelShape;
	public float torque;
	public float angle;
	public Rigidbody rb;
	public float maxSpeed;
	public Vector3 CenterOfMass;
	public float carMove;

	public void Start()
	{
		wheels = GetComponentsInChildren<WheelCollider>();
		

		for (int i = 0; i < wheels.Length; ++i) 
		{
			var wheel = wheels [i];

			// create wheel shapes only when needed
			if (wheelShape != null)
			{
				var ws = GameObject.Instantiate (wheelShape);
				ws.transform.parent = wheel.transform;
			}
		}
	}

	public void Update()
	{

			angle = maxAngle * Input.GetAxis("Horizontal") * carMove;
			torque = speed * Input.GetAxis("Vertical") * carMove;

			rb.centerOfMass = CenterOfMass;

			foreach (WheelCollider wheel in wheels)
			{
				wheel.motorTorque = torque;


				if (wheel.transform.localPosition.z > 0)
				{
					wheel.steerAngle = angle;
					wheel.motorTorque = torque;
				}

				if (wheelShape)
				{
					Quaternion q;
					Vector3 p;
					wheel.GetWorldPose(out p, out q);

					Transform shapeTransform = wheel.transform.GetChild(0);
					shapeTransform.position = p;
					shapeTransform.rotation = q;
				}
				if (torque == 0)
				{
					wheel.brakeTorque = brakeForce;
				}
				else
				{
					wheel.brakeTorque = 0;
				}
			}

	}
	
}
