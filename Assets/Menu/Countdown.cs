using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	public TextMesh textPrefab;
	
	private GameObject[] players;
		
	void OnEnable () {
		StartCoroutine(CountdownCoroutine());
		
		// we need the players to be active in order to find them...
		players = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject player in players) {
			player.SetActive(false);
		}

	}
	
	protected IEnumerator CountdownCoroutine () {
		
		Vector3 pos = Camera.mainCamera.transform.position;
		Quaternion rot = Quaternion.LookRotation(Camera.mainCamera.transform.forward, Vector3.up);
		
		Vector3 end = transform.position + transform.forward * 10;
		
		TextMesh prevText = null;
		for (int n = 3; n >= 0; n--) {
			TextMesh currText = Instantiate(textPrefab, pos, rot) as TextMesh;
			if (n == 0) {
				currText.text = "Kite Fight!";
			} else {
				currText.text = n.ToString();
			}
			iTween.MoveTo(currText.gameObject, transform.position, 1f);
			
			if (prevText != null) {
				Destroy(prevText.gameObject);
			}
			
			yield return new WaitForSeconds(1f);
			
			prevText = currText;
		}
		
		Destroy(prevText.gameObject);
		
		//Camera.mainCamera.GetComponent<SmoothLookAt>().
		
		foreach (GameObject player in players) {
			Debug.Log(player.name);
			player.SetActive(true);
		}
		
		yield break;
	}
}
