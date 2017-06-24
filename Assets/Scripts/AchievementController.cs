﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AchievementController :MonoBehaviour
{
	AchievementRepository achiRepos;
	AchievementRepository.Achievement achieve;

	[SerializeField]
	GameObject tileParent;
	[SerializeField]
	GameObject listView;
	[SerializeField]
	GameObject summaryView;

	[SerializeField]
	Text highScoreText;
	[SerializeField]
	Text totalScoreText;

	void Awake()
	{
		listView.SetActive (true);
		summaryView.SetActive (false);

		achiRepos = GetComponent<AchievementRepository> ();
		achieve = achiRepos.LoadAchievement ();

		List<int> achievedIdList = achieve.achievedIdList;
		AssginTiles (achievedIdList);
		SetSummary ();

	}

	void AssginTiles( List<int> list )
	{
		foreach ( int element in list) 
		{
			int index = element - 1;
			GameObject tile = tileParent.transform.GetChild(index).gameObject; //tileParent以下のachievementの並びがCSVのindexと同じである必要がある
			tile.transform.GetChild (1).gameObject.SetActive (false); //子供の2番目 hideImage をfalse にしている
			tile.GetComponent<AchievementButtonModel> ().SetAchieved(true);
		}
	}

	void SetSummary()
	{
		int highScore = achieve.highScore;
		int totalScore = achieve.totalScore;

		highScoreText.text = "HighScore: " + highScore.ToString ();
		totalScoreText.text = "TotalScore: " + totalScore.ToString ();
	}

	public void EnableListView()
	{
		listView.SetActive (true);
		summaryView.SetActive (false);
	}

	public void EnableSummaryView()
	{
		summaryView.SetActive (true);
		listView.SetActive (false);
	}

}
