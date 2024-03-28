using UnityEngine;

public class SelectionOutline : MonoBehaviour, ISelectable {
	[SerializeField] private MeshRenderer[] _meshes;

	private LayerMask _selectionLayer => LayerMask.NameToLayer("Selection");
	private SelectionData[] _selectionData;

	private void Awake() {
		Initialize();
	}

	public void Focus() {
		for (int i = 0; i < _selectionData.Length; i++) {
			_selectionData[i].SetLayer((int)_selectionLayer);
		}
	}

	public void Unfocus() {
		for (int i = 0; i < _selectionData.Length; i++) {
			_selectionData[i].ResetLayer();
		}
	}

	private void Initialize() {
		_selectionData = new SelectionData[_meshes.Length];

		for (int i = 0; i < _selectionData.Length; i++) {
			MeshRenderer mesh = _meshes[i];
			int initialLayer = mesh.gameObject.layer;

			_selectionData[i] = new SelectionData(mesh, initialLayer);
		}
	}

	private class SelectionData {
		private readonly MeshRenderer _mesh;
		private readonly LayerMask _initialLayer;

		public SelectionData(MeshRenderer mesh, LayerMask initialLayer) {
			_mesh = mesh;
			_initialLayer = initialLayer;
		}

		public void SetLayer(int layer) {
			//Debug.Log($"from: {LayerMask.LayerToName(_mesh.gameObject.layer)}\n"
			//		 + $"to: {LayerMask.LayerToName(layer)}");
			_mesh.gameObject.layer = layer;
		}

		public void ResetLayer() {
			//Debug.Log($"from: {LayerMask.LayerToName(_mesh.gameObject.layer)}\n"
			//		 + $"to: {LayerMask.LayerToName((int)_initialLayer)}");
			_mesh.gameObject.layer = _initialLayer;
		}
	}
}
