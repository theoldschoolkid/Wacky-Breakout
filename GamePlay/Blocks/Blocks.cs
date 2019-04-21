using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// This is the base class for Bonus, Standard and Pickup block
/// </summary>
public class Blocks : MonoBehaviour {


	protected int blockPoints;                                      // set by children, value depends on type of block
	protected IntOneArgEvent HUDpoints = new IntOneArgEvent();      // Creating an Invoker to add HUDpoints

	virtual protected void Start () {

		EventManager.AddBlockInvoker (this);                        // Add this as an Invoker
	}
	

	public void AddHUDAsListner( UnityAction<int> listner) {
		
		HUDpoints.AddListener (listner);                            // Adding Listner to Event manager variable HUDPoints
	}


	virtual protected void OnCollisionEnter2D(Collision2D other) {
		
		if (other.gameObject.tag == "Ball")
        {
			EventManager.NumberOfBlocks--;
		//	AudioManager.Play (AudioClipName.BrickBreak);
			HUDpoints.Invoke(blockPoints);                          // Invoke the listner function
			Destroy (this.gameObject);
		}
	}

}
	
