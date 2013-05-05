using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class KiteHit : MonoBehaviour {
	
	public AudioSource audio;
	
	public AudioClip[] kiteHitClips;

	void OnCollisionEnter(Collision collision) {
		GameObject them = collision.gameObject;
				
		if (them.tag == "Kite") {
			Debug.Log("kite hit!");
			audio.clip = kiteHitClips[Random.Range(0, kiteHitClips.Length)];
			audio.Play();
		}
		
	}
}
