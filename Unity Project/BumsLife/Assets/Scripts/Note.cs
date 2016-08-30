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
		goNote.transform.Translate(Vector3.down * Time.deltaTime * Speed);
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
