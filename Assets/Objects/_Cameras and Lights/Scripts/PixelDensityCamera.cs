using UnityEngine;

[ExecuteInEditMode]
public class PixelDensityCamera : MonoBehaviour {

	public float pixelsToUnits = 1;

	void Update () {

		GetComponent<Camera>().orthographicSize = Screen.height / pixelsToUnits / 2;
	}
}
