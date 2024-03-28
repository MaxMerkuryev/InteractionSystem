using System;
using UnityEngine;

[Serializable]
public class GroundCheck {
	[SerializeField] private Transform _body;
	[SerializeField] private LayerMask _mask;
	[SerializeField] private float _radius;
	[SerializeField] private float _offset;

	public bool IsGrounded { get; private set; }

	public void Update() {
		Vector3 checkSpherePosition = GetGroundCheckSperePosition();
		IsGrounded = Physics.CheckSphere(checkSpherePosition, _radius, _mask);
	}

	public void DrawGizmos() {
		if (_body == null) return;
		Vector3 groundCheckSpherePosition = GetGroundCheckSperePosition();
		Gizmos.DrawWireSphere(groundCheckSpherePosition, _radius);
	}

	private Vector3 GetGroundCheckSperePosition() {
		Vector3 characterPosition = _body.position;
		Vector3 offset = Vector3.down * _offset;

		return characterPosition + offset;
	}
}
