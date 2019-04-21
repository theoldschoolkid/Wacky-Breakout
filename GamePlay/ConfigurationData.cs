using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data, gets the value from a file on the disk
/// </summary>
public class ConfigurationData
{
   

    const string ConfigurationDataFileName = "ConfigurationData.txt";

    // configuration data ---- Need to initialize default values -----

	static float paddleMoveUnitsPerSecond;// = 10f;
	static float ballImpulseForce;// = 200f ;
	static float ballTimer;
	static int minDelay;
	static int maxDelay;
	static int STDbp;
	static int BNSbp;
	static int SPLbp;
	static float FRZd;
	static int SBDur;
	static int SBMag;


	StreamReader input = null;

 

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

	public float BallTimer
	{
		get { return ballTimer; }    
	}

	public int minDelayX
	{
		get { return minDelay; }    
	}

	public int maxDelayX
	{
		get { return maxDelay; }    
	}

	public int STDBlockPoints
	{
		get { return STDbp; }    
	}

	public int BNSBlockPoints
	{
		get { return BNSbp; }    
	}

	public int SPLBlockPoints
	{
		get { return SPLbp; }    
	}

	public float FRZDuration
	{
		get { return FRZd; }    
	}

	public int SpeedBallDuration
	{
		get { return SBDur; }    
	}

	public int SpeedBallMagnitude
	{
		get { return SBMag; }    
	}
   

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. 
    /// </summary>
    public ConfigurationData()
	{
		
		try {
			input = File.OpenText(Path.Combine(Application.streamingAssetsPath,ConfigurationDataFileName));
			string line1 = input.ReadLine();
			string line2 = input.ReadLine();

			string[] Fline = line2.Split(',');
		
			paddleMoveUnitsPerSecond = float.Parse(Fline[0]);
			ballImpulseForce = float.Parse(Fline[1]);
			ballTimer = float.Parse(Fline[2]);
			minDelay = int.Parse(Fline[3]);
			maxDelay = int.Parse(Fline[4]);
			STDbp = int.Parse(Fline[5]);
			BNSbp = int.Parse(Fline[6]);
			SPLbp = int.Parse(Fline[7]);
			FRZd = float.Parse(Fline[8]);
			SBDur = int.Parse(Fline[9]);
			SBMag = int.Parse(Fline[10]);
		}

		catch (Exception e) {
			Debug.Log ("Exception - " + e);
		}

		finally {
			input.Close ();
		}


	
		
  }
   
}
