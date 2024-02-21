using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void QuitGame()
    {
        print("Quitting");
        Application.Quit();
    }
}
