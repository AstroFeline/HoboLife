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
		} else {
			guide.SetActive (false);
		}
		int indexPosition = Random.Range (1, 5);
		float position;
		switch (indexPosition) {
			case 1: position=0.48f;
				break;
			case 2: position=0.64f;
				break;
			case 3: position=0.8f;
				break;
			case 4: position=0.96f;
				break;
		}

		//Note no = new Note (goNote,4, 6.3f);

    }
}
