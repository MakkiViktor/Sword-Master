using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//Test, ha lesz animáció, majd át kell írni
	public float speed;
	public StanceDatabase stanceDataBase;
	Priate Stance

	void Start(){
		
	}
		
	void Update () {
		Vector3 Move = new Vector3();
		Move.x += Time.deltaTime * speed * Input.GetAxis ("Horizontal");
		Move.z += Time.deltaTime * speed * Input.GetAxis ("Vertical");
		transform.position += Move;
	}
}
