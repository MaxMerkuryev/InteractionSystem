using System;
using UnityEngine;

public class InteractionHandler : MonoBehaviour {
	[SerializeField] private Transform _source;
	[SerializeField] private float _reach;

	public event Action Focused;
	public event Action Unfocused;

	private IInteractable _focusedInteractable;

	private void Update() {
		if (!GetRaycast(out RaycastHit hit)) {
			Unfocus();
			return;
		}

		if (GetHitComponent(hit, out IInteractable interactable)) {
			Focus(interactable);
		}

		Interact();
	}

	private void Focus(IInteractable interactable) {
		if (interactable == _focusedInteractable) return;
		
		_focusedInteractable = interactable;
		Focused?.Invoke();
	}

	private void Unfocus() {
		if (_focusedInteractable == null) return;

		_focusedInteractable = null;		
		Unfocused?.Invoke();
	}

	private void Interact() {
		if (_focusedInteractable == null) return;		
		if (!Input.GetMouseButtonDown(0)) return;

		_focusedInteractable.Interact();
	}	

	private bool GetRaycast(out RaycastHit hit) {
		Ray ray = new Ray(_source.position, _source.forward);
		return Physics.Raycast(ray, out hit, _reach);
	}

	private bool GetHitComponent<T>(RaycastHit hit, out T component) {
		hit.collider.TryGetComponent<T>(out component);
		return component != null;
	}

	private void OnDrawGizmosSelected() {
		if (_source == null) return;
		Gizmos.color = Color.red;
		Gizmos.DrawRay(_source.position, _source.forward * _reach);
	}
}
