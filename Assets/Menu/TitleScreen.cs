using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	
	public GameObject explosionPrefab;
	public float delay = 2f;
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		
		if (Input.anyKey) {
			StartCoroutine(StartGame());
		}
	}
	
	IEnumerator StartGame () {
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		yield return new WaitForSeconds(delay);
		Application.LoadLevel("Prototype");
		yield break;
	}
	
}
