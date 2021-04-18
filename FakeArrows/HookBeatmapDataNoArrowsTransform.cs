using FakeArrows.Hooking;

namespace FakeArrows {
	
	public class HookBeatmapDataNoArrowsTransform : Hook<BeatmapDataNoArrowsTransform> {
		
		[Prefix]
		public static bool CreateTransformedData(IReadonlyBeatmapData beatmapData, ref IReadonlyBeatmapData __result) {;
			
			__result = beatmapData;
			
			return false;
			
		}
		
	}
	
}