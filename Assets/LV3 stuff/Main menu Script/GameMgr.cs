using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMgr : MonoBehaviour
{
    public int SceneIndex;
    public void SetSceneIndex(int index){


    }
    public Toggle[] sceneTogs;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sceneTogs.Length; i++)
        {
            int index=i;
            sceneTogs[i].onValueChanged.AddListener((v) =>
        {
    if(v){
        SceneIndex=index+1;
    }
        });
        }
        sceneTogs[0].isOn=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UI_Start(){
 SceneManager.LoadScene(SceneIndex);
    }
}
