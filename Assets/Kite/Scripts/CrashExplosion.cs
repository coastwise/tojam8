using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class CrashExplosion : MonoBehaviour {
	
	public GameObject explosionPrefab;
	
	 void OnCollisionEnter(Collision collision) {
		GameObject them = collision.gameObject;
		
		if (them.tag == "Ground" && gameObject.tag == "Kite") {
			Destroy(this.gameObject);
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
			
			Countdown countdown = GameObject.FindObjectOfType(typeof(Countdown)) as Countdown;
			countdown.GameOver("");
		}
		
	}
	
}
