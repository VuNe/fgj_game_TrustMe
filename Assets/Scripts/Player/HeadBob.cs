using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Head bob.
/// 
/// Add this script to the "Camera_fp" GameObject.
/// - Bobbing Amount: 0.025
/// - Mid Point: 0
/// 
/// Add this script to the "Capsule_torch" GameObject.
/// - Bobbing Amount: 0.005
/// - Mid Point: -0.3
/// 
/// </summary>

public class HeadBob : MonoBehaviour 
{
	private float timer = 0.0f;
	private float bobbingSpeed = 0.2f;
	public float bobbingAmount = 0.02f;
	public float midPoint = 0.0f;


	void Update () 
	{
		MoshMode();
	}

//=================================================================================================================
	
	/// <summary>
	/// Moves GameObject up and down.
	/// </summary>
	void MoshMode ()
	{
		float waveslice = 0.0f;
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 cSharpConversion = transform.localPosition;
		
		if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) 
		{
			timer = 0.0f;
		}
		else 
		{
			waveslice = Mathf.Sin(timer);
			timer = timer + bobbingSpeed;
			
			if (timer > Mathf.PI * 2) 
			{
				timer = timer - (Mathf.PI * 2);
			}
		}
		
		if (waveslice != 0) 
		{
			float translateChange = waveslice * bobbingAmount;
			float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
			totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
			translateChange = totalAxes * translateChange;
			cSharpConversion.y = midPoint + translateChange;
		}
		else 
		{
			cSharpConversion.y = midPoint;
		}
		
		transform.localPosition = cSharpConversion;
	}

}
