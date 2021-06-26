using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelControl : MonoBehaviour
{
    public GameObject startPanel;
    bool startPanelControl = true;
    public GameObject player;
    public GameObject gameOverPanel;
    bool gameOverPanelControl = false;

    // Start is called before the first frame update
    void Start()
    {
        //startPanel = GameObject.Find("startPanel");
        //gameOverPanel = GameObject.Find("gameOverPanel");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void panel()
    {

        if (startPanelControl)
        {
            startPanel.SetActive(false);
            player.GetComponent<Player>().enabled = true;


        }
        else
        {
            startPanel.SetActive(true);
        }

    }

    public void restart()
    {
        SceneManager.LoadScene(0);

        //if (!gameOverPanelControl)
        //{
        //    startPanel.SetActive(false);
        //    gameOverPanel.SetActive(false);
        //    player.GetComponent<Player>().enabled = true;


        //}
    }
}
