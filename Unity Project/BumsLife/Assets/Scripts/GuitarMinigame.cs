using UnityEngine;
using System.Collections;

public class GuitarMinigame : MonoBehaviour {

	public GameObject guide, goNote;

    private Animator anim;
    private bool isGuitarOn;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
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
			guide.SetActive (true);
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
                    positionX = 0.8f;
                    break;
                case 4:
                    positionX = 0.96f;
                    break;
            }
            Note no = new Note(goNote, new Vector3(positionX, 1.07f, 0), 2);
            no.Move();
            //y arriba= 1.07, y abajo= 0.32
            //Note no = new Note (goNote,4, 6.3f);
        }
        else {
			guide.SetActive (false);
		}
		

    }
}
