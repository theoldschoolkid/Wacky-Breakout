using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bonus block same as normal block but more points
/// </summary>
public class BonusBlock : Blocks {

	[SerializeField]
	GameObject SpeedBlock;

	[SerializeField]
	GameObject FreezeBlock;



	protected override void Start ()  {
		base.Start ();

		blockPoints = ConfigurationUtils.BNSPoints; //initialize points

	}
		

}
