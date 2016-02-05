using UnityEngine;
using System;
using System.Collections;

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

	IEnumerator RgbaCoroutine()
	{
		while (freshRgba)
		{
			WWW www = new WWW(rgbaUrl);
			yield return www;
			if (www.error == null)
			{
				currentRgba = JsonUtility.FromJson<Rgba>(www.text);
			}
			else
			{
				print("failed json request moar info: " + www.text);
			}
		}
	}

	public void StopRgbaCoroutine()
	{
		freshRgba = false;
		try
		{
			StopCoroutine(RgbaCoroutine());
		}
		catch (Exception e)
		{
			print(e);
		}
	}

	#endregion

	void Start()
	{
		if (freshRgba == false)
		{
			try
			{
				freshRgba = true;
				StartCoroutine(RgbaCoroutine());
			}
			catch (Exception e)
			{
				print(e);
			}
		}
	}

	void OnApplicationQuit()
	{
		StopRgbaCoroutine();
	}
}
