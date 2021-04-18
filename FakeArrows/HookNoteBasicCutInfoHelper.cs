using FakeArrows.Hooking;
using UnityEngine;

namespace FakeArrows {
	
	public class HookNoteBasicCutInfoHelper : Hook<NoteBasicCutInfoHelper> {
		
		[Prefix]
		public static void GetBasicCutInfo(ref NoteCutDirection cutDirection) {
			
			GameplayModifiers gameplayModifiers = ZenjectReceiver.instance?.gameplayCoreSceneSetupData?.gameplayModifiers;
			
			if (gameplayModifiers != null && gameplayModifiers.noArrows)
				cutDirection = NoteCutDirection.Any;
			
		}
		
	}
	
}