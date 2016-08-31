using UnityEngine;
using System.Collections;

public class GuitarMinigame : MonoBehaviour {

	public GameObject[] guide,guideGood;
	public GameObject goNote;
	public Sprite noteShine;

    private Animator anim;
    private bool isGuitarOn;
	private int quantity = 7;
	private Collider2D[] guideCol = new Collider2D[4];
	private Collider2D[] guideGoodCol= new Collider2D[4];

    void Start()
    {
        anim = GetComponent<Animator>();
		for (int i = 0; i < guide.Length; i++) {
			print ("asignao");
			guideCol[i] = guide[i].GetComponent<Collider2D> ();
			guideGoodCol[i] = guideGood[i].GetComponent<Collider2D> ();
		}

    }

	void FixedUpdate () {
        PlayGuitar();

    }

    private void PlayGuitar()
    {
		string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            isGuitarOn = !isGuitarOn;
		}
		if (isGuitarOn) {
			GetComponent<PlayerController>().IsMovingD = false;
			GetComponent<PlayerController>().IsMovingU = false;
			GetComponent<PlayerController>().IsMovingL = false;
			GetComponent<PlayerController>().IsMovingR = false;
		}
        anim.SetBool("guitarOn", isGuitarOn);

		if (Camera.main.orthographicSize <= 1) {
			guide[0].SetActive (true);

			while (quantity > 0) {
	            int indexPosition = Random.Range(1, 5);
	            float positionX = 0;
	            switch (indexPosition)
	            {
	                case 1:
	                    positionX = -0.3f;
	                    break;
	                case 2:
	                    positionX = -0.14f;
	                    break;
	                case 3:
	                    positionX = 0.02f;
	                    break;
	                case 4:
	                    positionX = 0.18f;
	                    break;
	            }
				float speed= Random.Range(4f, 20.0f);
				GameObject noteClone = (GameObject)Instantiate (goNote, new Vector3 (positionX, 1.07f, 0), Quaternion.identity, GameObject.Find ("Hobo").transform);
				StartCoroutine (Moving (noteClone,speed,indexPosition));
				quantity--;
			}
            
        }
        else {
			guide[0].SetActive (false);
		}
		 

    }

	IEnumerator Moving(GameObject noteClone, float speed,int indexposition){
		
		while (noteClone.transform.position.y > 0.10f) {
			
			noteClone.transform.Translate (Vector3.down * Time.deltaTime/speed);
			Collider2D noteCol = noteClone.GetComponent<Collider2D> ();

			if (noteCol.IsTouching (guideCol [indexposition-1])){
				switch (indexposition) {
					case 1: if(Input.GetKeyDown (KeyCode.U)) {
								noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
								StartCoroutine (Fade (noteClone));
							}
							break;
					case 2: if(Input.GetKeyDown (KeyCode.I)) {
								noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
								StartCoroutine (Fade (noteClone));
							}
							break;
					case 3:	if(Input.GetKeyDown (KeyCode.O)) {
								noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
								StartCoroutine (Fade (noteClone));
							}
							break;
					case 4:	if(Input.GetKeyDown (KeyCode.P)) {
								noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
								StartCoroutine (Fade (noteClone));
							}
							break;

				}

			}
			if(Input.GetKeyDown (KeyCode.Space)){
				StartCoroutine (Fade (noteClone));
			}
			if (noteClone.transform.position.y <= 0.10f) {
				StartCoroutine(Fade(noteClone));
			}
			yield return null;
		}

	}
	IEnumerator Fade(GameObject noteClone){

		for(float i=1f;i>=0;i-=0.2f){
			Color c = noteClone.GetComponent<SpriteRenderer> ().color;
			c.a = i;
			noteClone.GetComponent<SpriteRenderer> ().color = c;
			if (i <= 0.2) {
				Destroy (noteClone);
			}

			yield return null;
		}

	}
	void OnCollisionEnter2D(Collision2D col){
		print ("funciona");
		if (col.gameObject.tag == "MehScore") {
			print("tocadito");
		}
	}

}
