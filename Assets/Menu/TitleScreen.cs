using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	
	public GameObject explosionPrefab;
	public float delay = 2f;
	
	private bool started = false;
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		
		if (Input.anyKey && !started) {
			StartCoroutine(StartGame());
			started = true;
		}
	}
	
	IEnumerator StartGame () {
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		yield return new WaitForSeconds(delay);
		Application.LoadLevel("Duel Scene");
		yield break;
	}
	
}
