using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{

	private static Main instance;
	public static Main Instance
	{
		get
		{
			if ( instance == null )
				instance = Object.FindObjectOfType<Main>();
			return instance;
		} // get
	} // +Instance

	public enum EGameStatus : int
	{
		Init = 0,
		StartScreen,
		StartAni,
		Play
	}

	public EGameStatus status { get; private set; }


	public static UIManage UIManager;
    public static CreateMedicine createMedicine;
	
	void Awake()
	{
		status = EGameStatus.Init;
		UIManager = UIManage.Instance;
        createMedicine = CreateMedicine.Instance;
	} // Awake()


	// Use this for initialization
	void Start () {
		status = EGameStatus.StartScreen;

	} // Start()
	
	// Update is called once per frame
	void Update () {
        UIManager.Update();
	} // Update()

	void FixedUpdate()
	{
		if ( status == EGameStatus.Play )
		{
			if ( UIManager.IsWin() )
			{
				Win();
			} // if
		} // if
	}

	void Win()
	{
		UIManager.WinAndReturn();
		status = EGameStatus.StartScreen;
	}

	public void StartScreenAni( UISprite sprite )
	{
		status = EGameStatus.StartAni;
		sprite.fillAmount = 1f;
	} // StartScreenAni()

	public void FinishScreenAni()
	{
		status = EGameStatus.Play;

		Debug.Log( "GameStart!!" );
        createMedicine.PlayGame();
        UIManager.StartGame();
	} // FinishScreenAni()
}
