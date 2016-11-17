using UnityEngine;
using System.Collections;

public class StealthManagerController : MonoBehaviour {
    //Esta clase controlará la interacción entre el hobo
    //Y la zona de stealth.
    // Use this for initialization

    public bool stealthActive;
    public GameObject ass;
    private PlayerController thePlayer;


    void Start () {
        stealthActive = false;
        thePlayer = GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (stealthActive)
        {
            //paramos el movimiento del jugador.
            stopPlayerMovement();
        }
	}

    void stopPlayerMovement() {
        thePlayer.IsMovingD = false;
        thePlayer.IsMovingU = false;
        thePlayer.IsMovingL = false;
        thePlayer.IsMovingR = false;
    }
}
