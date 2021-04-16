using System;

namespace FakeArrows.Hooking {
	
	[AttributeUsage(AttributeTargets.Method)]
	public class Prefix : Attribute {
		
		
		
	}
	
	[AttributeUsage(AttributeTargets.Method)]
	public class Postfix : Attribute {
		
		
		
	}
	
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class Before : Attribute {
		
		public readonly string id;
		
		public Before(string id) {
			
			this.id = id;
			
		}
		
	}
	
}