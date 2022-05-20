using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableSaveOptions : MonoBehaviour
{
    public Button saveButton;
    public Button saveToProf1;
    public Button saveToProf2;
    public Button saveToProf3;
    
    void Start () {
		Button btn = saveButton.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}
    
    public void OnClick() {
        saveButton.gameObject.SetActive(false);
        saveToProf1.gameObject.SetActive(true);
        saveToProf2.gameObject.SetActive(true);
        saveToProf3.gameObject.SetActive(true);
    }
}
