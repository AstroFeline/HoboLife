using UnityEngine;
using System.Collections;

public class NpcEspectatorIA : MonoBehaviour {

	private Animator anim;
	private float speed;
	void Start () {
		speed = 0.1;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		anim.SetFloat("SpeedNpc", speed);
		//transform.Translate = Vector3.MoveTowards;
	}

}
