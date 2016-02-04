using UnityEngine;
using System.Collections;

public class ApiBackgroundColor : ApiClient {

	private Color backgroundColor;
	private Rgba rgba;

	private Camera camera;

	void Awake()
	{
		camera = GetComponent<Camera>();
	}

	void LateUpdate () {
		//		Rgba rgba = GetRgba();
		Rgba rgba = ApiClient.instance.currentRgba;
		backgroundColor = new Color(rgba.R/255, rgba.G/255, rgba.B/255, rgba.A);
		camera.backgroundColor = backgroundColor;
	}
}
