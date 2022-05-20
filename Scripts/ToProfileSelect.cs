using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToProfileSelect : MonoBehaviour
{   

    public Button profButton;
    
    void Start () {
		Button btn = profButton.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}
    
    public void OnClick() {
        SceneManager.LoadScene(5);
    }
}
