using UnityEngine;
using System.Collections;

public class NpcEspectatorIA : MonoBehaviour {

	private Animator anim;
	private float speed;
	private Vector3 target;
	private bool isDancing;
	private SpriteRenderer spriteRend;
	private string facing;

	void Start () {
		speed = 0.5f;
		anim = GetComponent<Animator> ();
		spriteRend = GetComponent<SpriteRenderer> ();
		if (transform.position.y <= -0.8) {
			facing = "isDancingUp";
		} else {
			facing = "isDancingSide";
		}
		speed = Random.Range (0.3f, 1f);
	}

	void FixedUpdate(){

		if(transform.position.x==-1.7f)target = new Vector3 (-1.6f, -0.6f, 0);
		if(transform.position.x==-0.75f)target = new Vector3 (-1.85f, -0.55f, 0);
		if(transform.position.x==0.25f)target = new Vector3 (-1.36f, -0.45f, 0);
		if(transform.position.x==0.7f)target = new Vector3 (-1.1f, -0.2f, 0);
		if(transform.position.x==-3.2f)target = new Vector3 (-2.4f, -0.1f, 0);
		if(transform.position.x==-2.7f)target = new Vector3 (-2.15f, -0.4f, 0);


		print ("direccion" + facing);
		anim.SetFloat("SpeedNpc", speed);
		if (transform.position.x > target.x) {
			spriteRend.flipX=true;	
		}
		transform.position = Vector3.MoveTowards(transform.position,target ,Time.deltaTime*speed);
		if (transform.position == target) {
			speed = 0;
			isDancing = true;
			anim.SetFloat("SpeedNpc", speed);
			anim.SetBool (facing, isDancing);
		}

	}

}
