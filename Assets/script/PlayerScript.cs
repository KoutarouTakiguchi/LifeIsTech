using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	public float enegy = 0.0f;
	public Rigidbody rb;
	public GameObject rect;
	public GameObject pl;
	float angle;
	Vector3 rotee;

	public Slider slider;


    [SerializeField]public Transform  target;
	[SerializeField]public Transform  cursor;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (10, 10, 0, ForceMode.VelocityChange);

		slider.maxValue = enegy;
		slider.value = enegy;
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 targetDir = rotee - transform.position;
	    //angle = Vector3.Angle (targetDir, transform.forward);
		//transform.LookAt (rotee);
		transform.eulerAngles = rb.velocity;

		slider.value = enegy;

	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.name == "enemy") {
			enegy--;
		}else if(other.gameObject.tag == "wall") {
			//rotee = pl.transform.position;


		}
	}
	public void UseEnegy(float i){
		enegy = i;
	}
//	void rote(){
//		rotee = transform.position;
//	}
}