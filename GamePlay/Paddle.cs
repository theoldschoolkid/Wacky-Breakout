using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	
	float speed;
	Rigidbody2D rd;
	Vector2 dirR = new Vector2(2 , 0);
	Vector2 dirL = new Vector2(-2 , 0);
	float width;
	bool freeze = false;
	float ftime = 0;
	Timer freezeTimer;

	void Start()
	{
		speed = ConfigurationUtils.PaddleMoveUnitsPerSecond;
		rd = this.GetComponent<Rigidbody2D> ();
	//	width = (this.GetComponent<BoxCollider2D> ().size.x) / 2.0f;  

		EventManager.AddListener(freezeEffectImplement);

		freezeTimer = gameObject.AddComponent<Timer> ();

	}

	void freezeEffectImplement(float freezetime)
	{

		ftime += freezetime;
		freezeTimer.Duration = ftime;
		freeze = true;
		freezeTimer.Run ();  // run freeze effect timer

		//this.transform.position = new Vector3 (0, transform.position.y, transform.position.z);

	}



	// Update is called once per frame
	void FixedUpdate () {
		
		if (freeze == false) 
		{
            // Paddle movement 
            if (Input.GetAxisRaw ("Horizontal") == 1) {
				rd.MovePosition (rd.position + dirR * speed * Time.fixedDeltaTime);	
			} else if (Input.GetAxisRaw ("Horizontal") == -1) {
				rd.MovePosition (rd.position + dirL * speed * Time.fixedDeltaTime);
			} 

		}
		
		if (freezeTimer.Finished == true) {
			freeze = false;
		}
	
	}
}
