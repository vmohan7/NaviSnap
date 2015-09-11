using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour {

	public static Persistent Instance;

	// Use this for initialization
	void Start () {
		if (Instance == null)
			Instance = this;
		else {
			Destroy(Instance.gameObject);
			Instance = this;
		}

		DontDestroyOnLoad (this.gameObject);
	}

}
