using UnityEngine;
using System.Collections;

public class Kite : MonoBehaviour {
	
	private Vector3 positionAtLastFrame;
	private Vector3 positionAtCurrentFrame;
	public float distanceTraveledSinceLastFrame;
	
	// Use this for initialization
	void Start () {
		positionAtCurrentFrame = transform.TransformPoint(transform.position);
		positionAtLastFrame = positionAtCurrentFrame;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		positionAtCurrentFrame = transform.TransformPoint(transform.position);
		//Debug.Log ("Coordinates Now   : " + positionAtCurrentFrame);
		//Debug.Log ("Coordinates Before: " + positionAtLastFrame);
		
	
		distanceTraveledSinceLastFrame = Vector3.Distance(positionAtCurrentFrame, positionAtLastFrame);
		
		//Debug.Log ("Distance          : " + distanceTraveledSinceLastFrame);
		
		positionAtLastFrame = positionAtCurrentFrame;
		
		//Debug.Log ("...");
	}
}
