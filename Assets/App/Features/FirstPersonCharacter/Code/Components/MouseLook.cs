using System;
using UnityEngine;

[Serializable]
public class MouseLook {
	[SerializeField] private float _sensitivity;

	private Vector2 _lookInput;
	private Transform _head;

	public void Initialize(Transform head) {
		Cursor.lockState = CursorLockMode.Locked;
		_lookInput = new Vector2();
		_head = head;
	}

	public void Update() {
		HandleInput();
		ApplyRotation(); 
	}

	private void HandleInput() {
		_lookInput.x -= GetAxis("Mouse Y");
		_lookInput.y += GetAxis("Mouse X");

		_lookInput.x = Mathf.Clamp(_lookInput.x, -90, 90);
	}

	private float GetAxis(string axisName) {
		return Input.GetAxis(axisName) * _sensitivity * Time.deltaTime;
	}

	private void ApplyRotation() {
		_head.localRotation = Quaternion.Euler(_lookInput.x, _lookInput.y, 0f);	
	}
}
