using System.Collections.Generic;
using System.Linq;

public static class PlayerControl {

	public static List<HVACSceneObject> hvacs = new List<HVACSceneObject>();

	public static void LookingAtHvac(HVACSceneObject lookingHvac) {
		lookingHvac.PlayerLooking();
		List<HVACSceneObject> notLookingHvacs = hvacs.Where(hv => hv.id != lookingHvac.id).ToList();
		foreach (HVACSceneObject hvac in notLookingHvacs) {
			StopLookingAtHvac(hvac);
		}
	}

	public static void StopLookingAtHvac(HVACSceneObject hvac) {
		hvac.PlayerNotLooking();
		hvac.HideDataCanvas();
	}

	public static void ShowAllHvacs() {
		foreach (HVACSceneObject hvac in hvacs) {
			hvac.SetLookingMaterial();
			hvac.SetStandardMaterialAfterTime();
		}
	}
}
