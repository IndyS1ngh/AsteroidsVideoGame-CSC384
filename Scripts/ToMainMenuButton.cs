using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToMainMenuButton : MonoBehaviour
{   

    public Button backButton;
    
    void Start () {
		Button btn = backButton.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}
    
    public void OnClick() {
        SceneManager.LoadScene(0);
    }
}
