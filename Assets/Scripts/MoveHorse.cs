using UnityEngine;
using System.Collections;

public class MoveHorse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (TranslateHorse ());
	}

	IEnumerator TranslateHorse(){
		while (true) {
			iTween.MoveTo(this.gameObject, iTween.Hash("x", 0f, "y", -2f, "z", 6f , "easeType", "linear", "time", 3f));
			yield return new WaitForSeconds(3f);
			iTween.MoveTo(this.gameObject, iTween.Hash("x", -1f, "y", -2f, "z", 4.2f , "easeType", "linear", "time", 1f));
			iTween.RotateTo(this.gameObject, iTween.Hash("y", -50f, "easeType", "linear", "time", 1f));
			yield return new WaitForSeconds(1f);

			iTween.MoveTo(this.gameObject, iTween.Hash("x", -10.5f, "y", -2f, "z", 14.3f , "easeType", "linear", "time", 3f));

			yield return new WaitForSeconds(3f);
			//start point
			iTween.MoveTo(this.gameObject, iTween.Hash("x", -10f, "y", -2f, "z", 15f , "easeType", "linear", "time", 1f));
			iTween.RotateTo(this.gameObject, iTween.Hash("y", 41f, "easeType", "linear", "time", 1f));
			yield return new WaitForSeconds(0.5f);

			iTween.RotateTo(this.gameObject, iTween.Hash("y", 132f, "easeType", "linear", "time", 1f));
			yield return new WaitForSeconds(0.5f);
		}
	}
}
