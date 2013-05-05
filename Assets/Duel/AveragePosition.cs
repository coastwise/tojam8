using UnityEngine;
using System.Collections;

public class AveragePosition : MonoBehaviour {
	
	public Transform[] objects;

	// Update is called once per frame
	void Update () {
		Vector3 sum = Vector3.zero;
		foreach (Transform obj in objects) {
			sum = sum + obj.position;
		}
		
		transform.position = sum / (float)objects.Length;
	}
}
