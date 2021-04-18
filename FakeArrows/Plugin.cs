using System.Reflection;
using FakeArrows.Hooking;
using IPA;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace FakeArrows {
	
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin {
		
		internal static IPALogger log { get; private set; }
		
		[Init]
		public Plugin(IPALogger logger) {
			
			log = logger;
			
		}
		
		[OnStart]
		public void OnStart() {
			
			HookManager.instance.HookAll(Assembly.GetExecutingAssembly());
			
		}
		
		[OnEnable]
		public void OnEnable() {
			
			SceneManager.activeSceneChanged += OnSceneChanged;
			
		}
		
		[OnDisable]
		public void OnDisable() {
			
			SceneManager.activeSceneChanged -= OnSceneChanged;
			
		}
		
		private void OnSceneChanged(Scene prevScene, Scene nextScene) {
			
			if (nextScene.name == "GameCore")
				new GameObject("FakeArrowsZenjectReceiver").AddComponent<ZenjectReceiver>();
			
		}
		
	}
	
}