using UnityEngine;
using System.Collections;

public class ParallaxMover : MonoBehaviour {


	Rigidbody2D player;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		
		
		if (player_go == null) {
			
			Debug.LogError("No player object found");
			
			return;
		}
		
		player = player_go.rigidbody2D;

	}

	// Update is called once per frame
	void FixedUpdate () {
	
		float vel = player.velocity.x * 0.75f;

		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;

	
	}
}
