using UnityEngine;
using System.Collections;
using System.IO;



public class GuitarMinigame : MonoBehaviour {

	public GameObject[] guide,guideGood;
	public GameObject goNote, crap, meh, good;
	public Sprite noteShine;

    private Animator anim;
    private bool isGuitarOn;
	private Collider2D[] guideCol = new Collider2D[4];
	private Collider2D[] guideGoodCol= new Collider2D[4];
	private int quantity,j=0;
	private float totalTime = 0.68f, activeSeconds=0;
	private ArrayList line = new ArrayList();
	private bool isSeconds = true;

    void Start()
    {
        anim = GetComponent<Animator>();
		for (int i = 0; i < guide.Length; i++) {
			guideCol[i] = guide[i].GetComponent<Collider2D> ();
			guideGoodCol[i] = guideGood[i].GetComponent<Collider2D> ();
		}

		line = ReadTxt ();

		int.TryParse(line[j].ToString(),out quantity);
		j++;


    }

	void FixedUpdate () {
        PlayGuitar();

    }

    private void PlayGuitar()
    {
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
			if (isSeconds) {
				activeSeconds = Time.time;
				isSeconds = false;
			}
			guide[0].SetActive (true);
			float seconds;
			float.TryParse (line[j].ToString(),out seconds);


			if (Time.time<=(seconds + totalTime + activeSeconds+0.01f) && Time.time>=(seconds + totalTime + activeSeconds-0.01f) ) {
				print ("Segundos actuales=" + Time.time + " objetivo=" + (seconds + totalTime+activeSeconds) +" longitud= "+ j);
				if (quantity > 0) {
		            int indexPosition = Random.Range(1, 5);
		            float positionX = 0;
		            switch (indexPosition)
		            {
		                case 1:
		                    positionX = 0.48f;
		                    break;
		                case 2:
		                    positionX = 0.64f;
		                    break;
		                case 3:
		                    positionX = 0.80f;
		                    break;
		                case 4:
		                    positionX = 0.96f;
		                    break;
		            }


					float speed = 3;//Random.Range(1,4);
					GameObject noteClone = (GameObject)Instantiate (goNote, new Vector3 (positionX, 1.07f, 0), Quaternion.identity, GameObject.Find ("Hobo").transform);
					noteClone.transform.localPosition=new Vector3(positionX,1.07f, 0);
					StartCoroutine (Moving (noteClone, speed, indexPosition));

					if(j<line.Count)j++;
					quantity--;

				}

			}
            
        }
        else {
			guide[0].SetActive (false);
		}
		 

    }

	private IEnumerator Moving(GameObject noteClone, float speed,int indexposition){
		
		while (noteClone.transform.position.y > 0.10f) {
			
			noteClone.transform.Translate (Vector3.down * Time.deltaTime/speed);
			Collider2D noteCol = noteClone.GetComponent<Collider2D> ();

			//Si la nota toca el collider good
			if (noteCol.IsTouching (guideGoodCol [indexposition - 1])) {
				print ("GOOOOOOOD");
				print ("Tiempo tocar" + (indexposition - 1) + "=" + Time.time);
				int scorePosition = Random.Range (1, 3);
				bool isgood = false;
				switch (indexposition) {
				case 1:
					if (Input.GetKeyDown (KeyCode.U)) {
						noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
						StartCoroutine (Fade (noteClone));
						isgood = true;
					}
					break;
				case 2:
					if (Input.GetKeyDown (KeyCode.I)) {
						noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
						StartCoroutine (Fade (noteClone));
						isgood = true;
					}
					break;
				case 3:
					if (Input.GetKeyDown (KeyCode.O)) {
						noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
						StartCoroutine (Fade (noteClone));
						isgood = true;
					}
					break;
				case 4:
					if (Input.GetKeyDown (KeyCode.P)) {
						noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
						StartCoroutine (Fade (noteClone));
						isgood = true;
					}
					break;
				}
				switch (scorePosition) {
				case 1:
					if (isgood) {
						good.transform.localPosition = new Vector3 (0.05f, 0.6f, 0f);
						meh.SetActive (false);
						good.SetActive (true);
					}
					break;
				case 2:
					if (isgood) {
						good.transform.localPosition = new Vector3 (1.35f, 0.7f, 0f);
						meh.SetActive (false);
						good.SetActive (true);
					}
					break;
				case 3:
					if (isgood) {
						good.transform.localPosition = new Vector3 (1f, 0.07f, 0f);
						meh.SetActive (false);
						good.SetActive (true);
					}
					break;
				}

			} else {
				//Si la nota toca el collider meh
				if (noteCol.IsTouching (guideCol [indexposition - 1])) {
					print ("Tiempo tocar" + (indexposition - 1) + "=" + Time.time);
					int scorePosition = Random.Range (1, 3);
					bool ismeh = false;
					switch (indexposition) {
					case 1:
						if (Input.GetKeyDown (KeyCode.U)) {
							noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
							StartCoroutine (Fade (noteClone));
							ismeh = true;
						}
						break;
					case 2:
						if (Input.GetKeyDown (KeyCode.I)) {
							noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
							StartCoroutine (Fade (noteClone));
							ismeh = true;
						}
						break;
					case 3:
						if (Input.GetKeyDown (KeyCode.O)) {
							noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
							StartCoroutine (Fade (noteClone));
							ismeh = true;
						}
						break;
					case 4:
						if (Input.GetKeyDown (KeyCode.P)) {
							noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
							StartCoroutine (Fade (noteClone));
							ismeh = true;
						}
						break;
					}
					switch (scorePosition) {
					case 1:
						if (ismeh) {
							meh.transform.localPosition = new Vector3 (0.05f, 0.6f, 0f);
							good.SetActive (false);
							meh.SetActive (true);
						}
						break;
					case 2:
						if (ismeh) {
							meh.transform.localPosition = new Vector3 (1.35f, 0.7f, 0f);
							good.SetActive (false);
							meh.SetActive (true);
						}
						break;
					case 3:
						if (ismeh) {
							meh.transform.localPosition = new Vector3 (1f, 0.07f, 0f);
							good.SetActive (false);
							meh.SetActive (true);
						}
						break;
					}

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
	private IEnumerator Fade(GameObject noteClone){

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
	private void OnCollisionEnter2D(Collision2D col){
		print ("funciona");
		if (col.gameObject.tag == "MehScore") {
			print("tocadito");
		}
	}

	private ArrayList ReadTxt(){
		StreamReader reader = new StreamReader (Application.dataPath + "/StreamingAssets" + "/" + "Song.txt");
		ArrayList line = new ArrayList ();
		int i = 0;
		while (!reader.EndOfStream) {
			line.Add(reader.ReadLine ());
			print ("linea= " + line [i]);
			i++;
		}

		return line;
	}

}
