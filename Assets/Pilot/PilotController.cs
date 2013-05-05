using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(SimpleRope))]
public class PilotController : MonoBehaviour {
	
	public enum PlayerNumber {
		PLAYER_1 = 1,
		PLAYER_2,
		PLAYER_3,
		PLAYER_4
	}
	
	public PlayerNumber playerNumber;
	
	private SimpleRope rope;
	
	private CharacterController cc;
	private float moveVelocity = 10.0f;
	private Vector3 moveDirection = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
		if (rope == null) {
			rope = gameObject.GetComponent<SimpleRope>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Moving Pilot
		int number = (int)playerNumber;
		Vector3 v = new Vector3(Input.GetAxis("Horizontal" + number), 0, Input.GetAxis("Vertical" + number));
		
		Debug.Log ("Horizontal" + number);
		cc.Move (v * Time.deltaTime * moveVelocity);
		
		rope.Extend (Input.GetAxis("Extend" + number));
		rope.Retract (Input.GetAxis("Retract" + number));
		
		
	}
	
}
