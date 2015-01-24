using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Mouse Look
/// 
/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation
///
/// Add the this script to the "Player" capsule GameObject.
/// - Set the Axes to use MouseX in the Inspector. (You want to only turn the capsule but not tilt it)
///
/// Add the this script to the "FP_Camera" camera GameObject. Make the camera a child of the capsule. Set it's transform.
/// - Set the Axes to use MouseY in the Inspector. (You want the camera to tilt up and down like a head. The capsule already turns.)
/// 
/// </summary>

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	private float sensitivityX = 5.0f;
	private float sensitivityY = 4.0f;
	
	private float minimumX = -360.0f;
	private float maximumX = 360.0f;
	
	private float minimumY = -20.0f;
	private float maximumY = 30.0f;
	
	float rotationY = 0f;
	

	void Update ()
	{
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}

}
