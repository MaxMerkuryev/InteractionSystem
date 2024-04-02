using Zenject;
using UnityEngine;

public class SceneInstaller : MonoInstaller {
	[SerializeField] private InteractionHandler _interactionHandler;	

	public override void InstallBindings() {
		Container.BindInstance(_interactionHandler).AsSingle();
	}
}
