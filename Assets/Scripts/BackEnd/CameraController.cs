﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	//privates
	private Camera cameraFreeWalk;
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool Rotate;
	private Quaternion eulerRot;
	//publics
	public float zoomSpeed = 20f;
	public float minZoomFOV = 10f;
	public float maxZoomFOV = 100f;
	public float Rotation = 30; // degrees per second
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
		}
		if (Input.GetKeyDown("right"))
		{
			eulerRot.y -= Rotation;
			Rotate = true;
			//transform.rotation = Quaternion.Slerp(transform.rotation,new Quaternion(transform.rotation.x, transform.rotation.y + goodDegs, transform.rotation.z, transform.rotation.w), Time.deltatime * Smooth);
		}
		if(Rotate)
		{
			transform.rotation  = Quaternion.Lerp(transform.rotation, eulerRot, Time.deltaTime * Speed);
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
