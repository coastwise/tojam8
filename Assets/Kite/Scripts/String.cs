using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
[RequireComponent (typeof(CapsuleCollider))]
public class String : MonoBehaviour {

	public Transform start;
	public Transform end;
	
	private LineRenderer line;
	private CapsuleCollider capsule;
	
	void Start () {
		line = GetComponent<LineRenderer>();
		capsule = GetComponent<CapsuleCollider>();
	}
	
	void LateUpdate () {
		line.useWorldSpace = true;
		line.SetPosition(0, start.position);
		line.SetPosition(1, end.position);
		
		transform.position = (start.position + end.position) / 2f;
		transform.rotation = Quaternion.LookRotation(end.position - transform.position);
		
		capsule.height = Vector3.Distance(start.position, end.position) - 0.2f;
	}
	
}
