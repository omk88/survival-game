using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public int CurrentHealth;
    private PlayerManager playerManager;
    public int ReScene;

    //CurrentHealth=GameObject.FindGameObjectWithTag("playerManager").GetComponent<PlayerManager>().player.health;

    void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void Start()
    {
        Debug.Log(playerManager.player.health);
    }

    public void respawn()
    {
        if (CurrentHealth < 1)
        {
            //SceneManager.LoadScene(SceneManager.ActiveScene().buildIndex);//rebuilds current scene, both this and the below are differnt ways to restart the scene
            //SceneManager.LoadScene(ReScene);//rescene would be set to the scene index of the current scene(playtesting is currently 0 if you check build settings
        }

    }
}
