using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {
	public GameObject menuPanel;

	public void LoadScene(int sceneId) {
		SceneManager.LoadScene(sceneId);
	}

	public void ExitGame() {

#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}

	// ya boi anthony the artist coded this

	public void MenuPanelToggle (GameObject panel) {
		menuPanel.SetActive(false);
		panel.SetActive(true);
	}

	public void BackButton () {

		EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
		menuPanel.SetActive(true);
	}
}
