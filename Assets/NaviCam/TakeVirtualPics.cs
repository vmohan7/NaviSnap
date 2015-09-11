using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TakeVirtualPics : MonoBehaviour {

	public AudioSource cameraClick; //sound for camera
	public Text picNum; //shows picture number
	public GameObject camera; //the 3d camera model
	public GameObject imageViewPlane; //the plane used to view the image

	public RenderTexture copyTexture; //the render texture we will use to see what the camera sees

	private List<Texture2D> textures; //all the pictures we have taken

	private bool isCameraMode; //whether we are using the camera or not
	private int currentImage = 0; //what image is currently being shown on the plane


	/// <summary>
	/// Initalizes all events that are needed to control the camera
	/// </summary>
	void Start () {
		textures = new List<Texture2D> ();
		TouchManager.OnDoubleTap += TakePicture;

		GestureManager.SwipeUp += SwipeUp;
		GestureManager.SwipeDown += SwipeDown;
		GestureManager.SwipeRight += NextImage;
		GestureManager.SwipeLeft += PrevImage;

		SwipeDown ();
	}

	/// <summary>
	/// On swipe up, we show the images to the user
	/// </summary>
	private void SwipeUp() {
		if (textures.Count > 0) {
			camera.SetActive (false);
			SetPicture();
			imageViewPlane.SetActive (true);

			isCameraMode = false;
		}

	}

	/// <summary>
	/// On swipe down, we let the user take pictures with the camera
	/// </summary>
	private void SwipeDown() {
		camera.SetActive (true);
		imageViewPlane.SetActive (false);

		isCameraMode = true;

	}

	/// <summary>
	/// Scroll to the previous image the user took
	/// </summary>
	private void PrevImage() {
		if (!isCameraMode) {
			currentImage--;
			if (currentImage < 0)
				currentImage = textures.Count - 1;
			SetPicture();
		}
	}

	/// <summary>
	/// Scroll to the next image the user took
	/// </summary>
	private void NextImage() {
		if (!isCameraMode) {
			currentImage = (currentImage + 1) % textures.Count;
			SetPicture();
		}
	}

	/// <summary>
	/// Set the picture for display on the plane
	/// </summary>
	private void SetPicture(){
		imageViewPlane.GetComponent<Renderer> ().material.mainTexture = textures [currentImage];
		picNum.text = "" + (currentImage + 1);
	}

	/// <summary>
	/// Start taking the picture
	/// </summary>
	private void TakePicture(int fingerID, Vector2 pos){
		if (isCameraMode)
			StartCoroutine (ActuallyTakePic ());
	}

	/// <summary>
	/// Coroutine for capturing a picture and storing it in memory. We break up the process into 2 steps to save the frame rate
	/// </summary>
	private IEnumerator ActuallyTakePic(){
		cameraClick.Play ();
		yield return new WaitForEndOfFrame ();
		 
		Texture2D screenShot = new Texture2D(copyTexture.width, copyTexture.height, TextureFormat.RGB24, false);

		RenderTexture.active = copyTexture;
		screenShot.ReadPixels(new Rect(0, 0, copyTexture.width, copyTexture.height), 0, 0);
		RenderTexture.active = null; // JC: added to avoid errors

		//Split the process up
		yield return 0;
		screenShot.Apply ();
		textures.Add (screenShot);
	}

}
