using UnityEngine;

public class Score {

	//const
	const string HighScoreHash = "HighScore";

	//variable
	int currentScore = 0;

	//property
	public int CurrentScore { get { return currentScore; } set { currentScore = value; } }
	public int HighScore {
		get {
			return PlayerPrefs.HasKey(HighScoreHash) ? PlayerPrefs.GetInt(HighScoreHash) : 0;
		}
		set { PlayerPrefs.SetInt(HighScoreHash, value); }
	}

	public void UpdateHighScore() {
		if(currentScore > HighScore) {
			HighScore = currentScore;
		}
	}

	public void DeleteHighScore() {
		PlayerPrefs.DeleteKey(HighScoreHash);
	}
}
