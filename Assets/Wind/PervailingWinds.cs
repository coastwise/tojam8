using UnityEngine;
using System.Collections;

public class PervailingWinds : MonoBehaviour {
	
	private ConstantForce[] kiteForces;
	
	// Wind Direction
	private Vector3 windDirection;
	private Vector3 desiredWindDirection;
	
	// Wind Intensity
	private float windIntensity;
	private float desiredWindIntensity;
	private float windIntensityBlendTime = 2.0f;
	
	// Wind Change
	public int minimumWindChangeTime;
	public int maximumWindChangeTime;
	
	private float windChangeTime;
	private float currentWindChangeTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		kiteForces = (ConstantForce[])MonoBehaviour.FindObjectsOfType(typeof(ConstantForce));
		
		// Blending
		BlendWindDirection ();
		BlendWindIntensity ();
		
		// Randomize
		if (ShouldRandomizeWind ()) {
			RandomizeWindDirection ();
			RandomizeWindIntensity ();
		}
		
		UpdateWindChangeTime ();
		
		UpdateKites ();
	}
	
	private void UpdateKites () {
		if (kiteForces != null && kiteForces.Length > 0) {
			foreach (ConstantForce cf in kiteForces) {
				cf.force = windDirection * windIntensity;
			}
		}
	}
	
	private void BlendWindDirection () {
		Vector3.Slerp (windDirection, desiredWindDirection, 2.0f);
	}
	
	private void BlendWindIntensity () {
		windIntensityBlendTime += Time.deltaTime;
		
		if (windIntensityBlendTime > 2.0f) {
			return;
		}
		
		windIntensity += (desiredWindIntensity - windIntensity) * Time.deltaTime;
	}
	
	private void RandomizeWindDirection () {
		desiredWindDirection = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
	}
	
	private void RandomizeWindIntensity () {
		desiredWindIntensity = Random.Range (0.0f, 120.0f);
		windIntensityBlendTime = 0;
	}
	
	private bool ShouldRandomizeWind () {
		return currentWindChangeTime > windChangeTime;
	}
	
	private void UpdateWindChangeTime () {
		if (ShouldRandomizeWind()) {
			windChangeTime = Random.Range (minimumWindChangeTime, maximumWindChangeTime);
			currentWindChangeTime = 0;
		}
		
		currentWindChangeTime += Time.deltaTime;
	}
}
