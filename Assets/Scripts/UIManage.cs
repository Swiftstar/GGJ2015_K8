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

	public UIManage()
	{
		LinkLiver();
		LinkStart();

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
	} // end -LinkStart()

	public void Update()
	{
		if ( Main.Instance.status == Main.EGameStatus.StartAni )
		{
			Sprite_LiverDark.fillAmount = Mathf.Clamp01( Sprite_LiverDark.fillAmount - Time.deltaTime );
			if ( Sprite_LiverDark.fillAmount == 0f )
				Main.Instance.FinishScreenAni();
		} // if

	} // Update()

	void OnClick_Start( GameObject go )
	{
		if (Main.Instance.status == Main.EGameStatus.Init )
			return;
		Btn_Start.gameObject.SetActive(false);
		Main.Instance.StartScreenAni( Sprite_LiverDark );
	} // end -OnClick_Start()

} // end +UIManage
