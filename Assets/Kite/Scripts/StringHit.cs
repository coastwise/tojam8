using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class StringHit : MonoBehaviour {
	
	public GameObject effectPrefab;
	
	public AudioSource audio;
	
	public AudioClip[] stringHitClips;

	void OnCollisionEnter(Collision collision) {
		GameObject them = collision.gameObject;
				
		if (them.tag == "String") {
			Debug.Log("string hit!");
			audio.clip = stringHitClips[Random.Range(0, stringHitClips.Length)];
			audio.Play();
			
			GameObject effect = Instantiate(effectPrefab, collision.transform.position, collision.transform.rotation) as GameObject;
		}
		
	}
	
}
