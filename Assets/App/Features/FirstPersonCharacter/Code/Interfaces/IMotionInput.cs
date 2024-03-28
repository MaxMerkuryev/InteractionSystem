using UnityEngine;

public interface IMotionInput {
	Vector3 GetInput();
	bool IsRunning();
	bool IsJumpRequested();
}
