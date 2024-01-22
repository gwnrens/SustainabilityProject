using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScriptMainMenu : MonoBehaviour
{
    public Death deathScript; 

    public void PlayGame()
    {
        SceneManager.LoadScene("Si_MainMenu"); 
    }

}
