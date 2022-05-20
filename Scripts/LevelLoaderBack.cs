using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaderBack : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public Button optionButton;

    void Start()
    {
        optionButton.onClick.AddListener(LoadNextLevel);
    }

    public void LoadNextLevel() {
        Debug.Log("Back button clicked!");
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

}
