using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu1Manager : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject SelectLevel;

    // Start is called before the first frame update
    void Start()
    {
        MenuCanvas.SetActive(true);
        SelectLevel.SetActive(false);
    }

    
}
