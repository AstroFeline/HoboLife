using UnityEngine;
using System.Collections;

public class GuitarTrigger : MonoBehaviour {

	public GameObject guitar;
	
	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player") {
			guitar.SetActive (true);
			if (Input.GetKeyUp(KeyCode.P))  {
				print ("space");
				GameObject.Find ("Main Camera").GetComponent<CameraController> ().IsZoom = !GameObject.Find ("Main Camera").GetComponent<CameraController> ().IsZoom;
				GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().IsGuitarOn = !GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().IsGuitarOn;
				GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().PlayGuitar ();
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			guitar.SetActive (false);
		}	

	}
}
