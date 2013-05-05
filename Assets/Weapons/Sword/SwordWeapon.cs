using UnityEngine;
using System.Collections;

public class SwordWeapon : Weapon {
	
	
	// Use this for initialization
	void Start () {
		Destroy(this, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(initialDirection);
	}
}
