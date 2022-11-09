using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public int CurrentHealth;
    public int ReScene;

    private void Update()
    {
        CurrentHealth = Player.instance.health;
    }

    public void respawn()
    {
        if (CurrentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//rebuilds current scene, both this and the below are differnt ways to restart the scene
            SceneManager.LoadScene(ReScene);//rescene would be set to the scene index of the current scene(playtesting is currently 0 if you check build settings
        }
    }
}
