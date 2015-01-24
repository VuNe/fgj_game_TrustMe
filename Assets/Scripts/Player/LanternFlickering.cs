using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Lantern flickering.
/// 
/// Add this script to the "Light_Spot_lantern" GameObject.
/// 
/// </summary>

public class LanternFlickering : MonoBehaviour 
{
	private Light myLight;
	public float maxIntensity = 2.0f;
	public float minIntensity = 1.7f;
	public float pulseSpeed = 0.08f; 		// a value of 0.5f would take 2 seconds and a value of 2f would take half a second
	private float targetIntensity = 1.0f;
	private float currentIntensity;


	void Awake ()
	{
		myLight = GetComponent<Light>();
	}

	void Update ()
	{
		currentIntensity = Mathf.MoveTowards(myLight.intensity, targetIntensity, Time.deltaTime * pulseSpeed);

		if(currentIntensity >= maxIntensity)
		{
			currentIntensity = maxIntensity;
			targetIntensity = minIntensity;
		}
		else if (currentIntensity <= minIntensity)
		{
			currentIntensity = minIntensity;
			targetIntensity = maxIntensity;
		}

		myLight.intensity = currentIntensity;
	}

}
