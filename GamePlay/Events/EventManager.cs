using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event manager to add invokers and Listner, static class 
/// </summary>
public static class EventManager {

	//To KeepTrack of Blocks
	public static int NumberOfBlocks = 0;

	//For FREEZE EFFECT
	static PickupBlock Finvoker;
	static UnityAction<float> Flistener;

	//For SPEED EFFECT
	static PickupBlock Sinvoker;
	static UnityAction<float , float> Slistener;

	// HUD Points
	static Blocks blockInvoker;
	static UnityAction<int> HUDlistner;

	// Ball Spawner
	static Ball ballInvoker;
	static UnityAction ballSpawnerListner;


	// METHODS
	//For FREEZE EFFECT

	public static void AddInvoker(PickupBlock script)
	{
		Finvoker = script;
		if (Flistener != null)
		{
			Finvoker.AddFreezerEffectListener(Flistener);
		}
	}


	public static void AddListener(UnityAction<float> handler)
	{
		Flistener = handler;
		if (Finvoker != null)
		{
			Finvoker.AddFreezerEffectListener(Flistener);            
		}
	}


	//For SPEED EFFECT

	public static void SAddInvoker(PickupBlock script)
	{
		Sinvoker = script;
		if (Slistener != null)
		{
			Sinvoker.AddFSpeedEffectListener(Slistener);
		}
	}


	public static void SAddListener(UnityAction<float , float> handler)
	{
		Slistener = handler;
		if (Sinvoker != null)
		{
			Sinvoker.AddFSpeedEffectListener(Slistener);            
		}
	}


	// For HUD points

	public static void AddBlockInvoker(Blocks Invoker)
	{
		blockInvoker = Invoker;
		if (HUDlistner != null) {
			blockInvoker.AddHUDAsListner (HUDlistner);
		}

	}


	public static void AddHUDListner(UnityAction<int> listner)
	{
		
		HUDlistner = listner;
		if (blockInvoker != null) {
			blockInvoker.AddHUDAsListner (HUDlistner);	
		}
	}


	// For BallSpawner

	public static void AddBallAsInvoker(Ball Invoker)
	{
		
		ballInvoker = Invoker;
		if (ballSpawnerListner != null) {
			ballInvoker.AddBallSpawnerAsListner (ballSpawnerListner);
		}

	}


	public static void AddBallSpawnerListner(UnityAction listner)
	{
		
		ballSpawnerListner = listner;
		if (ballInvoker != null) {
			ballInvoker.AddBallSpawnerAsListner (ballSpawnerListner);	
		}
	}


}
