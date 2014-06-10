using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {
	
	static bool seen = false;

	// Use this for initialization
	void Start () {
		if (!seen) {

			GetComponent<SpriteRenderer>().enabled = true;
			Time.timeScale = 0;
		}

		seen = true;
		Time.timeScale = 0;


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 0 && (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space))) {
				
			Time.timeScale = 1;
			GetComponent<SpriteRenderer>().enabled = false;
		   }
		}
	
	}

