using TMPro;
using UnityEngine;
using Zenject;

namespace Interactions.Ui {
	public class UiInteractionPrompt : MonoBehaviour {
		[SerializeField] private CanvasGroup _canvasGroup;
		[SerializeField] private TextMeshProUGUI _prompt;

		private InteractionHandler _interactionHandler;

		[Inject]
		public void Construct(InteractionHandler interactionHandler) {
			_interactionHandler = interactionHandler;
			_interactionHandler.Focused += Show;
			_interactionHandler.Unfocused += Hide;
			_canvasGroup.alpha = 0;
		}

		private void OnDestroy() {
			_interactionHandler.Focused -= Show;
			_interactionHandler.Unfocused -= Hide;
		}

		private void Show(IInteractable interactable) {
			_canvasGroup.alpha = 1;
			_prompt.text = interactable.GetPrompt();
		}

		private void Hide() {
			_canvasGroup.alpha = 0;
			_prompt.text = string.Empty;
		}
	}
}
