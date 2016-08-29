using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {


    private float cameraOrtho;

    // Use this for initialization
	void Start () {
        cameraOrtho = Camera.main.orthographicSize;    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
