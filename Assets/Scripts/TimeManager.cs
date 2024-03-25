using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Slider slider;

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
			slider.value = currentTime / timeLimit;

            if (currentTime > timeLimit && !timeExpired)
            {
                timeExpired = true;
                Debug.Log("timer ended !");
            }
            yield return new WaitForSeconds(timeStep);
        } while (!timeExpired);
    }
}
