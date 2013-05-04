using UnityEngine;
using System.Collections;

/**
 * Adapted from Jacob Fletcher's Physics Based 3D Rope
 * http://wiki.unity3d.com/index.php/3D_Physics_Based_Rope
 */

[RequireComponent (typeof(Rigidbody))]
public class Rope : MonoBehaviour {
	
	public Rigidbody end;
	public float resolution;
	public Material ropeMaterial;
	
	void Awake () {
		if (end) {
			GenerateRope();
		} else {
			Debug.LogError("Need to assign an end to generate rope " + name);
		}
	}
	
	private void GenerateRope () {
		float length = Vector3.Distance(transform.position, end.position);
		int numSegments = (int)(length * resolution);
		Vector3 separation = (end.position - transform.position) / numSegments;
		
		GameObject prevSegment = null;
		for (int i = 1; i < numSegments; i++) {
			
			GameObject segment = new GameObject(name + "_segment_" + i);
			segment.transform.parent = transform;
			segment.transform.localPosition = separation * i;
			segment.transform.localRotation = Quaternion.LookRotation(separation);
			
			Rigidbody body = segment.AddComponent<Rigidbody>();
			body.mass = 0.001f; // 1 gram
			body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			
			CharacterJoint joint = segment.AddComponent<CharacterJoint>();
			joint.axis = Vector3.forward; // twist
			joint.swingAxis = Vector3.up; // swing
			//joint.swing1Limit.limit = 20;
			//joint.lowTwistLimit.limit = 0;
			//joint.highTwistLimit.limit = 0;
			
			CapsuleCollider collider = segment.AddComponent<CapsuleCollider>();
			collider.radius = 0.1f;
			collider.height = 1f/resolution;
			collider.direction = 2; // forward
			
			LineRenderer renderer = segment.AddComponent<LineRenderer>();
			renderer.SetWidth(0.05f, 0.05f);
			renderer.material = ropeMaterial;			
			
			if (prevSegment == null) {
				// first segment is connected to us
				joint.connectedBody = rigidbody;
			} else {
				// other segments are connected to previous segments
				joint.connectedBody = prevSegment.rigidbody;
				
				LineRendererAnchor lineAnchor = prevSegment.AddComponent<LineRendererAnchor>();
				lineAnchor.anchor = segment.transform;
			}
			
			prevSegment = segment;
		}
		
		CharacterJoint lastJoint = end.gameObject.AddComponent<CharacterJoint>();
		lastJoint.connectedBody = prevSegment.rigidbody;
		
		LineRendererAnchor lastLine = prevSegment.AddComponent<LineRendererAnchor>();
		lastLine.anchor = end.transform;
		
		// for some reason, the last segment can't have a normal collider
		prevSegment.collider.isTrigger = true;
	}
	
	public void Extend (float amount) {
		Debug.LogWarning("extend is not implemented yet!");
	}
	
	public void Retract (float amount) {
		Debug.LogWarning("retract is not implemented yet!");
	}
	
}
