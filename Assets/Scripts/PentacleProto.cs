using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentacleProto : MonoBehaviour
{
	public List<SlotObject> candlesSlot;
	public bool puzzleComplete;

	// Start is called before the first frame update
	void Start()
	{
		puzzleComplete = false;
	}

	// Update is called once per frame
	void Update()
	{
		bool ok = true;
		foreach (SlotObject slot in candlesSlot)
		{
			if (!slot.GoodObject)
			{
				ok = false;
			}
		}

		if (ok) {

			puzzleComplete = true;
		}
	}
}
