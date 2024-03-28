using UnityEngine;

public class MotionInput : IMotionInput {
	private readonly Transform _head;

	public MotionInput(Transform head) {
		_head = head;
	}

	public Vector3 GetInput() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector3 forward = Vector3.ProjectOnPlane(_head.forward, Vector3.up) * y;
		Vector3 right = _head.right * x;

		return (forward + right).normalized;
	}

	public bool IsRunning() {
		return Input.GetKey(KeyCode.LeftShift);
	}

	public bool IsJumpRequested() {
		return Input.GetKeyDown(KeyCode.Space);
	}
}
