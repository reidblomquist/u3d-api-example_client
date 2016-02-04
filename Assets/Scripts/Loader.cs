using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject apiClient;

	void Awake () {
		if (apiClient && ApiClient.instance == null)
			Instantiate(apiClient);
	}
}
