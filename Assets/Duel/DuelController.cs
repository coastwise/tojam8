using UnityEngine;
using System.Collections;

public class DuelController : MonoBehaviour {
	
	String rootString;
	
	public int controller;
	
	void Start () {
		rootString = GetComponentInChildren<String>();
	}
	
	bool extending = false;
	bool retracting = false;
	
	// Update is called once per frame
	void Update () {
		/*
		if (!extending = Input.GetButtonDown("Extend1")) {
			//rootString.
		}
		*/
		
		/*
		float x = Input.GetAxis("Horizontal"+controller);
		float y = Input.GetAxis("Vertical1"+controller);
		Vector3 force = new Vector3(x, 0, y);
		force.Normalize();
		*/
		rigidbody.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical"+controller) * 5f);
		rigidbody.AddRelativeTorque(Vector3.up * Input.GetAxis("Horizontal"+controller) * 5f);
		//rigidbody.AddRelativeForce
		if (Input.GetButtonDown("Retract2")) {
			Debug.Log("retract");
		}
		
		Debug.Log("extend"+Input.GetAxis("Extend1"));
		Debug.Log("re"+Input.GetAxis("Retract1"));
	}
}
