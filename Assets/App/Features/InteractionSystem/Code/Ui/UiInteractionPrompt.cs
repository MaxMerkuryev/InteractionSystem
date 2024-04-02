using UnityEngine;
using Zenject;

public class UiInteractionPrompt : MonoBehaviour {
	[SerializeField] private CanvasGroup _prompt;

	private InteractionHandler _interactionHandler;

	[Inject]
	public void Construct(InteractionHandler interactionHandler) {
		_interactionHandler = interactionHandler;
		_interactionHandler.Focused += Show;
		_interactionHandler.Unfocused += Hide;
		_prompt.alpha = 0;
	}	

	private void OnDestroy() {
		_interactionHandler.Focused -= Show;
		_interactionHandler.Unfocused -= Hide;			
	}

	private void Show() {
		_prompt.alpha = 1;
	}

	private void Hide() {
		_prompt.alpha = 0;
	}
}
