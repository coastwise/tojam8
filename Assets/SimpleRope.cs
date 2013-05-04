using UnityEngine;
using System.Collections;

public class SimpleRope : MonoBehaviour {
	
	public GameObject pilot;
	public GameObject kite;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Extend (float amount) {
		if (amount > 0.7f) {
			CharacterJoint cj = pilot.GetComponent<CharacterJoint>();
			cj.connectedBody = null;
		} else {
			CharacterJoint cj = pilot.GetComponent<CharacterJoint>();
			if (cj.connectedBody == null) {
				cj.connectedBody = kite.GetComponent<Rigidbody>();
			}
		}
	}
	
	public void Retract (float amount) {
		if (amount > 0.7f) {
			CharacterJoint cj = pilot.GetComponent<CharacterJoint>();
			cj.connectedBody = null;
			Vector3 kiteDirection = pilot.transform.position - kite.transform.position;
			kiteDirection.Normalize();
			
			kite.constantForce.relativeForce = -kite.constantForce.force;
			kite.transform.position -= (kite.transform.position - pilot.transform.position) * Time.deltaTime;
			
		} else {
			CharacterJoint cj = pilot.GetComponent<CharacterJoint>();
			if (cj.connectedBody == null) {
				cj.connectedBody = kite.GetComponent<Rigidbody>();
				kite.constantForce.relativeForce = Vector3.zero;
			}
		}
	}
	
	
}
