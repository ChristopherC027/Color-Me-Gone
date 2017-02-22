using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class PlayerControllerTWO : MonoBehaviour {
	public float speed;

    public Text countText;
    public AudioClip pickSound;
	public GameObject pickUp;
	public GameObject enemy; 
	public AudioClip loseSound;
	public AudioClip winSound;
	public AudioClip enemySound; 
     
    public Text timerText;

    private Rigidbody rb;


  	public float spawnAreaCenterX;
 	public float spawnAreaCenterZ;
  	public float spawnRadius = 30;
  	public int score; 
	public float timeLeft;

	public bool spawnMonsterOne = false;
	public bool spawnMonsterTwo = false; 
	public bool spawnMonsterThree = false; 
	public bool spawnMonsterFour = false; 
	public bool spawnMonsterFive = false; 
	public bool spawnMonsterSix = false; 
	public bool spawnMonsterSeven = false; 
	public bool spawnMonsterEight = false; 
	private bool hasPlayed = false; 

    void Start ()
    {
		timeLeft = 60.0f;
    	score = 0; 
        rb = GetComponent<Rigidbody>();
		Time.timeScale = 1; 
		setCountText();
    }

	void Update()
     {
         timeLeft -= Time.deltaTime;
         timerText.text = "Time Left:" + Mathf.Round(timeLeft);
         print(timeLeft); 
         if (((timeLeft <= 52.5f) && (timeLeft >= 52.0f)) && spawnMonsterOne == false){
			Instantiate(enemy, new Vector3(10, 2, -12), Quaternion.Euler(0, 0, 0));
			AudioSource.PlayClipAtPoint(enemySound, transform.position);
			spawnMonsterOne = true; 
         }	
		if (((timeLeft <= 45.5f) && (timeLeft >= 45.0f)) && spawnMonsterTwo == false){
			Instantiate(enemy, new Vector3(-10, 2, -12), Quaternion.Euler(0, 0, 0));
			AudioSource.PlayClipAtPoint(enemySound, transform.position);
			spawnMonsterTwo = true; 
         }	
		if (((timeLeft <= 37.5f) && (timeLeft >= 37.0f)) && spawnMonsterThree == false){
			Instantiate(enemy, new Vector3(-22, 2, 5), Quaternion.Euler(0, 90, 0));
			AudioSource.PlayClipAtPoint(enemySound, transform.position);
			spawnMonsterThree = true; 
         }	
		if (((timeLeft <= 30.5f) && (timeLeft >= 30.0f)) && spawnMonsterFour == false){
			Instantiate(enemy, new Vector3(-22, 2, -5), Quaternion.Euler(0, 90, 0));
			AudioSource.PlayClipAtPoint(enemySound, transform.position);
			spawnMonsterFour = true; 
         }	
		if (((timeLeft <= 22.5f) && (timeLeft >= 22.0f)) && spawnMonsterFive == false){
			Instantiate(enemy, new Vector3(22, 2, -5), Quaternion.Euler(0, 270, 0));
			AudioSource.PlayClipAtPoint(enemySound, transform.position);
			spawnMonsterFive = true; 
         }	
		if (((timeLeft <= 15.5f) && (timeLeft >= 15.0f)) && spawnMonsterSix == false){
			Instantiate(enemy, new Vector3(22, 2, 5), Quaternion.Euler(0, 270, 0));
			AudioSource.PlayClipAtPoint(enemySound, transform.position);
			spawnMonsterSix = true; 
         }	
		if (((timeLeft <= 7.5f) && (timeLeft >= 7.0f)) && spawnMonsterSeven == false){
			Instantiate(enemy, new Vector3(10, 2, 12), Quaternion.Euler(0, 180, 0));
			AudioSource.PlayClipAtPoint(enemySound, transform.position);
			spawnMonsterSix = true; 
         }	
		if (((timeLeft <= 1.5f) && (timeLeft >= 0.0f)) && spawnMonsterEight == false){
			Instantiate(enemy, new Vector3(-10, 2, 12), Quaternion.Euler(0, 180, 0));
			AudioSource.PlayClipAtPoint(enemySound, transform.position);
			spawnMonsterSix = true; 
         }	
     }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void setCountText ()
    {
		countText.text = "Count: " + score.ToString();
    }	

    void OnTriggerEnter(Collider other) 
    {
		
        if (other.gameObject.CompareTag ("Pick Up"))
        {
			AudioSource.PlayClipAtPoint(pickSound, transform.position);
			float xRandomOffset = Random.Range(-spawnRadius, spawnRadius);
 			float zRandomOffset = Random.Range(-spawnRadius, spawnRadius);
  			float xSpawnPosition = spawnAreaCenterX + xRandomOffset;
  			float zSpawnPosition = spawnAreaCenterZ + zRandomOffset;
  			other.transform.position = new Vector3(xSpawnPosition, other.transform.position.y, zSpawnPosition);
  			score += 1; 
			setCountText();
        }

    }

	private void OnGUI() 
	{
		GUILayout.BeginArea(new Rect(0,0, Screen.width, Screen.height)); 
		if (score == 15)
		{
			Time.timeScale = 0;
			buildWinPrompt();
		}
		if(timeLeft < 0)
         {

			Time.timeScale = 0; 
			buildLosePrompt();
         }
         if (transform.position.y < -10)
         {
			Time.timeScale = 0; 
			buildLosePrompt();
         }
		GUILayout.EndArea(); 
	}

	private void buildWinPrompt()
	{
		if (!hasPlayed){
			AudioSource.PlayClipAtPoint(winSound, transform.position);
			hasPlayed = true; 
		}
		int winPromptW = 120; 
		int winPromptH = 90; 

		float halfScreenW = Screen.width/2; 
		float halfScreenH = Screen.height/2; 

		int halfPromptW = winPromptW/2; 
		int halfPromptH = winPromptH/2;

		GUI.BeginGroup(new Rect(halfScreenW-halfPromptW, halfScreenH-halfPromptH, winPromptW, winPromptH)); 
		GUI.Box(new Rect(0,0,winPromptW,winPromptH), "Green Restored!"); 

		int buttonW = 80; 
		int buttonH = 20; 

		if (GUI.Button(new Rect(halfPromptW-(buttonW/2), halfPromptH-(buttonH/2), buttonW, buttonH), "Proceed")); 
		{
			if (Input.GetMouseButtonUp(0)){
				Application.LoadLevel("PreLevel3");
			}
		}
		GUI.EndGroup();


	}

	private void buildLosePrompt()
	{
		if (!hasPlayed){
			AudioSource.PlayClipAtPoint(loseSound, transform.position);
			hasPlayed = true; 
		}
		int LosePromptW = 200; 
		int LosePromptH = 90; 

		float halfScreenW = Screen.width/2; 
		float halfScreenH = Screen.height/2; 

		int halfPromptW = LosePromptW/2; 
		int halfPromptH = LosePromptH/2;

		GUI.BeginGroup(new Rect(halfScreenW-halfPromptW, halfScreenH-halfPromptH, LosePromptW, LosePromptH)); 
		GUI.Box(new Rect(0,0,LosePromptW,LosePromptH), "The Darkness consumed you"); 

		int buttonW = 80; 
		int buttonH = 20; 

		if (GUI.Button(new Rect(halfPromptW-(buttonW/2), halfPromptH-(buttonH/2), buttonW, buttonH), "Try again")); 
		{
			if (Input.GetMouseButtonUp(0)){
				Application.LoadLevel("Level2");
			}
		}
		GUI.EndGroup(); 
	}

  
}