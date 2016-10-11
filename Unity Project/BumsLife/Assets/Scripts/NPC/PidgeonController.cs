using UnityEngine;
using System.Collections;

public class PidgeonController : MonoBehaviour {

	Vector3 initPosition;
	private Animator anim;
	bool fly;
	SpriteRenderer spriteRend;
	int rand;
	void Start () {
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
			anim.SetBool ("fly", true);
			Fly (rand);
		}
	}

	public void Move(){
		anim.SetFloat("speed", 1);
		int direction = Random.Range (1, 5);

		switch (direction) {
		case 1: 
			transform.Translate (Vector3.up* Time.deltaTime*0.1f);
			break;
		case 2: 
			transform.Translate (Vector3.down* Time.deltaTime*0.1f);
			break;
		case 3:
			spriteRend.flipX = false;
			transform.Translate (Vector3.right* Time.deltaTime*0.1f);
				break;
		case 4:	
			spriteRend.flipX = true;
			transform.Translate (Vector3.left* Time.deltaTime*0.1f);
			break;
		}
	}

	public void Fly(int direction){
		
		switch (direction) {
		case 1: spriteRend.flipX = true;
				transform.Translate(new Vector3((1f * Time.deltaTime), (1f * Time.deltaTime),0f));	
				break;
		case 2:	transform.Translate(new Vector3(-(1f * Time.deltaTime), (1f * Time.deltaTime),0f));
				break;
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			print ("volar");
			fly = true;
		}
	}
}
