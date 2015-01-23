﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	Vector3 _directon;

	bool			_flaggedForKill = false;
	float			_lifespan;
	ParticleSystem	_particleSystem;

	void Start()
	{
		_particleSystem = GetComponent<ParticleSystem>();
	}

	public void Fire(Vector3 direction)
	{
		rigidbody.AddForce(direction * 1000);
		//_directon = direction;
	}

	void Update()
	{
		//if (!_flaggedForKill)
		//{
		//	transform.Translate(_directon);
		//}

		_lifespan += Time.deltaTime;
		if (_lifespan > 10 || (_flaggedForKill && _particleSystem.particleCount == 0))
		{
			GameObject.Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		collider.enabled = false;
		_particleSystem.Emit(50);
		_flaggedForKill = true;
		renderer.enabled = false;
	}
}