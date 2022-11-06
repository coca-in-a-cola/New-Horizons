using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;

	public bool isCustomOffset;
	public Vector3 offset;

	public float smoothSpeed = 0.1f;
	public float lookAtSpeed = 10f;

	// Use this for initialization
	void Start()
	{
		if (!isCustomOffset)
		{
			offset = transform.position - target.transform.position;
		}
	}


	// Update is called once per frame
	void Update()
	{
		if (target)
		{
			transform.LookAt(target.transform.position, Vector3.forward);
			Vector3 targetPos = target.transform.position + offset;
			Vector3 smoothFollow = Vector3.Lerp(transform.position, targetPos, smoothSpeed);

			transform.position = smoothFollow;

		}
	}
}
