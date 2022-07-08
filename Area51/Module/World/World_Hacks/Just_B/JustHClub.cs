using UnityEngine;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class JustHClub
	{
		public static void EnableVROnlyBtn(bool state)
		{
			GameObject.Find("기믹/ele/ele trick").gameObject.active = state;
		}
	}
}
