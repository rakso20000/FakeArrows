using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MonoBehavior = UnityEngine.MonoBehaviour;

namespace FakeArrows.Hooking {
	
	public class HookManager {
		
		public static HookManager instance => hookManager ?? (hookManager = new HookManager());
		
		private static HookManager hookManager;
		
		private readonly Harmony harmony;
		
		private HookManager() {
			
			harmony = new Harmony("com.rakso20000.beatsaber.twitchfx");
			
		}
		
		public void HookAll(Assembly assembly) {
			
			foreach (Type type in assembly.GetTypes()) {
				
				if (!type.IsSubclassOf(typeof(HookBase)))
					continue;
				
				if (type.IsAbstract)
					continue;
				
				//type is Hook<Hooked>
				object hook = Activator.CreateInstance(type);
				
				Type hookedType = (Type) type.GetField("type").GetValue(hook);
				
				foreach (MethodInfo method in type.GetMethods()) {
					
					if (!method.IsStatic)
						continue;
					
					bool isPrefix = method.GetCustomAttribute<Prefix>() != null;
					bool isPostfix = method.GetCustomAttribute<Postfix>() != null;
					
					if (!isPrefix && !isPostfix)
						continue;
					
					MethodInfo hookedMethod;
					
					try {
						
						hookedMethod = hookedType.GetMethod(method.Name);
						
					} catch (AmbiguousMatchException) {
						
						Plugin.log.Error("Error in HookManager: " + hookedType.Name + "." + method.Name + " is ambiguous");
						
						continue;
						
					}
					
					if (hookedMethod == null) {
						
						Plugin.log.Error("Error in HookManager: " + hookedType.Name + "." + method.Name + " not found");
						
						continue;
						
					}
					
					HarmonyMethod harmonyMethod = new HarmonyMethod(method) {
						before = method.GetCustomAttributes<Before>().Select(before => before.id).ToArray()
					};
					
					if (isPrefix)
						harmony.Patch(hookedMethod, prefix: harmonyMethod);
					else
						harmony.Patch(hookedMethod, postfix: harmonyMethod);
					
				}
				
			}
			
		}
		
	}
	
}