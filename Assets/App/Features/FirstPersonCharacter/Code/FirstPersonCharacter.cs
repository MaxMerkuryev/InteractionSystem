using UnityEngine;

public class FirstPersonCharacter : MonoBehaviour, IMovable {
	[SerializeField] private Transform _head;
	[SerializeField] private CharacterController _characterController;
	[SerializeField] private MouseLook _mouseLook;
	[SerializeField] private CharacterMovement _movement;
	[SerializeField] private GroundCheck _groundCheck;

	private void Awake() {
		IMotionInput motionInput = new MotionInput(_head);

		_mouseLook.Initialize(_head);
		_movement.Initialize(this, motionInput);
	}

	private void Update() {
		_mouseLook.Update();
		_movement.Update();
	}

	private void FixedUpdate() {
		_groundCheck.Update();
	}

	public bool IsGrounded() {
		return _groundCheck.IsGrounded;
	}

	public void Move(Vector3 motion) {
		_characterController.Move(motion);
	}

	private void OnDrawGizmosSelected() {
		_groundCheck.DrawGizmos();
	}
}
