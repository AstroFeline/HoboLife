using UnityEngine;
using System.Collections;

public class GuitarEnd : MonoBehaviour {

	private bool isEnding;
	private Animator anim;

	// Use this for initialization
	void Start () {
		isEnding = true;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GuitarResults(){
		anim.SetBool ("EndGuitar", isEnding);
	}
}
