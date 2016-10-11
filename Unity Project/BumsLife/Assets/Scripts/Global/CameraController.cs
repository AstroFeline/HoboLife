using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    
    public GameObject target;
    public float distance;
	public bool isTarget;

	private float camOrthographic;
	private Vector3 camInitPosition;
	private bool isZoom=false;
	
	void Start(){
		camOrthographic = Camera.main.orthographicSize;
		camInitPosition = transform.position;
	}
	void Update () {

        if (IsTarget)
            transform.position = target.transform.position- new Vector3 (0,0, distance);
		if (isZoom) {
			if (Camera.main.orthographicSize > 1) {
				ZoomIn ();
			}
		} else {
			if (Camera.main.orthographicSize < camOrthographic) {
				ZoomOut ();
			} 
		}
	}

    public void ZoomIn(){
		transform.position = Vector3.MoveTowards(transform.position,target.transform.position- new Vector3(0, 0, Camera.main.orthographicSize),0.1f);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, Camera.main.orthographicSize - 500, Time.deltaTime * 0.7f);
    }

	public void ZoomOut(){
		transform.position = Vector3.MoveTowards(transform.position,camInitPosition + new Vector3 (0, 0, camOrthographic),0.1f);
		Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, camOrthographic + 500, Time.deltaTime * 0.7f);
	}

    public bool IsTarget
    {
        get
        {
            return isTarget;
        }

        set
        {
            isTarget = value;
        }
    }
	public bool IsZoom {
		get {
			return this.isZoom;
		}
		set {
			isZoom = value;
		}
	}
}
