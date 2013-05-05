using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class CrashExplosion : MonoBehaviour {
	
	public GameObject explosionPrefab;
	
	 void OnCollisionEnter(Collision collision) {
		GameObject them = collision.gameObject;
		
		Debug.Log("bang!");
		
		Debug.Log(them.tag);
		
		if (them.tag == "Ground") {
			Debug.Log("ground!");
			Destroy(this.gameObject);
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
		}
		
		if (them.tag == "Kite") {
			Kite themKite = them.GetComponent<Kite>();
			Kite me = GetComponent<Kite>();
			
			if (me.distanceTraveledSinceLastFrame < themKite.distanceTraveledSinceLastFrame) {
				Destroy(this.gameObject);
				GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
			}
		}
	}
	
}
