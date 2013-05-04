using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
public class LineRendererAnchor : MonoBehaviour {
	
	public Transform anchor;
	
	private LineRenderer line;
	
	void Start () {
		line = GetComponent<LineRenderer>();
	}
	
	void Update () {
		line.useWorldSpace = true;
		line.SetPosition(0, transform.position);
		line.SetPosition(1, anchor.position);
	}
}
