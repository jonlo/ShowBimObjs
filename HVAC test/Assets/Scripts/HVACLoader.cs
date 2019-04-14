using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class HVACLoader : MonoBehaviour {

	private const string Path = "/GameData/Buildings.json";
	private List<Building> buildings;
	// Use this for initialization
	void Start () {
		string filePath = Application.dataPath + Path;
		string json = File.ReadAllText(filePath);
		buildings = JsonConvert.DeserializeObject<List<Building>>(json);
		LoadHVACS();
	}

	void LoadHVACS() {
		foreach (Building building in buildings) {
			foreach (HVACData hvac in building.HVACs) {
				GameObject hvacObj = GameObject.Instantiate(Resources.Load(hvac.modelId)) as GameObject;
				HVACSceneObject hvacSceneObject = hvacObj.GetComponent<HVACSceneObject>();
				PlayerControl.hvacs.Add(hvacSceneObject);
				hvacSceneObject.transform.position = new Vector3(hvac.position.x, hvac.position.y, hvac.position.z);
				hvacSceneObject.transform.rotation =  Quaternion.Euler(new Vector3(hvac.rotation.x, hvac.rotation.y, hvac.rotation.z));
				hvacSceneObject.isOk = hvac.isOk;
				hvacSceneObject.id = hvac.id;
			}
		}
	}


}
