using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class LookTowardsMouse : MonoBehaviour
{
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	float rotationX = 0F;
	private List<float> rotArrayX = new List<float>();
	float rotAverageX = 0F;

	public float frameCounter = 20;

	Quaternion originalRotation;

	void Update()
	{
		if (GetComponent<HelicopterMovement>().grounded == false)
		{
			rotAverageX = 0f;

			rotationX += Input.GetAxis("Mouse X") * sensitivityX;

			rotArrayX.Add(rotationX);

			if (rotArrayX.Count >= frameCounter)
			{
				rotArrayX.RemoveAt(0);
			}
			for (int i = 0; i < rotArrayX.Count; i++)
			{
				rotAverageX += rotArrayX[i];
			}
			rotAverageX /= rotArrayX.Count;

			rotAverageX = ClampAngle(rotAverageX, -360F, 360F);

			Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		}
	}

	void Start()
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb)
			rb.freezeRotation = true;
		originalRotation = transform.localRotation;
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F))
		{
			if (angle < -360F)
			{
				angle += 360F;
			}
			if (angle > 360F)
			{
				angle -= 360F;
			}
		}
		return Mathf.Clamp(angle, min, max);
	}
}
