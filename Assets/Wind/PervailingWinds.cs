using UnityEngine;
using System.Collections;

public class PervailingWinds : MonoBehaviour {
	
	private Kite[] kites;
	
	// Wind Direction
	private Vector3 windDirection;
	private Vector3 desiredWindDirection;
	
	// Wind Intensity
	private float windIntensity;
	private float desiredWindIntensity;
	
	// Wind Change
	public int minimumWindChangeTime;
	public int maximumWindChangeTime;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		kites = (Kite[])MonoBehaviour.FindObjectsOfType(typeof(Kite[]));
		
		// Blending
		BlendWindDirection ();
		BlendWindIntensity ();
		
		// Randomize
		if (ShouldRandomizeWind ()) {
			RandomizeWindDirection ();
			RandomizeWindIntensity ();
		}
	}
	
	private void BlendWindDirection () {
		
	}
	
	private void BlendWindIntensity () {
		
	}
	
	private void RandomizeWindDirection () {
		// ...
	}
	
	private void RandomizeWindIntensity () {
		// ...
	}
	
	private bool ShouldRandomizeWind () {
		// ...
		
		return false;	
	}
}
