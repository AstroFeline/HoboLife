using UnityEngine;

[System.Serializable]

class Note {
	private GameObject goNote;
	private Vector3 positionInit;
	private float speed;
  

	public Note(GameObject no, Vector3 pos, float sp){
		goNote = no;
		positionInit = pos;
		speed = sp;
	}

	public void Move(){
        Debug.Log("is moving "+goNote.name);
        goNote.transform.Translate(Vector3.down * Time.deltaTime * Speed);
        if (goNote.transform.position.y <= 0.32)
        {
           goNote.GetComponent<SpriteRenderer>().sprite = Resources.Load("NotaBrillo") as Sprite;
           Debug.Log("is shining " + goNote.name);
        }
	}

	public GameObject GoNote{
		get {
			return this.goNote;
		}
		set {
			goNote = value;
		}
	}
	public Vector3 PositionInit {
		get {
			return this.positionInit;
		}
		set {
			positionInit = value;
		}
	}

	public float Speed {
		get {
			return this.speed;
		}
		set {
			speed = value;
		}
	}
}
