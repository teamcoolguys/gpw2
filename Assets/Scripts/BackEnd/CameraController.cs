using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	//privates
	private Camera cameraFreeWalk;
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool Rotate;
	private Quaternion eulerRot;
	private float totalRotation = 0;
	//publics
	public float zoomSpeed = 20f;
	public float minZoomFOV = 10f;
	public float maxZoomFOV = 100f;
	public float Rotation = 30; // degrees per second
	public float RotationSpeed = 10;
	public float panSpeed = 4.0f;
	public float Speed = 5.0f;

	public void ZoomIn()
	{
		cameraFreeWalk.fieldOfView -= zoomSpeed/8;
		if (cameraFreeWalk.fieldOfView < minZoomFOV)
		{
			cameraFreeWalk.fieldOfView = minZoomFOV;
		}
	}
	public void ZoomOut()
	{
		cameraFreeWalk.fieldOfView += zoomSpeed/8;
		if (cameraFreeWalk.fieldOfView > maxZoomFOV)
		{
			cameraFreeWalk.fieldOfView = maxZoomFOV;
		}
	}

	// Use this for initialization
	void Start () 
	{
		cameraFreeWalk = Camera.main;
		eulerRot = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		Rotate = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			ZoomIn();
		}
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			ZoomOut();
		}
		if (Input.GetKeyDown("left"))
		{
			eulerRot.y += Rotation;
			Rotate = true;
			Debug.Log("left");
		}
		if (Input.GetKeyDown("right"))
		{
			eulerRot.y *= Rotation;
			Rotate = true;
			Debug.Log("right");
			//transform.rotation = Quaternion.Slerp(transform.rotation,new Quaternion(transform.rotation.x, transform.rotation.y + goodDegs, transform.rotation.z, transform.rotation.w), Time.deltatime * Smooth);
		}
		if(Rotate)
		{
			eulerRot = Quaternion.AngleAxis(Rotation, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, eulerRot, Time.deltaTime); 
			Debug.Log (eulerRot);
		}
		if(Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;
		}
		if (!Input.GetMouseButton(1)) isPanning=false;
		// Move the camera on it's XY plane
		if (isPanning)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			Vector3 move = new Vector3(pos.x * panSpeed, 0, pos.y * panSpeed);
			transform.Translate(move, UnityEngine.Space.Self);
		}
	}
}
