using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	GameObject prefabBall;

	int minD;   // Min and max delay to spawn a new ball
	int maxD;
	float tx;
	float count;
	Timer spawnBT;  // SpawnBallTimer, when the timer is running new ball should not be spawned

	bool retrySpawn = false;
	Vector2 spawnLocationMin;
	Vector2 spawnLocationMax;


	void Start () {

		EventManager.AddBallSpawnerListner (SpawnBall);

		minD = ConfigurationUtils.minDelay;
		maxD = ConfigurationUtils.maxDelay;
		spawnBT = gameObject.AddComponent<Timer> ();

        TempBall(); // Create a temporary ball to get its dimension, the dimesion is used to avoid overlaping of ball spawn at same location

        SpawnBall();  // Spawn the first ball at the start of the game

        spawnTimer ();  // Start the timer to spawn the next ball
         		       	
	}


	 void SpawnBall()
	{
		if (Physics2D.OverlapArea (spawnLocationMin, spawnLocationMax) == null)  // Check if there is any overlap in the spawn location
        {
			retrySpawn = false;
			GameObject ball = Instantiate (prefabBall) as GameObject; // if no then instantiate the ball
		}
		else
		{
			retrySpawn = true;  // If yes then try respawining in next frame
		}

	}



	void spawnTimer()
	{		
		tx = Random.Range (minD, maxD);
		spawnBT.Duration = tx;
		spawnBT.Run ();	
	}


	void Update () {

		if(spawnBT.Running == false)  // If spawnball timer is not running then it means its time to spawn a new ball
		{
			SpawnBall ();               // Spawn the new ball
			spawnTimer ();              // Start the timer again
	    }
		if (retrySpawn) {    // checking in every frame that if retrySpawn is true or false 
			SpawnBall ();
		}

   }

    void TempBall()
    {
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        CircleCollider2D collider = tempBall.GetComponent<CircleCollider2D>();
        float ballColliderHalfWidth = collider.radius / 2;
        float ballColliderHalfHeight = collider.radius / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfHeight,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);
    }
}

