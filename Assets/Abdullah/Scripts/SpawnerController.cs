using TMPro;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public EnemySpawner[] spawners; // Array to hold references to the spawner scripts
    public TextMeshProUGUI enemiesKilledText;
    public MouseLook mouseLook;
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
            foreach (EnemySpawner spawner in spawners)
            {
                spawner.StartSpawning();
            }
            enemiesKilledText.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseLook.mouseLookEnabled = true;
            panel.SetActive(false);
        }
    }
}
