using UnityEngine;
using System.Collections;

public class NpcEspectatorIA : MonoBehaviour {

	private Animator anim;
	private float speed;
	private Vector3 target;
	private bool isDancing,X=true;
	private SpriteRenderer spriteRend;
	private string facing;
	private Vector3 posInicial, posInicial2;


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
		posInicial = transform.position;
		posInicial2 = new Vector3 (posInicial.x - 5, posInicial.y, posInicial.z);

	}

	void FixedUpdate(){
		
		if (GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().Quantity <= 0) {
			MovimientoAtras ();
		} else {
			
			MovimientoNpc ();
		}

	}

	void MovimientoNpc(){
		if (X) {
			if (transform.position.x == -1.7f)
				target = new Vector3 (-1.6f, -0.6f, 0);
			if (transform.position.x == -0.75f)
				target = new Vector3 (-1.85f, -0.55f, 0);
			if (transform.position.x == 0.25f)
				target = new Vector3 (-1.36f, -0.45f, 0);
			if (transform.position.x == 0.7f)
				target = new Vector3 (-1.1f, -0.2f, 0);
			if (transform.position.x == -3.2f)
				target = new Vector3 (-2.4f, -0.1f, 0);
			if (transform.position.x == -2.7f)
				target = new Vector3 (-2.15f, -0.4f, 0);

			anim.SetFloat ("SpeedNpc", speed);
			if (transform.position.x > target.x) {
				spriteRend.flipX = true;	
			}
			transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * speed);
			if (transform.position == target) {
				speed = 0;
				isDancing = true;
				anim.SetFloat ("SpeedNpc", speed);
				anim.SetBool (facing, isDancing);
			}
		}
	}

	void MovimientoAtras(){
		X = false;

		isDancing = false;
		if (transform.position.x > target.x) {
			spriteRend.flipX = true;	
		}
		speed = Random.Range (1, 3);
		anim.SetBool (facing, isDancing);
		anim.SetFloat("SpeedNpc", speed);
		transform.position = Vector3.MoveTowards(transform.position,posInicial2,Time.deltaTime*speed);
		if (transform.position == posInicial2) {
			
			GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().NpcCounter += 1;
			GameObject.Find ("Hobo").GetComponent<GuitarMinigame> ().Quantity = -5;
			print ("destruyeme");
			Destroy (this.gameObject);
		}
	}
}
