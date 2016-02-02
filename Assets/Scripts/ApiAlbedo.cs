using UnityEngine;
using System.Collections;

public class ApiAlbedo : ApiClient {

	private Color albedo;
	private Rgba rgba;

	void Awake () {
		Rgba rgba = RgbaApi.GetRgba();
		albedo = new Color(rgba.R, rgba.G, rgba.B, rgba.A);
		Renderer rend = GetComponent<Renderer>();
		rend.material.SetColor("Albedo", albedo);
	}

	void Update () {
		Debug.Log(albedo);
	}
}
