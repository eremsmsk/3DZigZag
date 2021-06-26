using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Singleton<panelControl>
{

    public panelControl gameOver;

    public GameObject startPanel;
    bool startPanelControl;
    public GameObject player;
    public GameObject gameOverPanel;
    bool gameOverPanelControl = false;
    public InterstitialAd _fullscreenAd;

    private string _fullScreenAdId = "ca-app-pub-9062608619931623/4837859131";

    bool lookingRigth = true;
    public CreateFloor createFloor;
    Vector3 direction;
    public float startSpeed;
    public float speed;
    public static bool die;
    public Text txtScore;
    public GameObject game;
    delegate void TurnDelegate();
    TurnDelegate turnDelegate;

    public int counter;
    int score = 0;
    int result = 0;
    void Start()
    {
        #region PLATFORM FOR TURNING

#if UNITY_EDITOR
        turnDelegate = TurnPlayerUsingKeybord;
#endif

#if !UNITY_EDITOR
            turnDelegate = TurnPlayerUsingTouch;
#endif

        #endregion

        die = false;
        direction = Vector3.left;
        requestFullScreenAd();
        Kill();

    }

    // Update is called once per frame
    void Update()
    {
        if (die == true)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (direction.x != 0)
            {
                direction = Vector3.back;
            }
            else
            {
                direction = Vector3.left;
            }
        }

        if (transform.position.y <0.1f)
        {
            die = true;
            KillCounter();
            Debug.Log("counter : " + counter );
            if (!startPanelControl)
            {
                //startPanelControl = true;
                //gameOverPanel.SetActive(true);
                
                if (counter % 3 == 0)
                {
                    _fullscreenAd.Show();
                    SceneManager.LoadScene(1);
                }
                SceneManager.LoadScene(1);
            }

        }
    }

    private void TurnPlayerUsingKeybord()
    {
        GameObject eventSystem = EventSystem.current.currentSelectedGameObject;
        if (eventSystem != null)
        {
            if (eventSystem.name != "BtnOn" || eventSystem.name != "BtnOff")
            {
                if (Input.GetMouseButtonDown(0)) Turn();
            }
        }

        if (Input.GetMouseButtonDown(0)) Turn();
    }
    private void TurnPlayerUsingTouch()
    {
        GameObject eventSystem = EventSystem.current.currentSelectedGameObject;

        if (eventSystem != null)
        {
            if (eventSystem.name != "BtnOn" || eventSystem.name != "BtnOff")
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) Turn();
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) Turn();

    }

    private void Turn()
    {
        if (lookingRigth)
        {
            transform.Rotate(new Vector3(0, 1, 0), -90);
        }
        else
        {
            transform.Rotate(new Vector3(0, 1, 0), 90);
        }
        lookingRigth = !lookingRigth;

    }

    private void Kill()
    {
        counter = PlayerPrefs.GetInt("kill");
    }
    private void KillCounter()
    {
        counter++;
        PlayerPrefs.SetInt("kill", counter);

    }

    private void FixedUpdate()
    {
        Vector3 move = direction * Time.deltaTime * startSpeed;
        transform.position += move;

        startSpeed += speed * Time.deltaTime;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            
            StartCoroutine(removeFloor(collision.gameObject));
            createFloor.createFloor();
        }
    }

    IEnumerator removeFloor(GameObject obje)
    {
        yield return new WaitForSeconds(0.15f);
        obje.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1.4f);
        Destroy(obje);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("crystal"))
        {
            score += 1;
            //Debug.Log(score);
            txtScore.text = score.ToString();
            //result += score;
            PlayerPrefs.SetInt("cry", score);
            Destroy(other.gameObject);

            
        }
    }

    public void panel()
    {
        startPanelControl = true;
        if (startPanelControl)
        {
            startPanelControl = false;
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
    }

    public void requestFullScreenAd()
    {
        _fullscreenAd = new InterstitialAd(_fullScreenAdId);

        AdRequest adRequest = new AdRequest.Builder().Build();

        _fullscreenAd.LoadAd(adRequest);

        // Reklam yüklenmesini bekler ondan sonra reklamı gösterir.
    }

}


