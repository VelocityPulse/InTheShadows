using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public enum LevelStatus {
		AVAILABLE,
		UNAVAILABLE,
		SUCCESSED
	}

	private const string LEVEL_STATUS_1_KEY = "LEVEL_STATUS_1_KEY";
	private const string LEVEL_STATUS_2_KEY = "LEVEL_STATUS_2_KEY";
	private const string LEVEL_STATUS_3_KEY = "LEVEL_STATUS_3_KEY";
	private const string LEVEL_STATUS_4_KEY = "LEVEL_STATUS_4_KEY";

	private const string FIRST_LAUNCH_KEY = "FIRST_LAUNCH_KEY";

	[HideInInspector] public int levelStatus1;
	[HideInInspector] public int levelStatus2;
	[HideInInspector] public int levelStatus3;
	[HideInInspector] public int levelStatus4;
	[HideInInspector] public int firstLaunch;

	private static Player p = null;

	public static Player getInstance () {
		return (p);
	}

	private void Awake () {
		if (p == null) {
			p = this;
		}
	}

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt (FIRST_LAUNCH_KEY) == 0) {
			initDataToDefault ();
		}
		reloadDatas ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void initDataToDefault () {
		PlayerPrefs.SetInt (LEVEL_STATUS_1_KEY, (int)LevelStatus.AVAILABLE);
		PlayerPrefs.SetInt (LEVEL_STATUS_2_KEY, (int)LevelStatus.UNAVAILABLE);
		PlayerPrefs.SetInt (LEVEL_STATUS_3_KEY, (int)LevelStatus.UNAVAILABLE);
		PlayerPrefs.SetInt (LEVEL_STATUS_4_KEY, (int)LevelStatus.UNAVAILABLE);
		PlayerPrefs.SetInt (FIRST_LAUNCH_KEY, 1);
	}

	public void reloadDatas () {
		levelStatus1 = PlayerPrefs.GetInt (LEVEL_STATUS_1_KEY);
		levelStatus2 = PlayerPrefs.GetInt (LEVEL_STATUS_2_KEY);
		levelStatus3 = PlayerPrefs.GetInt (LEVEL_STATUS_3_KEY);
		levelStatus4 = PlayerPrefs.GetInt (LEVEL_STATUS_4_KEY);
		firstLaunch = PlayerPrefs.GetInt (FIRST_LAUNCH_KEY);
	}

	public void saveDatas () {
		PlayerPrefs.SetInt (LEVEL_STATUS_1_KEY, levelStatus1);
		PlayerPrefs.SetInt (LEVEL_STATUS_2_KEY, levelStatus2);
		PlayerPrefs.SetInt (LEVEL_STATUS_3_KEY, levelStatus3);
		PlayerPrefs.SetInt (LEVEL_STATUS_4_KEY, levelStatus4);
	}

	public void loadDebugDatas () {
		levelStatus1 = (int)LevelStatus.SUCCESSED;
		levelStatus2 = (int)LevelStatus.SUCCESSED;
		levelStatus3 = (int)LevelStatus.SUCCESSED;
		levelStatus4 = (int)LevelStatus.SUCCESSED;
	}
}
