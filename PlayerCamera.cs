using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	// Use this for initialization
	public Transform lookAt;
	public float MaxDistance = 5.0f;
	public Transform target;
	public float sensivityX = 10.0f;
	public float sensivityY = 10.0f;
	public float Y_ANGLE_MIN = -50.0f;
	public float Y_ANGLE_MAX = 50.0f;

	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private Transform camTransform;
	private float distance;
	private Camera cam;
	private Vector3[] corners;
	void Start () {
		camTransform = transform;
		cam = Camera.main;
		corners = new Vector3[4];
	}
	
	// Update is called once per frame
	void Update () {
		currentX += Input.GetAxis ("Mouse X") * sensivityX;
		currentY += Input.GetAxis ("Mouse Y") * sensivityY;

		currentY = Mathf.Clamp (currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

		countViewCorners ();
		CheckCollision();

		// TODO ezt sokszor kell hivni

			
	}

	void LateUpdate(){
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);

		camTransform.position = target.position + rotation * dir;
		camTransform.LookAt(lookAt.position);
	}


	//TODO ki kellene talalni, hogyan van az utkozes
	private void CheckCollision(){
		RaycastHit hitInfo;
		foreach (var point in corners) {
			if (Physics.Raycast(camTransform.position, point, out hitInfo, MaxDistance)) {
				if(hitInfo.collider.tag == "enviroment")
					distance = hitInfo.distance * 0.8f; 
			}
		}
	}

	//TODO nem biztos hogy jo
	private void countViewCorners(){
		Vector3 RayDir = (lookAt.position - camTransform.position).normalized;

		float offsetZ = cam.nearClipPlane;
		float offsetX = offsetZ * Mathf.Tan (cam.fieldOfView / 2);
		float offsetY = offsetX / cam.aspect;

		Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);

		corners[0] = Vector3(-offsetX, offsetY, offsetZ) + camTransform.position + rotation * RayDir;
		corners[1] = Vector3(offsetX, offsetY, offsetZ) + camTransform.position + rotation * RayDir;
		corners[2] = Vector3(-offsetX, -offsetY, offsetZ) + camTransform.position + rotation * RayDir;
		corners[3] = Vector3(offsetX, -offsetY, offsetZ) + camTransform.position + rotation * RayDir;
	}
}
