using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Basketball : MonoBehaviour {
	
	//variable visible in the inspector
	public GameObject ball;
	
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
	//normal time scale
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
	
	spawnpoint = GameObject.Find("spawnpoint").transform;
		
	//show best score on best score object using UI text
	BestScore.GetComponent<UnityEngine.UI.Text>().text = "Best: " + PlayerPrefs.GetInt("Best(basketball)");
		
	//set objects true/false
	Score.SetActive(false);
	startMenu = true;
	gameOver = false;
	StartMenu.SetActive(true);
	GameOverMenu.SetActive(false);
	}
	
	void Update(){
	//if the game is playing, show time left and score
	if(!gameOver && !startMenu){
	Score.GetComponent<UnityEngine.UI.Text>().text = "" + (int)score;
	timeObject.GetComponent<UnityEngine.UI.Text>().text = "" + time.ToString("f1");
	time -= Time.deltaTime;
	}
	
	//if time is over, game is over
	if(time <= 0){
	gameOver = true;
	GameOverMenu.SetActive(true);
	//adjust playerprefs to save best score
	if(score > PlayerPrefs.GetInt("Best(basketball)")){
	PlayerPrefs.SetInt("Best(basketball)", score);	
	}
	}
	//if we are game over, display score and time
	if(gameOver){
	Score.GetComponent<UnityEngine.UI.Text>().text = "Score: " + (int)score;
	timeObject.GetComponent<UnityEngine.UI.Text>().text = "";
	}
	}
	
	//instantiate new basketball at the spawnposition
	
	
	public void startGame(){
	//start game and spawn first ball
	StartMenu.SetActive(false);
	BestScore.SetActive(false);
	startMenu = false;
	Score.SetActive(true);
	Debug.Log("Start calisti");
	}
	
	//quit app
	public void quitGame(){
		Application.Quit();
	}
	
	//restart current scene
	public void restartGame(){
	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
