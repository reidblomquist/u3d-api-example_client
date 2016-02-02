using UnityEngine;
using System.Net;
using System.Collections;



public class ApiClient : MonoBehaviour
{
	[System.Serializable]
	public struct Rgba
	{
		public float R;
		public float G;
		public float B;
		public float A;
	}

	public class RgbaApi
	{
		public static Rgba GetRgba()
		{
			var url = "http://reidblomquist.com:6969/rgba";

			var syncClient = new WebClient();
			string jsonResponse = syncClient.DownloadString(url);
			return JsonUtility.FromJson<Rgba>(jsonResponse);
		}
	}
}
