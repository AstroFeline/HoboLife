using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManagerController : MonoBehaviour {

    //Dialogue manager reference.
    public GameObject dBox;
    public bool dialogueActive;
    public GameObject target;
    public Text dText;

    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        dialogueActive = false;
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            dBox.SetActive(false);
            dialogueActive = false;

            thePlayer.canMove = true;
        }
	}

    public void ShowBox(string text)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = text;
        thePlayer.canMove = false;
        Vector3 targetPosition = Camera.main.WorldToScreenPoint(target.transform.localPosition);
        targetPosition.y += 15f;
        dBox.transform.position = targetPosition;


    }
}
