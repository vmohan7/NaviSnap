using UnityEngine;
using System.Collections;

public class DeviceChooser : MonoBehaviour {

	//set in the inspector
	public GameObject TangoPrefab;
	public GameObject CardboardPrefab;

	// Use this for initialization
	void Start () {
		GameObject temp;
		if (AndroidHelper.IsTangoCorePresent ()) {
			temp = Instantiate(TangoPrefab) as GameObject;
			NaviConnectionSDK.OnResetHMD += ResetTangoHMD;
		} else {
			temp = Instantiate(CardboardPrefab) as GameObject;
			NaviConnectionSDK.OnResetHMD += ResetCardboardHMD;
		}

		temp.transform.parent = this.transform.parent;
	}
	
	public void ResetTangoHMD(){
		TangoDeltaPoseController.Player.ResetPose (); 
	}

	public void ResetCardboardHMD(){
		Cardboard.SDK.Recenter ();
	}
}
