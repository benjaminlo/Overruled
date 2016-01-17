#pragma strict

//Reference the camera
var mainCam : Camera;

//Reference the colliders we are going to adjust
var topWall : BoxCollider2D;
var bottomWall : BoxCollider2D;
var leftWall : BoxCollider2D;
var rightWall : BoxCollider2D;

function Start () { //Only set this to Update if you know the screen size can change during a playsession.
	Screen.SetResolution (1280, 768, true);
	//Move each wall to its edge location:
	topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
	topWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y + 0.5f);
	
	bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2, 0f, 0f)).x, 1f);
	bottomWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y - 0.5f);
	
	leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0.5f, Screen.height*2f, 0f)).y);;
	leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.1f, 0f);
	
	rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0.5f, Screen.height*2f, 0f)).y);
	rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
}