using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	public enum EGameStatus
	{
		StartScreen,
		Play,
		Init
	}

	public EGameStatus status { get; private set; }


	public static UIManage UIManager;
	
	void Awake()
	{
		status = EGameStatus.Init;
		UIManager = UIManage.Instance;
	} // Awake()


	// Use this for initialization
	void Start () {


	} // Start()
	
	// Update is called once per frame
	void Update () {
		UIManager.Update();
	} // Update()
}
