using System;

[Serializable]
public class HVACPosition {

	public float x;
	public float y;
	public float z;

}

[Serializable]
public class HVACRotation {

	public float x;
	public float y;
	public float z;

}

[Serializable]
public class HVACData {

	public string id;
	public string modelId;
	public HVACPosition position;
	public HVACRotation rotation;
	public bool isOk;

}
