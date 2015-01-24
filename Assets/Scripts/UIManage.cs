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

	public UIManage()
	{
		LinkLiver();
	} // end +UIManage


	private void LinkLiver()
	{
	    GameObject go = GameObject.Find( CONST.NAME_SPRITE_LIVER_BG );
		Sprite_LiverBG = go.GetComponent<UISprite>();
		go = GameObject.Find( CONST.NAME_SPRITE_LIVER_DARK );
		Sprite_LiverDark = go.GetComponent<UISprite>();
		Liver_Empty = Sprite_LiverDark.cachedTransform.parent.gameObject;

	} // end -LinkLiver()

	public void Update()
	{
	} // Update()

} // end +UIManage
