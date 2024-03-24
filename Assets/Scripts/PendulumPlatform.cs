using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumPlatform : MonoBehaviour
{
	[SerializeField]
	private float initialForce;

	void Start(){
		var rb = GetComponent<Rigidbody>();

		rb.AddForce(Vector3.right * initialForce, ForceMode.Impulse);
	}
}
