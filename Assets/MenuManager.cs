using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public void StartGame() {

        SceneManager.LoadScene(1);
    }
}
