using UnityEngine;
using System;
using System.Collections;
using System.Net;

public class ApiClient : MonoBehaviour
{
	#region Persistance

	public static ApiClient instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	#endregion

	// Create Rgba struct to serialize api request into
	// Run route requests via coroutine to ensure we don't block
	// the application's main thread.
	#region Rgba

	[System.Serializable]
	public class Rgba
	{
		public float R;
		public float G;
		public float B;
		public float A;
	}

	public Rgba currentRgba;

	private string rgbaUrl = "http://reidblomquist.com:6969/rgba";
	private bool freshRgba = false;
	private WebClient syncClient = new WebClient();

	IEnumerator KeepRgbaFresh()
	{
		while (freshRgba)
		{
			try
			{
				string jsonResponse = syncClient.DownloadString(rgbaUrl);
				currentRgba = JsonUtility.FromJson<Rgba>(jsonResponse);
			}
			catch (Exception e)
			{
				print(e);
			}
			yield return null;
		}
	}

	#endregion

	public void Start()
	{
		if (freshRgba == false)
		{
			try
			{
				freshRgba = true;
				StartCoroutine(KeepRgbaFresh());
			}
			catch (Exception e)
			{
				print("what the fuck");
			}
		}
	}
}
