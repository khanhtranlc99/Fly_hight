using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class gameManager : EditorWindow {
	// Editor
	Texture2D book;
	Texture2D GMbanner;
	bool toggle1 = false;
	bool toggle2 = false;
	bool toggle3 = false;
	string button1 = "Open";
	string button2 = "Open";
	string button3 = "Open";
	Vector2 scrollPosition = new Vector2(0,0);

	// Game
	public managerVars vars;

	[MenuItem("Editor/Game Manager")]
	static void Initialize(){
		gameManager window = (gameManager)EditorWindow.GetWindow (typeof(gameManager), true, "Game Manager v1.0");
		window.maxSize = new Vector2 (500f, 500f);
		window.minSize = window.maxSize;
	}

	void OnEnable(){
		vars = (managerVars) AssetDatabase.LoadAssetAtPath("Assets/Resources/manager.asset", typeof(managerVars));
		book = Resources.Load("book", typeof(Texture2D)) as Texture2D;
		GMbanner = Resources.Load("GMbanner", typeof(Texture2D)) as Texture2D;
	}

	void OnGUI(){
		GUILayout.Label (GMbanner);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition);

		//Game Options
		GUILayout.BeginVertical("HelpBox");
		GUILayout.Label ("Game Options", "TL Selection H2");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button (button1, "LargeButton")) toggle1 = !toggle1;
		GUILayout.BeginHorizontal("HelpBox");
		GUILayout.Label ("Title, Sounds etc..");
		GUILayout.Label (book ,"SelectionRect");
		GUILayout.EndHorizontal();
		GUILayout.EndHorizontal();

		if(toggle1){
			button1 = "Close";
			GUILayout.BeginVertical("GroupBox");

			GUILayout.Label ("Game Title");
			vars.gameTitle = EditorGUILayout.TextArea (vars.gameTitle, GUILayout.Height (30));
			vars.tapStart = EditorGUILayout.TextField ("Tap To Start", vars.tapStart);
			vars.rateUrl = EditorGUILayout.TextField ("Rate Url", vars.rateUrl);
			GUILayout.Label ("Jump Sound");
			vars.jumpSound = EditorGUILayout.ObjectField (vars.jumpSound, typeof(AudioClip), false) as AudioClip;
			GUILayout.Label ("Coin Sound");
			vars.coinSound = EditorGUILayout.ObjectField (vars.coinSound, typeof(AudioClip), false) as AudioClip;
			GUILayout.Label ("Background Music");
			vars.bgSound = EditorGUILayout.ObjectField (vars.bgSound, typeof(AudioClip), false) as AudioClip;
			EditorUtility.SetDirty (vars);
			GUILayout.EndVertical();
		}else{
			button1 = "Open";
		}
		GUILayout.EndVertical();

		//Bird Price
		GUILayout.BeginVertical("HelpBox");
		GUILayout.Label ("Character Options", "TL Selection H2");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button (button2, "LargeButton")) toggle2 = !toggle2;
		GUILayout.BeginHorizontal("HelpBox");
		GUILayout.Label ("Characters Price");
		GUILayout.Label (book ,"SelectionRect");
		GUILayout.EndHorizontal();
		GUILayout.EndHorizontal();

		if(toggle2){
			button2 = "Close";
			GUILayout.BeginVertical("GroupBox");
			vars.bird2Price = EditorGUILayout.IntField ("Bird 2 Price", vars.bird2Price);
			vars.bird3Price = EditorGUILayout.IntField ("Bird 3 Price", vars.bird3Price);
			vars.bird4Price = EditorGUILayout.IntField ("Bird 4 Price", vars.bird4Price);
			vars.bird5Price = EditorGUILayout.IntField ("Bird 5 Price", vars.bird5Price);
			vars.bird6Price = EditorGUILayout.IntField ("Bird 6 Price", vars.bird6Price);
			vars.unlockAt1 = EditorGUILayout.IntField ("Unlock Extra Bird 1 Floor", vars.unlockAt1);
			vars.unlockAt2 = EditorGUILayout.IntField ("Unlock Extra Bird 2 Floor", vars.unlockAt2);
			EditorUtility.SetDirty (vars);
			GUILayout.EndVertical();
		}else{
			button2 = "Open";
		}
		GUILayout.EndVertical();

		//Ad and Leader ID's
		GUILayout.BeginVertical("HelpBox");
		GUILayout.Label ("Admob and Leaderboard Options", "TL Selection H2");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button (button3, "LargeButton")) toggle3 = !toggle3;
		GUILayout.BeginHorizontal("HelpBox");
		GUILayout.Label ("Ad and Leaderboard Settings");
		GUILayout.Label (book ,"SelectionRect");
		GUILayout.EndHorizontal();
		GUILayout.EndHorizontal();

		if(toggle3){
			button3 = "Close";
			GUILayout.BeginVertical("GroupBox");
			vars.admobBanner = EditorGUILayout.TextField ("Banner ID", vars.admobBanner);
			vars.admobInterstitial = EditorGUILayout.TextField ("Interstitial ID", vars.admobInterstitial);
			vars.leaderboard = EditorGUILayout.TextField ("Leaderboard ID", vars.leaderboard);
			vars.showAdAfterDead = EditorGUILayout.IntField ("Show Ad After Dead", vars.showAdAfterDead);
			EditorUtility.SetDirty (vars);
			GUILayout.EndVertical();
		}else{
			button3 = "Open";
		}
		GUILayout.EndVertical();

		GUILayout.EndScrollView();
	}

	void OnDestroy(){
		EditorUtility.SetDirty (vars);
	}

	void drawArray(string arrayName){
		SerializedObject so = new SerializedObject(this);
		SerializedProperty stringsProperty = so.FindProperty (arrayName);
		EditorGUILayout.PropertyField(stringsProperty, true);
		so.ApplyModifiedProperties();
	}

}
