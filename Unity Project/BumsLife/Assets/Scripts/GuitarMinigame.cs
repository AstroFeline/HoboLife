using UnityEngine;
using System.Collections;

public class GuitarMinigame : MonoBehaviour {

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
            print("guitarra " + isGuitarOn);
        }
        anim.SetBool("guitarOn", isGuitarOn);
    }
}
