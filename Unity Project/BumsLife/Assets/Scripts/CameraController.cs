using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.transform.position - new Vector3 (0,0, distance);
	}
}
