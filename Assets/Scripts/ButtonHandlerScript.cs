using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonHandlerScript : MonoBehaviour {
    public Button myButton;

	// Use this for initialization
	void Start () {
		myButton.onClick.AddListener (OnButtonClick);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void OnButtonClick()
    {
		SceneManager.LoadScene("ScenePlay");
    }
}
