using UnityEngine;
using System.Collections;

public class PidgeonController : MonoBehaviour {

	Vector3 initPosition;
	private Animator anim;
	bool fly, facingR=false, flyBack;
	SpriteRenderer spriteRend;
	int rand,direction;
	float isWalking=1f;

	void Start () {
		direction = 3;
		initPosition = transform.position;
		anim = GetComponent<Animator>();
		spriteRend = GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate () {
		
		if (!fly) {
			rand=Random.Range (1, 3);
			switch (rand) {
			case 1:
				Move ();
				break;
			case 2:
				anim.SetFloat ("speed", 0);
				break;
			}
		} else {
			anim.SetBool ("fly", fly);
			Fly ();
		}
	}

	public void Move(){
		anim.SetFloat("speed", 1);
		if (isWalking >= 0) {
			switch (direction) {
			case 1: 
				transform.Translate (Vector3.up * Time.deltaTime * 0.1f);
				break;
			case 2: 
				transform.Translate (Vector3.down * Time.deltaTime * 0.1f);
				break;
			case 3:
				spriteRend.flipX = true;
				facingR = true;
				transform.Translate (Vector3.right * Time.deltaTime * 0.1f);
				break;
			case 4:	
				spriteRend.flipX = false;
				facingR = false;
				transform.Translate (Vector3.left * Time.deltaTime * 0.1f);
				break;
			}
			isWalking -= Time.deltaTime;
		} else {
			direction = Random.Range (1, 5);
			isWalking = 1f;
		}
	}

	public void Fly(){
		
		if (!flyBack) {
			if (facingR)
				transform.Translate (new Vector3 ((1f * Time.deltaTime), (1f * Time.deltaTime), 0f));
			else
				transform.Translate (new Vector3 (-(1f * Time.deltaTime), (1f * Time.deltaTime), 0f));
		} else {
			if (facingR) spriteRend.flipX = false;
			else spriteRend.flipX = true;

			transform.position = Vector3.MoveTowards (transform.position,initPosition, Time.deltaTime*2);
			if (transform.position == initPosition) {
				flyBack = false;
				fly = false;
				anim.SetBool ("fly", fly);
			}
		}
		if (transform.position.y > initPosition.y + 2f && flyBack==false) {
			flyBack = true;
		}

	}

	public void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player") {
			print ("volar");
			fly = true;
		}
	}
}
