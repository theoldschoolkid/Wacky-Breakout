using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock: Blocks {

	[SerializeField]
	Sprite RedSprite, BlueSprite, GreenSprite, VoiletSprite, OrangeSprite;

	protected override void Start ()  {
		base.Start ();

        // When a new standard block is created a random color sprite is assigned

		blockPoints = ConfigurationUtils.SBPoints;
		int x = Random.Range (0, 5);

		switch(x)
		{
		case 0: 
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = RedSprite;
			break;
		case 1: 
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = BlueSprite;
			break;
		case 2: 
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = GreenSprite;
			break;
		case 3: 
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = VoiletSprite;
			break;
		case 4: 
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = OrangeSprite;
			break;
		}
	}

}
