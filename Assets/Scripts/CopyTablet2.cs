using UnityEngine;
using System.Collections;

public class CopyTablet2 : MonoBehaviour {

	void Start(){
		if (AndroidHelper.IsTangoCorePresent ()) {
			transform.parent = TangoDeltaPoseController.Player.gameObject.transform;
		} else {
			transform.parent = Cardboard.SDK.transform;
		}

	}

	// Update is called once per frame
	void Update () {
		transform.rotation = NaviDeviceLocation.DeviceLocation.rotation;
	}
}
