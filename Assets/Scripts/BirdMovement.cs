using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed = 150f;
	public float forwardSpeed = .6f;
	
	bool didFlap = false;
	bool dead = false;

	public bool godMode = false;

	float deathCoolDown;

	Animator animator;

	// Use this for initialization
	void Start () {

		animator = transform.GetComponentInChildren<Animator> ();


	
	}
	//Graphics update here
	void Update(){

		if (dead) {

			deathCoolDown -= Time.deltaTime;

			if(deathCoolDown <= 0){
				if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {

				Application.LoadLevel(Application.loadedLevel);
				}
			}

				
		
				} else {


						if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {

								didFlap = true;



						}
				}
		}
	
	// Update is called once per frame
	// Physics updates here
	void FixedUpdate () {

		if (dead)
						return;

		rigidbody2D.AddForce(Vector2.right * forwardSpeed);

		if(didFlap){

			rigidbody2D.AddForce(Vector2.up * flapSpeed);

			animator.SetTrigger("DoFlap");

			didFlap = false;
		}

		if (rigidbody2D.velocity.y > -0.5f) {
			float angle = Mathf.Lerp(0, 15, rigidbody2D.velocity.y);
			transform.rotation = Quaternion.Euler(0, 0, angle);

		} else {


			float angle = Mathf.Lerp(0, -90, -rigidbody2D.velocity.y / 3f);
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}

		
		}


	void OnCollisionEnter2D(Collision2D collision){

		if (godMode == true)
						return;

		animator.SetTrigger ("Death");
		dead = true;

		deathCoolDown = 0.5f;
	}





}
