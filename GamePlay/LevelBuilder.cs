using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {


    [SerializeField]
    GameObject paddlePrefab, blockPrefab, bonusBlockPrefab, speedBlockPrefab, freezeBlockPrefab;

	GameObject firstBlock;
	GameObject restBlock;
	Vector2 firstBlockPos;
	Vector2 blockPos;

	float width;
	float height;

	void Start () {
		
		//get width and height of the block to build rows
		GetWidthHeight ();

		GameObject paddle = Instantiate (paddlePrefab) as GameObject;

		//First Block will be instantiated at the Edge (-9.85,4) which is the trans.pos of the BlockPrefab
		GameObject firstBlock = Instantiate (blockPrefab) as GameObject;
		firstBlockPos = firstBlock.transform.position; 
		blockPos = firstBlockPos;
		Destroy (firstBlock);

		StartCoroutine (BulidBlocks());

	}


	IEnumerator BulidBlocks ()
		{
		for(int i = 0; i < 3; i++) // i<3 three rows of blocks to build
        {

			for(int j = 0; j < 14; j++)   // j< 14 a row contains 14 blocks
			{
				EventManager.NumberOfBlocks++;
				int x = Random.Range (0, 7); // Generate random blocks
				switch(x)
				{
				case 0: 
					restBlock = Instantiate (blockPrefab) as GameObject;
					break;
				case 1: 
					restBlock = Instantiate (bonusBlockPrefab) as GameObject;
					break;
				case 2: 
					restBlock = Instantiate (blockPrefab) as GameObject;
					break;
				case 3: 
					restBlock = Instantiate (freezeBlockPrefab) as GameObject;
					break;
				case 4: 
					restBlock = Instantiate (blockPrefab) as GameObject;
					break;
				case 5: 
					restBlock = Instantiate (speedBlockPrefab) as GameObject;
					break;
				case 6: 
					restBlock = Instantiate (blockPrefab) as GameObject;
					break;
				
				}
					
				restBlock.transform.position = blockPos;
				blockPos.x = blockPos.x + width;
				yield return new WaitForSeconds (0.03f);
			}

			blockPos.x = firstBlockPos.x;
			blockPos.y = blockPos.y - height;
		}

	}


	void GetWidthHeight ()
	{

		GameObject TempBlock = Instantiate (blockPrefab) as GameObject;
		BoxCollider2D b2D = TempBlock.GetComponent<BoxCollider2D> ();
		width = b2D.size.x;
		height = b2D.size.y;
		Destroy (TempBlock); 

	}
}
