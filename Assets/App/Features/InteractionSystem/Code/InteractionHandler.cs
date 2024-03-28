using UnityEngine;

public class InteractionHandler : MonoBehaviour {
	[SerializeField] private Transform _source;
	[SerializeField] private float _reach;

	private ISelectable _focusedSelectable;

	private void Update() {
		if (!GetRaycast(out RaycastHit hit)) {
			ClearFocus();
			return;
		}

		if (GetHitComponent(hit, out ISelectable selectable)) {
			Focus(selectable);
		}

		if (GetHitComponent(hit, out IInteractable interactable)) {
			Handle(interactable);
		}
	}

	private void Handle(IInteractable interactable) {
		if (interactable == null) return;
		if (!Input.GetMouseButtonDown(0)) return;
		
		interactable.Interact();
	}

	private void Focus(ISelectable selectable) {
		if (selectable == null) return;
		if (selectable == _focusedSelectable) return;

		ClearFocus();

		_focusedSelectable = selectable;
		_focusedSelectable.Focus();
	}

	private void ClearFocus() {
		if (_focusedSelectable == null) return;

		_focusedSelectable.Unfocus();
		_focusedSelectable = null;
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
