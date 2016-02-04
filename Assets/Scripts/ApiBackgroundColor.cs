using UnityEngine;
using System;

public class ApiBackgroundColor : MonoBehaviour {

	private Color backgroundColor;
	private ApiClient.Rgba rgba;

	private Camera camera;

	void Awake()
	{
		camera = GetComponent<Camera>();
	}

	void LateUpdate () {
		ApiClient.Rgba rgba = ApiClient.instance.currentRgba;
		backgroundColor = new Color(rgba.R/255, rgba.G/255, rgba.B/255, rgba.A);
		try
		{
			camera.backgroundColor = backgroundColor;
		}
		catch (Exception e)
		{
			print(e);
		}
	}
}
