using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class PilotController : MonoBehaviour {
	
	public Rope rope;
	private CharacterController cc;
	private float moveVelocity = 10.0f;
	private Vector3 moveDirection = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
		if (rope == null) {
			rope = gameObject.GetComponentInChildren<Rope>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Moving Pilot
		Vector3 v = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		cc.Move (v * Time.deltaTime * moveVelocity);
		
		rope.Extend (Input.GetAxis("Extend"));
		rope.Retract (Input.GetAxis("Retract"));
	}
	
}
