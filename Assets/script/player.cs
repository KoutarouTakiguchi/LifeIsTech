using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
	public float enegy = 10;
	Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody> ().velocity = transform.right * 30f;


//エネルギーゲージ
		slider = GameObject.Find ("Slider").GetComponent<Slider> ();
		slider.value = enegy;
		
	}
	void OnCollisionEnter(Collider other){
		if (other.gameObject.name == "enemy") {
			enegy--;
		}
	}
}
