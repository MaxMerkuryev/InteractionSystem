using System;
using UnityEngine;

[Serializable]
public class CharacterMovement {
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _gravity;

	[Header("DEBUG")]
	[SerializeField] private float _verticalSpeed;

	private IMovable _target;
	private IMotionInput _input;

	private float _jumpBuffer;

	public void Initialize(IMovable target, IMotionInput input) {
		_target = target;
		_input = input;
	}

	public void Update() {
		ApplyGravity();

		if(_input.IsJumpRequested() && _target.IsGrounded()) {
			ApplyJump();
		} 

		Move();
	}

	private void ApplyGravity() {
		if (_target.IsGrounded() && _jumpBuffer < Time.time) { 
			_verticalSpeed = -1f;
			return;
		}

		_verticalSpeed -= _gravity * Time.deltaTime;
	}

	private void ApplyJump() {
		_verticalSpeed = _jumpForce;
		_jumpBuffer = Time.time + 0.1f;
	}

	private void Move() {
		Vector3 input = _input.GetInput();
		float speed = _input.IsRunning() ? _runSpeed : _walkSpeed;
		Vector3 velocity = Vector3.up * _verticalSpeed + input * speed;

		_target.Move(velocity * Time.deltaTime);
	}
}
