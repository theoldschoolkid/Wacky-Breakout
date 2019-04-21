using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>

public static class ConfigurationUtils
{
    #region Properties
    
	static ConfigurationData CD;
	static float PM;
	static float BI;
	static float BT;
	static int MND;
	static int MXD;
	static int STDbp;
	static int BNSbp;
	static int SPLbp;
	static float FRZd;
	static int SBDur;
	static int SBMag;

    public static float PaddleMoveUnitsPerSecond
    {
		get { return PM; }
    }

	public static float BallImpulseForce
	{
		get { return BI; }
	}

	public static float BallTimer 
	{
		get { return BT; }
	}

	public static int minDelay 
	{
		get { return MND; }
	}

	public static int maxDelay 
	{
		get { return MXD; }
	}

	public static int SBPoints 
	{
		get { return STDbp; }
	}

	public static int BNSPoints 
	{
		get { return BNSbp; }
	}

	public static int SPLPoints 
	{
		get { return SPLbp; }
	}

	public static float FRZDuration
	{
		get { return FRZd; }
	}

	public static int SpeedBallDuration 
	{
		get { return SBDur; }
	}

	public static int SpeedBallMagnitude 
	{
		get { return SBMag; }
	}

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {

		ConfigurationData CD = new ConfigurationData();

		PM = CD.PaddleMoveUnitsPerSecond;

		BI = CD.BallImpulseForce;

		BT = CD.BallTimer;

		MND = CD.minDelayX;

		MXD = CD.maxDelayX;

		STDbp = CD.STDBlockPoints;

		BNSbp = CD.BNSBlockPoints;

		SPLbp = CD.SPLBlockPoints;

		FRZd = CD.FRZDuration;

		SBDur = CD.SpeedBallDuration;

		SBMag = CD.SpeedBallMagnitude;
    }
}
