using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Soccer : MonoBehaviour {
	
	//gameobject visible in the inspector
	public GameObject soccerBall;
	
	//variables not visible in the inspector
	public static bool gameOver;
	public static bool startMenu;
	
	GameObject GameOverMenu;
	GameObject StartMenu;
	
	GameObject Score;
	GameObject BestScore;
	GameObject timeObject;
	
	public static int score;
	float time;
	
	Transform spawnpoint;
	
	void Start(){
	//normal timescale
	Time.timeScale = 1f;
	
	//set score 0 and time 60
	score = 0;
	time = 60f;
		
	//search for the menu objects
	StartMenu = GameObject.Find("Start menu");
	GameOverMenu = GameObject.Find("Game over menu");
	Score = GameObject.Find("Score");
	timeObject = GameObject.Find("time left");
	BestScore = GameObject.Find("Best");
	
	//find ball spawner
	spawnpoint = GameObject.Find("spawnpoint").transform;
		
	//show best score on best score object using UI text
	BestScore.GetComponent<UnityEngine.UI.Text>().text = "Best: " + PlayerPrefs.GetInt("Best(soccer)");
		
	//set objects true/false
	Score.SetActive(false);
	startMenu = true;
	gameOver = false;
	StartMenu.SetActive(true);
	GameOverMenu.SetActive(false);
	}
	
	void Update(){
	//if the game is playing, show score and time
	if(!gameOver && !startMenu){
	Score.GetComponent<UnityEngine.UI.Text>().text = "" + (int)score;
	timeObject.GetComponent<UnityEngine.UI.Text>().text = "" + time.ToString("f1");
	time -= Time.deltaTime;
	}
	
	//game is over after 60 seconds
	if(time <= 0){
	gameOver = true;
	GameOverMenu.SetActive(true);
	
	//save highscore
	if(score > PlayerPrefs.GetInt("Best(soccer)")){
	PlayerPrefs.SetInt("Best(soccer)", score);	
	}
	}
	//if we are game over, display score and don't display time
	if(gameOver){
	Score.GetComponent<UnityEngine.UI.Text>().text = "Score: " + (int)score;
	timeObject.GetComponent<UnityEngine.UI.Text>().text = "";
	}
	}
	
	//add soccerball at spawner position
	public void spawnBall(){
	if(!gameOver){
	Instantiate(soccerBall, spawnpoint.position, spawnpoint.rotation);	
	}
	}
	
	public void startGame(){
	//start game and spawn the first ball
	StartMenu.SetActive(false);
	BestScore.SetActive(false);
	startMenu = false;
	Score.SetActive(true);
	spawnBall();
	}
	
	public void quitGame(){
	//quit app
	Application.Quit();
	}
	
	public void restartGame(){
		//restart this scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
