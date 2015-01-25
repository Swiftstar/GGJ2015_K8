using UnityEngine;
using System.Collections;

public class UIManage {


	private static UIManage instance;
	public static UIManage Instance
	{
		get {
			if ( instance == null )
				instance = new UIManage();
			return instance;
		} // get
	} // end +Instance


	GameObject Liver_Empty;
	UISprite Sprite_LiverBG;
	UISprite Sprite_LiverDark;

	UIButton Btn_Start;
	UILabel Lbl_Start;

	UISprite[] Sprite_LiverAry;

	GameObject winOrLose;

	public UIManage()
	{
		LinkLiver();
		LinkStart();
		LinkLiverAry();
	} // end +UIManage


	private void LinkLiver()
	{
	    GameObject go = GameObject.Find( CONST.NAME_SPRITE_LIVER_BG );
		Sprite_LiverBG = go.GetComponent<UISprite>();
		go = GameObject.Find( CONST.NAME_SPRITE_LIVER_DARK );
		Sprite_LiverDark = go.GetComponent<UISprite>();
		Liver_Empty = Sprite_LiverDark.cachedTransform.parent.gameObject;

	} // end -LinkLiver()

	private void LinkStart()
	{
		GameObject go = GameObject.Find( CONST.NAME_BTN_START );
		Btn_Start = go.GetComponent<UIButton>();
		UIEventListener.Get(go).onClick = OnClick_Start;

		go = GameObject.Find( CONST.NAME_LBL_START );
		Lbl_Start = go.GetComponent<UILabel>();
	} // end -LinkStart()

	private void LinkLiverAry()
	{
		GameObject go;
		Sprite_LiverAry = new UISprite[CONST.NAME_LIVER_BLOCK.Length];

		for (int i = 0 ; i < CONST.NAME_LIVER_BLOCK.Length ; i++ )
		{
			go = GameObject.Find( CONST.NAME_LIVER_BLOCK[i] );
			Sprite_LiverAry[i] = go.GetComponent<UISprite>();
		} // for

		for (int i = 0 ; i < Sprite_LiverAry.Length ; i++ )
		{
			Sprite_LiverAry[i].fillAmount = 0f;
		} // for

	} // end -LinkLiverAry

	float tempTime;
	public int tempI= 0;

    public void StartGame()
    {
        tempI = 1;
        Sprite_LiverAry[0].fillAmount = 1f;
    }

    public float SpreadTime = 8f;

	public void Update()
	{
		if ( Main.Instance.status == Main.EGameStatus.StartAni )
		{
			Sprite_LiverDark.fillAmount = Mathf.Clamp01( Sprite_LiverDark.fillAmount - Time.deltaTime );
			if ( Sprite_LiverDark.fillAmount == 0f )
				Main.Instance.FinishScreenAni();
		} // if

		if ( Main.Instance.status == Main.EGameStatus.Play )
		{
            Sprite_LiverAry[tempI].fillAmount = Mathf.Clamp01(Sprite_LiverAry[tempI].fillAmount + Time.deltaTime / SpreadTime);
			if ( Sprite_LiverAry[tempI].fillAmount >= 1f )
			{
				tempI++;
				tempI = Mathf.Clamp( tempI, 0, Sprite_LiverAry.Length-1);
			} // if
		} // if 

	} // Update()

	void OnClick_Start( GameObject go )
	{
		if (Main.Instance.status == Main.EGameStatus.Init )
			return;

		Btn_Start.gameObject.SetActive(false);
		Main.Instance.StartScreenAni( Sprite_LiverDark );

		if ( winOrLose != null )
			GameObject.Destroy(winOrLose);
	} // end -OnClick_Start()

	public void WinAndReturn()
	{
		winOrLose = GameObject.Instantiate( Resources.Load("Prefabs/Win") ) as GameObject ;

        AudioSource _AudioSource = GameObject.Find("BackGroundMusic").GetComponent<AudioSource>();
        _AudioSource.clip = Resources.Load("Sound/Win") as AudioClip;
        _AudioSource.loop = false;
        _AudioSource.volume = 1;
        _AudioSource.Play();

		Btn_Start.gameObject.SetActive(true);
		Lbl_Start.text = CONST.RETRY;
		Sprite_LiverDark.fillAmount = 1f;

		for ( int i = 0 ; i < Sprite_LiverAry.Length ; i++ )
		{
			Sprite_LiverAry[i].fillAmount = 0f;
		} // for
		tempI = 0;



	} // WinAndReturn()

    public void GameOver()
	{
		winOrLose = GameObject.Instantiate( Resources.Load("Prefabs/Lose") ) as GameObject ;

        AudioSource _AudioSource = GameObject.Find("BackGroundMusic").GetComponent<AudioSource>();
        _AudioSource.clip = Resources.Load("Sound/Lose") as AudioClip;
        _AudioSource.volume = 1;
        _AudioSource.loop = false;
        _AudioSource.Play();

		Btn_Start.gameObject.SetActive(true);
		Lbl_Start.text = CONST.RETRY;
		Sprite_LiverDark.fillAmount = 1f;
		
		for ( int i = 0 ; i < Sprite_LiverAry.Length ; i++ )
		{
			Sprite_LiverAry[i].fillAmount = 0f;
		} // for
		tempI = 0;


	} // GameOver()

	public bool IsWin()
	{
		for ( int i = 0 ; i < Sprite_LiverAry.Length ; i++ )
		{
			if ( Sprite_LiverAry[i].fillAmount < 1f )
				return false;
		} // for
		return true;
	} // IsWin()

	public bool IsLose()
	{
		if (tempI == 0 && Sprite_LiverAry[tempI].fillAmount == 0f  )
			return true;
		else
			return false;
	} // IsLose()

    public void Heal()
    {

        float nowAmount = Sprite_LiverAry[tempI].fillAmount;

        if (nowAmount >= 0.5f)
            Sprite_LiverAry[tempI].fillAmount = Mathf.Clamp01(Sprite_LiverAry[tempI].fillAmount - 0.25f);
        else
        {
            Sprite_LiverAry[tempI].fillAmount = 0f;

            tempI--;
            tempI = Mathf.Clamp(tempI, 0, Sprite_LiverAry.Length - 1); ;
            Sprite_LiverAry[tempI].fillAmount = Mathf.Clamp01(Sprite_LiverAry[tempI].fillAmount - 0.25f);
        }
    }

	public void HealBig()
	{
		tempI = Mathf.Clamp(tempI, 0, Sprite_LiverAry.Length - 1);
		Sprite_LiverAry[tempI].fillAmount = 0f;
		tempI--;
		tempI = Mathf.Clamp(tempI, 0, Sprite_LiverAry.Length - 1);
		Sprite_LiverAry[tempI].fillAmount = 0f;
	}

} // end +UIManage
