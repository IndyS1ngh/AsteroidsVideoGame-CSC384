using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaderHTP : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public Button htpButton;

    void Start()
    {
        htpButton.onClick.AddListener(LoadNextLevel);
    }

    public void LoadNextLevel() {
        Debug.Log("Back button clicked!");
        StartCoroutine(LoadLevel(4));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

}