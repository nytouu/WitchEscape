using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Manager
{
	private float currentTime;
	public float CurrentTime { get; }

	private bool timeExpired;
	public bool TimeExpired { get; }

	[SerializeField]
	private float timeLimit;

	[SerializeField]
	private float timeStep;

	// Start is called before the first frame update
	void Start()
	{
		currentTime = 0;

		StartCoroutine(TimeRoutine());
		Debug.Log("timer starts !");
	}

	// Update is called once per frame
	void Update() { }

	private IEnumerator TimeRoutine()
	{
		do
		{
			currentTime += timeStep;

			if (currentTime > timeLimit && !timeExpired)
			{
				timeExpired = true;
				Debug.Log("too late !");
			}
			yield return new WaitForSeconds(timeStep);
		} while (true);
	}
}
