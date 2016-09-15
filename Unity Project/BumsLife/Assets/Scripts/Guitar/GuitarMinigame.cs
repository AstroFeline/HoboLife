using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;



public class GuitarMinigame : MonoBehaviour {

	public GameObject[] guide,guideGood;
	public GameObject goNote, crap, meh, good, money,goCombo,gotextCombo1,gotextCombo2,npc1,npc2,npc3,npc4;
	public Sprite noteShine;
	public AudioClip themeSong;
	public Text moneyText1, moneyText2,comboTxt1,comboTxt2;

	private AudioSource audios;
    private Animator anim;
    private bool isGuitarOn;
	private Collider2D[] guideCol = new Collider2D[4];
	private Collider2D[] guideGoodCol= new Collider2D[4];
	private int quantity,j=0, score=0,comboAux=0,combo=1,npcCounter=6,auxCounter=0;
	private float totalTime = 0.68f, activeSeconds=0;
	private ArrayList line = new ArrayList();
	private ArrayList repeatPosition = new ArrayList();
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
    
	void Update(){
		
		if ((npcCounter == auxCounter && quantity==-5)){
			print ("npccounter=" + npcCounter + " auxcounter=" + auxCounter);
			/*if (!isGuitarOn) {
				//StartCoroutine (Wait ());
				audios.Stop ();
				GameObject.Find ("Main Camera").GetComponent<CameraController> ().IsZoom = false;
			} else {*/
				audios.Stop ();
				isGuitarOn = false;
				GameObject.Find ("Main Camera").GetComponent<CameraController> ().IsZoom = false;
			//}
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
		if (comboAux >= 1) {
			goCombo.SetActive (true);
			gotextCombo1.SetActive (true);
			gotextCombo2.SetActive (true);
			comboTxt1.text = combo.ToString ();
			comboTxt2.text = combo.ToString ();
			print ("combo=" + combo);
		} else {
			goCombo.SetActive (false);
			gotextCombo1.SetActive (false);
			gotextCombo2.SetActive (false);
			comboTxt1.text = combo.ToString ();
			comboTxt2.text = combo.ToString ();
		}
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
				audios.Play ();
				isSeconds = false;
			}
			//Activamos el sprite de las cuerdas y en cada loop del update tomamos los segundos de la cancion
			guide [0].SetActive (true);
			money.SetActive (true);
			float seconds=0;

			if (j < line.Count)	float.TryParse (line [j].ToString (), out seconds);

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


					float speed = 1;

					//instanciamos cada nota con sus parametros
					GameObject noteClone = (GameObject)Instantiate (goNote, new Vector3 (positionX, 1.07f, 0), Quaternion.identity, GameObject.Find ("Hobo").transform);
					noteClone.transform.localPosition = new Vector3 (positionX, 1.07f, 0);
					//Llamamos al movimiento de la nota
					StartCoroutine (Moving (noteClone, speed, indexPosition));

					if (j < line.Count)	j++;
					quantity--;

					//Hacemos que aparezcan los NPCs
					GeneraNPC();
				}
			}
			if(quantity<=0) {
				print ("npccounter 0=" + npcCounter);

			}

		}
        else {
			auxCounter = 0;
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
			money.SetActive (false);
			combo = 1;
			score = 0;
			gotextCombo1.SetActive (false);
			gotextCombo2.SetActive (false);
			comboTxt1.text = "0";
			comboTxt2.text = "0";
			comboAux = 0;
			repeatPosition.Clear ();

		}
		 

    }

	private IEnumerator Wait(){
		yield return new WaitForSeconds(3);
		//audios.Stop ();
		GameObject.Find ("Main Camera").GetComponent<CameraController> ().IsZoom = false;
	}

	private void GeneraNPC(){
		if (npcCounter > 0) {
			bool found;
			int i = 0;
			int randomPosition=0;
			if (repeatPosition.Count < 6) {
				do {
					i = 0;
					found = false;
					randomPosition = Random.Range (1, 7);
					while (i < repeatPosition.Count) {
						if ((int)repeatPosition [i] == randomPosition) {
							found = true;
						}
						i++;
					}
				} while (found);
				repeatPosition.Add (randomPosition);
			}
			int wichNpc =Random.Range (1, 5);
			GameObject npc=npc1;
			switch (wichNpc) {
			case 1:
				npc = npc1;
				break;
			case 2:
				npc = npc2;
				break;
			case 3:
				npc = npc3;
				break;
			case 4:
				npc = npc4;
				break;
			}

			switch (randomPosition) {
			case 1:
				Instantiate (npc, new Vector3 (-1.7f, -1.3f, 0), Quaternion.identity);
				break;
			case 2:
				Instantiate (npc, new Vector3 (-0.75f, -1.3f, 0), Quaternion.identity);
				break;
			case 3:
				Instantiate (npc, new Vector3 (0.25f, -1.3f, 0), Quaternion.identity);
				break;
			case 4:
				Instantiate (npc, new Vector3 (0.7f, -0.6f, 0), Quaternion.identity);
				break;
			case 5:
				Instantiate (npc, new Vector3 (-3.2f, -0.6f, 0), Quaternion.identity);
				break;
			case 6:
				Instantiate (npc, new Vector3 (-2.7f, -1.3f, 0), Quaternion.identity);
				break;
			}
			npcCounter--;
			auxCounter++;
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

						moneyText1.text = score.ToString ();
						moneyText2.text = score.ToString ();
						comboAux++;
						if (comboAux % 5 == 0) {
							combo +=1;
						}
						score = score + (combo*2);
						//score = score*(int)combo;
						//print ("resulti=" + score);

					}
					break;
				case 2:
					if (Input.GetKeyDown (KeyCode.I)) {
						noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
						StartCoroutine (Fade (noteClone));
						isgood = true;
						moneyText1.text = score.ToString ();
						moneyText2.text = score.ToString ();
						comboAux++;
						if (comboAux % 5 == 0) {
							combo +=1;
						}
						score = score + (combo*2);
						//score = score*(int)combo;
						//print ("resulti=" + score);
					}
					break;
				case 3:
					if (Input.GetKeyDown (KeyCode.O)) {
						noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
						StartCoroutine (Fade (noteClone));
						isgood = true;
						moneyText1.text = score.ToString ();
						moneyText2.text = score.ToString ();
						comboAux++;
						if (comboAux % 5 == 0) {
							combo +=1;
						}
						score = score + (combo*2);
						//score = score*(int)combo;
						//print ("resulti=" + score);
					}
					break;
				case 4:
					if (Input.GetKeyDown (KeyCode.P)) {
						noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
						StartCoroutine (Fade (noteClone));
						isgood = true;
						moneyText1.text = score.ToString ();
						moneyText2.text = score.ToString ();
						comboAux++;
						if (comboAux % 5 == 0) {
							combo +=1;
						}
						score = score + (combo*2);
						//score = score*(int)combo;
						//print ("resulti=" + score);
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
							moneyText1.text = score.ToString ();
							moneyText2.text = score.ToString ();
							comboAux++;
							if (comboAux % 5 == 0) {
								combo +=1;
							}
							score = score + combo;
							//score = score*(int)combo;
							//print ("resulti=" + score);
                            }
						break;
					case 2:
						if (Input.GetKeyDown (KeyCode.I)) {
							noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
							StartCoroutine (Fade (noteClone));
							ismeh = true;
							moneyText1.text = score.ToString ();
							moneyText2.text = score.ToString ();
							comboAux++;
							if (comboAux % 5 == 0) {
								combo +=1;
							}
							score = score + combo;
							//score = score*(int)combo;
							//print ("resulti=" + score);
						}
                            break;
					case 3:
						if (Input.GetKeyDown (KeyCode.O)) {
							noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
							StartCoroutine (Fade (noteClone));
							ismeh = true;
							moneyText1.text = score.ToString ();
							moneyText2.text = score.ToString ();
							comboAux++;
							if (comboAux % 5 == 0) {
								combo +=1;
							}
							score = score + combo;
							//score = score*(int)combo;
							//print ("resulti=" + score);
						}
                            break;
					case 4:
						if (Input.GetKeyDown (KeyCode.P)) {
							noteClone.GetComponent<SpriteRenderer> ().sprite = noteShine;
							StartCoroutine (Fade (noteClone));
							ismeh = true;
							moneyText1.text = score.ToString ();
							moneyText2.text = score.ToString ();
							comboAux++;
							if (comboAux % 5 == 0) {
								combo +=1;
							}
							score = score + combo;
							//score = score*(int)combo;
							//print ("resulti=" + score);
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
                        
					crap.transform.localPosition = new Vector3 (0.05f, 0.6f, 0f);
					crap.SetActive (true);
					good.SetActive (false);
					meh.SetActive (false);
					combo = 1;
					comboAux = 0;
					break;
                case 2:
                    
                    crap.transform.localPosition = new Vector3(0.05f, 0.6f, 0f);
                    crap.SetActive(true);
                    good.SetActive(false);
                    meh.SetActive(false);
					combo = 1;
					comboAux = 0;
					break;
                case 3:
                    
                    crap.transform.localPosition = new Vector3(0.05f, 0.6f, 0f);
                    crap.SetActive(true);
                    good.SetActive(false);
                    meh.SetActive(false);
					combo = 1;
					comboAux = 0;
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

	private void CalculaCombo(){
			
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
	public int Quantity {
		get {
			return this.quantity;
		}
		set {
			quantity = value;
		}
	}
	public int NpcCounter {
		get {
			return this.npcCounter;
		}
		set {
			npcCounter = value;
		}
	}

	public int Score {
		get {
			return this.score;
		}
		set {
			score = value;
		}
	}
}
