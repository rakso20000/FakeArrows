using Zenject;
using MonoBehavior = UnityEngine.MonoBehaviour;

namespace FakeArrows {
	
	public class ZenjectReceiver : MonoBehavior {
		
		public static ZenjectReceiver instance { get; private set; }
		
		public GameplayCoreSceneSetupData gameplayCoreSceneSetupData { get; private set; }
		
		[Inject]
		public void Receive(GameplayCoreSceneSetupData gameplayCoreSceneSetupData) {
			
			this.gameplayCoreSceneSetupData = gameplayCoreSceneSetupData;
			
			instance = this;
			enabled = false;
			
		}
		
		public void OnDestroy() {
			
			if (instance == this)
				instance = null;
			
		}
		
	}
	
}