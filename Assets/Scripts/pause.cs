using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {

	public static bool gameispaused = false;
	public GameObject pauseui;
	void Start()
	{
		gameispaused = false;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gameispaused) {
				Resume();
			} 
			else {
				Pause();
			}
		}
	}
		public void Resume()
		{
			pauseui.SetActive(false);
			Time.timeScale=1f;
			gameispaused=false;
		}

		void Pause()
		{
			pauseui.SetActive(true);
			Time.timeScale= 0f;
			gameispaused = true;
		}

	public void quitgame()
	{
	#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying=false;
	#else
		Application.Quit();
	#endif
	}

}
