using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PickupBlock : Blocks {  // Inheriting from blocks

	int SBDuration;
	int SBMagnitude;


	float freezeDuration;
	FreezerEffectActivated freezEffActEvent = new FreezerEffectActivated ();  // Create Event system for freeze and speed effect
	SpeedEffectActivated speedEffActEvent = new SpeedEffectActivated();



	// Use this for initialization
	protected override  void Start ()  {
		base.Start ();                              // Run the base function start first 

		SBDuration = ConfigurationUtils.SpeedBallDuration;
		SBMagnitude = ConfigurationUtils.SpeedBallMagnitude;

		freezeDuration = ConfigurationUtils.FRZDuration;
		blockPoints = ConfigurationUtils.SPLPoints;

		EventManager.AddInvoker(this);
		EventManager.SAddInvoker (this);
	
	}

		
	public void AddFreezerEffectListener(UnityAction<float> listener)
	{
		freezEffActEvent.AddListener (listener);
	}

	public void AddFSpeedEffectListener(UnityAction<float , float> listener2)
	{
		speedEffActEvent.AddListener (listener2);
	}
		
	protected override void  OnCollisionEnter2D(Collision2D other)
	{
		
		if (this.gameObject.tag == "FreezeBlock") {     // If this is a freeze block
			
			freezEffActEvent.Invoke (freezeDuration);
			base.OnCollisionEnter2D (other);
		}

		if (this.gameObject.tag == "SpeedBlock")  {     // If this is a SpeedBlock
            speedEffActEvent.Invoke (SBDuration, SBMagnitude);
			base.OnCollisionEnter2D (other);
		}
	}

}
