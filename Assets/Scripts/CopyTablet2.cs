using UnityEngine;
using System.Collections;

public class CopyTablet2 : MonoBehaviour {

	void Start(){
		transform.parent = TangoDeltaPoseController.Player.gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
		transform.rotation = NaviDeviceLocation.DeviceLocation.rotation;
	}
}
