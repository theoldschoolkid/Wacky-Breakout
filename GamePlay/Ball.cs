using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour {

	Vector2 dir;
	float speed;

    // Ball timer
	Timer ballT;                    // Timer to calculate active duriation of the ball
	Timer SpeedDurationTimer;       // Timer to calculate the amount of time the ball will be in accelarated mode when it hits the speed block

	BallSpawner _ballSpawner;
	bool ballActive = true;
	Rigidbody2D bRd2d;
	float Mag;
	bool checktime = false;

	NoArgEvent Ballspawner = new NoArgEvent();

    Vector2 oldVelocity;
    bool speedEffectActivated = false;

	// Use this for initialization
	void Start () {

		bRd2d = this.GetComponent<Rigidbody2D> ();
		Invoke("AddForceToBall", 2f);                            // call function after 2 seconds.

        // Configuration utils is used to extract values from a file
		dir = new Vector2( Mathf.Sin(0.785398f) , Mathf.Cos(0.785398f) ); 

		speed = ConfigurationUtils.BallImpulseForce;             // Get the value of the speed from the ConfigurationUtils script

        // Add timer componenet to this gameobject, decide how long ball will be active
        ballT = gameObject.AddComponent<Timer> ();      
		ballT.Duration = ConfigurationUtils.BallTimer;  
		ballT.Run ();                                            //Run the timer


        // Add timer componenet to this gameobject, to decide accelerated speed duration
        SpeedDurationTimer =  gameObject.AddComponent<Timer> ();

		_ballSpawner = Camera.main.GetComponent<BallSpawner> ();

		EventManager.SAddListener (SpeedEffect);    // Add SpeedEffect function as Listner
		EventManager.AddBallAsInvoker (this);       // Add this script as Invoker to invoke BallSpawner
	
	}


   void AddForceToBall()  {        
		bRd2d.AddForce (dir * speed, ForceMode2D.Force); 
	}


	void SpeedEffect(float Sduration , float magnitude)
	{
        speedEffectActivated = true;
        oldVelocity = bRd2d.velocity;
        bRd2d.AddForce (bRd2d.velocity * magnitude, ForceMode2D.Force); // Add force in the direction of this gameobject

		SpeedDurationTimer.Duration = Sduration;             // Set the duriation for how much time this effect should be on and run the timer
		SpeedDurationTimer.Run ();
	}


	public void AddBallSpawnerAsListner(UnityAction listner)
	{
		Ballspawner.AddListener (listner);                   //Add listner to Ballspawner event variable
	}



	void Update () {
		
		if (ballT.Running == false) {                       // when the balltimer Runs out 

            ballActive = false;   
			Ballspawner.Invoke (); 
			Destroy (this.gameObject);
		}

		if (SpeedDurationTimer.Finished == true && speedEffectActivated == true) // Set the velocity back to normal once timer runs out
        {
			bRd2d.AddForce (oldVelocity, ForceMode2D.Force);
            speedEffectActivated = false;

        }
		
	}

	void OnBecameInvisible()   // If an active ball goes below destroy it and spawn a new one
	{

		if (ballActive == true && this.transform.position.y < -5) {     			
			Ballspawner.Invoke ();
			Destroy (this.gameObject);
		}

	}





}
