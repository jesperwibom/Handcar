using UnityEngine;
using System.Collections;
using Uniduino;

public class ControlManager : MonoBehaviour {


	public Arduino arduino1;
	//public Arduino arduino2;

	public GameObject player1;
	//public GameObject player2;

	Controller controller1;
	//Controller controller2;

	PlayerMovement player1Movement;
	//PlayerMovement player2Movement;

	public GameManager gm;

	int[] player1Values = {512,0,0,0,0};
	//int[] player2Values = {512,0,0,0,0};
	int[] player1PreviousValues = {512,0,0,0,0};
	//int[] player2PreviousValues = {512,0,0,0,0};

	//will not be public in final game
	public bool gameRunning = true;
	public bool keyboardControl = false;
	public bool player1active;
	//public bool player2active;

	int controller1Player = 0; //-1 left player, +1 right player, 0 any player
	//int controller2Player = 0; //-1 left player, +1 right player, 0 any player

	/* DEFAULT
	int controllerDeadzone = 20;
	int playerSwitchThreshold = 127;
	int playerBoostThreshold = 20;
	int playerMaxTravel = 6;
	*/

	int controllerDeadzone = 20;
	int playerSwitchThreshold = 300;
	int playerBoostThreshold = 200;
	int playerMaxTravel = 150;

	float controller1Force = 0;
	float controller2Force = 0;

	float forceModifier = 0.0035f;
	float powerModifier = 0.001f;
	int boostBonusForce = 15;

	bool[] controller1Btn = { false, false };
	//bool[] controller2Btn = { false, false };
	bool controller1BtnRun = false;
	//bool controller2BtnRun = false;


	bool jumpRelease = true;
	bool trackSwitchLeft = false;
	bool trackSwitchRight = false;

	//===================================================//

	void Awake(){
		//DontDestroyOnLoad ();
	}

	void Start(){



		if (player1active) {
			player1Movement = player1.GetComponent<PlayerMovement> ();
		}


		if (arduino1) {
			controller1 = new Controller (arduino1);
		}


	}

	void Update(){

		if (Input.GetKeyDown ("i")) {
			ResetControllerStates ();
		}
		if (Input.GetKeyDown ("b")) {
			gameRunning = !gameRunning;
		}
		if(keyboardControl && Input.GetKeyDown("r")){
			gm.Respawn();
		}


		CheckControllers ();
		UpdateControllers ();


		if(gameRunning){
			
			if (keyboardControl) {
				KeyboardControl ();
			}

			CalculatePlayerForce (); //calc speed and power

		}

	}

	void FixedUpdate(){
		SetControllers ();

		if (gameRunning) {
			UpdatePlayerMovements ();
		}

	}


	//===================================================//

	void CheckControllers(){
		if (controller1 != null) {
			player1Values = controller1.GetInput ();
		}

	}

	void UpdateControllers(){
		if (controller1 != null) {
			controller1.UpdateLeds ();
		}

	}

	void SetControllers(){
		if (controller1 != null) {
			if (controller1Player == 0) {
				controller1.SetLedFade ("both", 300f, true);
			}
			if (controller1Player == -1) {
				controller1.SetLed ("left", 255);
				controller1.SetLed ("right", 0);
			}
			if (controller1Player == 1) {
				controller1.SetLed ("right", 255);
				controller1.SetLed ("left", 0);
			}
		}




	}


	void CalculatePlayerForce(){
		if (controller1 != null) {
			//Debug.Log (player1Values [0]);
			switch (controller1Player) {
			case 0:
				if (player1Values [0] < (player1PreviousValues [0] - controllerDeadzone)) {
					controller1Player = -1;
				} else if (player1Values [0] > (player1PreviousValues [0] + controllerDeadzone)) {
					controller1Player = 1;
				}
				break;
			case -1:
				controller1Force += player1PreviousValues [0] - player1Values [0];

				if (player1Values [0] <= playerBoostThreshold) {
					controller1Force += boostBonusForce;
				}

				if (player1Values [0] < playerSwitchThreshold && player1Values [0] > player1PreviousValues [0]) {
					controller1Player = 1;
				} else if (player1Values [0] < playerMaxTravel){
					controller1Player = 1;
				}
				player1PreviousValues [0] = player1Values [0];
				break;
			case 1:
				controller1Force += player1Values [0] - player1PreviousValues [0];

				if (player1Values [0] >= 1023 - playerBoostThreshold) {
					controller1Force += boostBonusForce;
				}

				if (player1Values [0] > (1023 - playerSwitchThreshold) && player1Values [0] < player1PreviousValues [0]) {
					controller1Player = -1;
				}  else if (player1Values [0] > 1023 - playerMaxTravel){
					controller1Player = -1;
				}
				player1PreviousValues [0] = player1Values [0];
				break;
			default:
				break;
			}

		}




	}


	void UpdatePlayerMovements(){

		if (controller1 != null) {

			//SPEED
			if(controller1Force > 0){
				player1Movement.ChangeSpeed((float)controller1Force * forceModifier);
				controller1Force = 0;
			}

			//SWITCH AND JUMP
			//if both player pull the switch, then JUMP

			if (jumpRelease) {
				if (player1Values [3] > 0 && player1Values [4] > 0) {
					player1Movement.Jump ();
					jumpRelease = false;
					trackSwitchLeft = false;
					trackSwitchRight = false;
				} else if (player1Values [3] > 0) {
					trackSwitchLeft = true;
				} else if (player1Values [4] > 0) {
					trackSwitchRight = true;
				}
			}

			if (player1Values [3] == 0 && player1Values [4] == 0) {
				jumpRelease = true;
				if (trackSwitchLeft) {
					player1Movement.SwitchLeft ();
					trackSwitchLeft = false;
				} else if (trackSwitchRight) {
					player1Movement.SwitchRight ();
					trackSwitchRight = false;
				}
			}
					/*
			if (!player1Movement.isGrounded() && jumpRelease) {
				if (player1Values [3] > 0 && player1Values [4] > 0) {
					player1Movement.Jump ();
					jumpRelease = false;
				}
			}
			*/

			/*
			if ((player1Values [3] > 0 && player1Values [3] != player1PreviousValues [3]) && (player1Values [4] > 0 && player1Values [4] != player1PreviousValues [4])) {
				player1Movement.Jump ();
			}

			if (player1Values [3] != player1PreviousValues [3]) {
				player1PreviousValues [3] = player1Values [3];
			}

			if (player1Values [4] != player1PreviousValues [4]) {
				player1PreviousValues [4] = player1Values [4];
			}
			*/
			


			/* OLD JUMP AND SWITCH
			//TRACK SWITCH
			if (player1Values [3] > 0 && player1Values[3] != player1PreviousValues[3]) {
				player1Movement.SwitchLeft ();
				Debug.Log ("TRACK SWITCH LEFT");

			}
			player1PreviousValues [3] = player1Values [3];

			if (player1Values [4] > 0 && player1Values[4] != player1PreviousValues[4]) {
				player1Movement.SwitchRight ();
				Debug.Log ("TRACK SWITCH RIGHT");
			}
			player1PreviousValues [4] = player1Values [4];


			//JUMP
			if (player1Values [1] > 0 && player1Values [1] != player1PreviousValues [1]) {
				controller1Btn [0] = true;
				if (!controller1BtnRun) {
					controller1BtnRun = true;
					StartCoroutine (WaitForController1Jump (0));
				} else if (controller1BtnRun && controller1Btn[1]){
					player1Movement.Jump();
					Debug.Log("JUMPING!!!");
				}
			}

			if (player1Values [2] > 0 && player1Values [2] != player1PreviousValues [2]) {
				controller1Btn [1] = true;
				if (!controller1BtnRun) {
					controller1BtnRun = true;
					StartCoroutine (WaitForController1Jump (1));
				} else if (controller1BtnRun && controller1Btn[0]){
					player1Movement.Jump();
					Debug.Log("JUMPING!!!");
				}
			}
			*/

			player1PreviousValues [1] = player1Values [1];
			player1PreviousValues [2] = player1Values [2];


		}



	}

	IEnumerator WaitForController1Jump(int i){
		yield return new WaitForSeconds(0.7f);

		controller1BtnRun = false;
		controller1Btn [i] = false;

		if (!controller1Btn [0] && !controller1Btn [1]) {
			//Shoot ();
			player1.GetComponent<PlayerSound>().Honk();
			Debug.Log("SHOOTING!!!");
		}

		controller1Btn [0] = false;
		controller1Btn [1] = false;

	}


	IEnumerator WaitForController2Jump(){
		yield return null;
	}

	public void ResetControllerStates(){
		controller1Player = 0;

	}


	void KeyboardControl(){
		//PLAYER 1
		if (player1active) {
			if(keyboardControl && Input.GetKeyDown("right")){
				player1Movement.ChangeSpeed (2f);


			}
			if(keyboardControl && Input.GetKeyDown("up")){
				player1Movement.SwitchLeft();
			}
			if(keyboardControl && Input.GetKeyDown("down")){
				player1Movement.SwitchRight();
			}
			if(keyboardControl && Input.GetKeyDown("space")){
				player1Movement.Jump();
			}



		}


	}

}
