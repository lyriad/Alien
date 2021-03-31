using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    private Boolean pause = false;
    private Boolean dead = false;
    private int points = 0;
    private List<GameObject> blons;
    
    public Button button;
    private Coroutine _coroutine;

    public GameObject balloon;
    private GameObject[] balloons;
    public GameObject ship;

    public Sprite pauseBtn;
    public Sprite playBtn;

    public Text timer;
    public Text score;

    public Canvas HUD;
    public Canvas gameOver;
    

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

        Random.InitState((int)DateTime.Now.Ticks);
        _coroutine = StartCoroutine(coroutine());
        score.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       balloons = GameObject.FindGameObjectsWithTag("Balloon");
        //Debug.Log(points);

    }

    private IEnumerator coroutine()
    {
   
        while (true && !dead)
        {
            try
            {
                //Debug.Log(balloons.Length);
                if (balloons.Length > 6) continue;
            }
            catch { }
            yield return new WaitForSecondsRealtime(Random.Range(0.5f, 1f));
            if (true)
            {
                Instantiate(balloon, new Vector3(Random.Range(-6.5f, 7.5f), -7, 0), Quaternion.identity);

            }

        }
    }


    public void applyPoints(int points)
    {
        this.points += points;
        updateScore(this.points.ToString());
    }

    public void Pause()
    {
        button.GetComponent<Image>().sprite = pause ? pauseBtn: playBtn;
        Debug.Log("PAUSE CALLED");
        this.pause = !pause;
        Time.timeScale = pause ? 0 : 1;
        ship.GetComponent<Ship>().Pause(this.pause);
    }

    public void updateTimer(String time) {

        timer.text = time;
    }

    public void updateScore(String score)
    {
        this.score.text = score;
    }

    public void restartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void finishGame() {

        HUD.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        dead = true;
    }    
}
