using Tridify;
using UnityEngine;
using UnityEngine.UI;

public class HVACSceneObject : MonoBehaviour {

	public Shader outlineShader;
	public Shader standardShader;
	public Color okColor;
	public Color wrongColor;
	public string id;
	public string modelId;
	public HVACPosition position;
	public HVACRotation rotation;
	public bool isOk;
	public GameObject dataCanvas;
	public Material mainMaterial;
	public IfcPropertySet BimPropertySet;
	public Text text;
	public MeshRenderer meshRender;
	private bool playerLookingAtObject;
	
	private void Start() {
		int index = 0;
		foreach (Material mat in meshRender.materials) {
			if (mat.name.Contains(mainMaterial.name)) {
				break;
			}
			index++;
		}
		text.text += "System: " + (isOk ? "Ok" : "Failure") +"\n";
		text.text += "Id: " + id + "\n";
		text.text += "Model: " + modelId + "\n";

		meshRender.materials[index] = Instantiate<Material>(mainMaterial);
		mainMaterial = meshRender.materials[index];
		foreach (IfcAttribute attribute in BimPropertySet.Attributes) {
			text.text += attribute.Name + ": " + attribute.Value + "\n";
		}
	}

	public void ShowDataCanvas() {
		dataCanvas.SetActive(true);
	}

	public void HideDataCanvas() {
		dataCanvas.SetActive(false);
	}

	public void PlayerLooking() {
		CancelInvoke();
		Invoke(nameof(PlayerNotLooking), 3);
		playerLookingAtObject = true;
	}

	public void PlayerNotLooking() {
		CancelInvoke();
		playerLookingAtObject = false;
		SetStandardMaterial();
	}

	private void Update() {
		if (!playerLookingAtObject) {
			return;
		}
		if (Input.GetMouseButtonDown(0)) {
			if (dataCanvas.activeInHierarchy) {
				HideDataCanvas();
			}
			else {
				ShowDataCanvas();
			}
		}
		SetLookingMaterial();
	}

	public void SetLookingMaterial() {
		mainMaterial.shader = outlineShader;
		mainMaterial.SetColor("_OutlineColor", isOk ? okColor : wrongColor);
	}

	public void SetStandardMaterial() {
		mainMaterial.shader = standardShader;
	}

	public void SetStandardMaterialAfterTime() {
		Invoke(nameof(SetStandardMaterial),3);
	}
}