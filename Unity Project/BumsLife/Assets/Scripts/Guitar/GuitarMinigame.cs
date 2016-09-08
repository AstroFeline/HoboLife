using UnityEngine;
using System.Collections;
using System.IO;



public class GuitarMinigame : MonoBehaviour {

	public GameObject[] guide,guideGood;
	public GameObject goNote, crap, meh, good;
	public Sprite noteShine;
	public AudioClip themeSong;

	private AudioSource audios;
    private Animator anim;
    private bool isGuitarOn;
	private Collider2D[] guideCol = new Collider2D[4];
	private Collider2D[] guideGoodCol= new Collider2D[4];
	private int quantity,j=0;
	private float totalTime = 0.68f, activeSeconds=0;
	private ArrayList line = new ArrayList();
	private bool isSeconds = true, reset = true;

    void Start()
    {
		audios = GetComponent<AudioSource> ();
        anim = GetComponent<Animator>();

        //inicializamos los coliders pequeño y grande
		for (int i = 0; i < guide.Length; i++) {
			guideCol[i] = guide[i].GetComponent<Collider2D> ();
			guideGoodCol[i] = guideGood[i].GetComponent<Collider2D> ();
		}

    }
    
	void FixedUpdate () {
		PlayGuitar();

    }
	public void Getlines(){
		if (reset) {
			//obtenemos las lineas y los segundos leyendo del txt
			line = ReadTxt ();

			//fijamos la cantidad de notas que van a haber
			int.TryParse (line [j].ToString (), out quantity);
			j++;
			reset = false;
		}
	}
    public void PlayGuitar()
    {
		Getlines ();
		//Impedimos que le hobo se mueva mientra toca la guitarra
		if (isGuitarOn) {
			GetComponent<PlayerController> ().IsMovingD = false;
			GetComponent<PlayerController> ().IsMovingU = false;
			GetComponent<PlayerController> ().IsMovingL = false;
			GetComponent<PlayerController> ().IsMovingR = false;


		} else {
			audios.Stop();

		}
        //animacion guitarrista
        anim.SetBool("guitarOn", isGuitarOn);

        //si la camara esta enfocada en el guitarrista
		if (Camera.main.orthographicSize <= 1) {
            //tomamos el tiempo de inicio del guitarritas y empieza la cancion
			if (isSeconds) {
				activeSeconds = Time.time;
				audios.clip = themeSong;
				audios.Play();
				isSeconds = false;
			}
            //Activamos el sprite de las cuerdas y en cada loop del update tomamos los segundos de la cancion
			guide[0].SetActive (true);
			float seconds;
			float.TryParse (line[j].ToString(),out seconds);

            //Si el tiempo esta entre los segundos iniciales de cada nota, el tiempo desde el inicio de la guitarra y le sumamos el intervalo en el que tarda la nota en llegar al objetivo
            if (Time.time<=((seconds + activeSeconds+0.01f)+ totalTime) && Time.time>=((seconds  + activeSeconds-0.01f)- totalTime) ) {
				//print ("Segundos actuales=" + Time.time + " objetivo=" + ( (seconds + activeSeconds)-totalTime));
                //mientras haya notas
				if (quantity > 0) {
					//Randomizamos la posicion de cada nota
					int indexPosition = Random.Range (1, 5);
					float positionX = 0;
					switch (indexPosition) {
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


					float speed = 1;//Random.Range(1,4) si queremos meterle dificultad extra

					//instanciamos cada nota con sus parametros
					GameObject noteClone = (GameObject)Instantiate (goNote, new Vector3 (positionX, 1.07f, 0), Quaternion.identity, GameObject.Find ("Hobo").transform);
					noteClone.transform.localPosition = new Vector3 (positionX, 1.07f, 0);
					//Llamamos al movimiento de la nota
					StartCoroutine (Moving (noteClone, speed, indexPosition));

					if (j < line.Count)
						j++;
					quantity--;
					print ("cantidad=" + quantity);
				}


			}
			if(quantity<=0) {
				audios.Stop ();
				isGuitarOn = false;
				GameObject.Find ("Main Camera").GetComponent<CameraController> ().IsZoom = false;
			}
		}
        else {
			guide[0].SetActive (false);
			line.Clear ();
			quantity = 0;
			crap.SetActive (false);
			meh.SetActive (false);
			good.SetActive (false);
			j = 0;
			reset = true;
			audios.Stop ();
			isSeconds = true;
		}
		 

    }

	private IEnumerator Moving(GameObject noteClone, float speed,int indexposition){
       
		while (noteClone.transform.position.y > 0.10f) {
			
			noteClone.transform.Translate (Vector3.down * Time.deltaTime/speed);
			Collider2D noteCol = noteClone.GetComponent<Collider2D> ();
            //Si la nota toca el collider good
			if (noteCol.IsTouching (guideGoodCol [indexposition - 1])) {
				int scorePosition = Random.Range (1, 4);
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
                        crap.SetActive(false);
                        }
					break;
				case 2:
					if (isgood) {
						good.transform.localPosition = new Vector3 (1.35f, 0.7f, 0f);
						meh.SetActive (false);
						good.SetActive (true);
                        crap.SetActive(false);
                        }
					break;
				case 3:
					if (isgood) {
						good.transform.localPosition = new Vector3 (1f, 0.07f, 0f);
						meh.SetActive (false);
						good.SetActive (true);
                        crap.SetActive(false);
                        }
					break;
				}

			} else {
				//Si la nota toca el collider meh
				if (noteCol.IsTouching (guideCol [indexposition - 1])) {
					int scorePosition = Random.Range (1, 4);
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
                            crap.SetActive(false);
                            }
                            
						break;
					case 2:
						if (ismeh) {
							meh.transform.localPosition = new Vector3 (1.35f, 0.7f, 0f);
                            good.SetActive (false);
							meh.SetActive (true);
                            crap.SetActive(false);
                            }
                            
                            break;
					case 3:
						if (ismeh) {
							meh.transform.localPosition = new Vector3 (1f, 0.07f, 0f);
							good.SetActive (false);
							meh.SetActive (true);
                            crap.SetActive(false);
                            }
                            
                            break;
					}


                }
			}
            
			if (noteClone.transform.position.y <= 0.10f) {
				int scorePosition = Random.Range(1, 4);
                switch (scorePosition)
                {
                    case 1:
                        
                        crap.transform.localPosition = new Vector3(0.05f, 0.6f, 0f);
                        crap.SetActive(true);
                        good.SetActive(false);
                        meh.SetActive(false);
                        

                        break;
                    case 2:
                        
                        crap.transform.localPosition = new Vector3(0.05f, 0.6f, 0f);
                        crap.SetActive(true);
                        good.SetActive(false);
                        meh.SetActive(false);
                        

                        break;
                    case 3:
                        
                        crap.transform.localPosition = new Vector3(0.05f, 0.6f, 0f);
                        crap.SetActive(true);
                        good.SetActive(false);
                        meh.SetActive(false);
                        

                        break;
                }
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

	private ArrayList ReadTxt(){
		StreamReader reader = new StreamReader (Application.dataPath + "/StreamingAssets" + "/" + "Song.txt");
		ArrayList line = new ArrayList ();
		int i = 0;
		while (!reader.EndOfStream) {
			line.Add(reader.ReadLine ());
			i++;
		}

		return line;
	}

	public bool IsGuitarOn {
		get {
			return this.isGuitarOn;
		}
		set {
			isGuitarOn = value;
		}
	}

}
