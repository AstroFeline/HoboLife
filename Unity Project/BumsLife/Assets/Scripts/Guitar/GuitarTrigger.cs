using UnityEngine;
using System.Collections;

public class GuitarTrigger : MonoBehaviour {

	public GameObject guitar;
	private bool isTrigger=false;

	void Update(){
		if (isTrigger && Input.GetKeyDown (KeyCode.Space)) {
			if(guitar.activeSelf)guitar.SetActive (false);
				else guitar.SetActive (true);
			GameObject.Find ("Main Camera").GetComponent<CameraController> ().IsZoom = true;//!GameObject.Find ("Main Camera").GetComponent<CameraController> ().IsZoom;
			GameObject.Find ("Hobo").GetComponent<PlayerController> ().Flip (0.1f);
			GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().IsGuitarOn = !GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().IsGuitarOn;
			GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().PlayGuitar ();
		} 
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			guitar.SetActive (true);
			isTrigger = true;
		}	

	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			guitar.SetActive (false);
			isTrigger = false;
		}	

	}
}
