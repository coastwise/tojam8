using UnityEngine;
using System.Collections;

public class WeaponMount : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			GameObject go = (GameObject)Instantiate(Resources.Load ("Broadsword"));
			go.transform.position = transform.position + transform.TransformDirection(Vector3.up) * 2f;
			go.transform.rotation = go.transform.rotation;
			Weapon w = go.GetComponent<Weapon>();
			w.initialDirection = transform.TransformDirection(Vector3.up);
			w.enabled = true;
		}
	}
}
