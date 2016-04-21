using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float aspectX;
	public float aspectY;

	private Rect rect;
	private float targetaspect;
	private float windowaspect;
	private float scaleheight;
	private float scalewidth;

	void Start () {
		Camera camera = GetComponent<Camera>();
		targetaspect = aspectX / aspectY;
		windowaspect = (float)Screen.width / (float)Screen.height;
		scaleheight = windowaspect / targetaspect;
		
		if (scaleheight < 1.0f)	{  
			rect = camera.rect;
			
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			
			camera.rect = rect;
		} else {
			scalewidth = 1.0f / scaleheight;
			
			rect = camera.rect;
			
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			
			camera.rect = rect;
		}
	}
}
