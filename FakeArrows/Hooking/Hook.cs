using System;

namespace FakeArrows.Hooking {
	
	public abstract class Hook<Hooked> : HookBase {
		
		public Type type;
		
		public Hook() {
			
			type = typeof(Hooked);
			
		}
		
	}
	
}