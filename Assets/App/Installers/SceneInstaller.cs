using Zenject;
using UnityEngine;
using Interactions;

public class SceneInstaller : MonoInstaller {
	[SerializeField] private InteractionHandler _interactionHandler;	

	public override void InstallBindings() {
		Container.BindInstance(_interactionHandler).AsSingle();
	}
}
