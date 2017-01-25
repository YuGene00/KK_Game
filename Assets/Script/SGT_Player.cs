using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGT_Player : MonoBehaviour {

	//singleton
	static SGT_Player instance = null;
	public static SGT_Player Instance { get { return instance; } }

	//caching
	Transform trans;

	//variable
	Move move;
	Score score;
	Life life;
	Combo combo;

	//property
	public Vector2 Position { get { return trans.position; } }

	private void Awake() {
		instance = this;
		InitCaching();
		InitVariable();
	}

	void InitCaching() {
		trans = transform;
	}

	void InitVariable() {
		InitMove();
		InitScore();
		InitLife();
		InitCombo();
	}

	void InitMove() {
		Vector2 leftBot = new Vector2(-360f, Position.y);
		Vector2 rightUp = new Vector2(360f, Position.y);
		Area moveArea = new Area(leftBot, rightUp);
		move = new Move(trans, moveArea);
	}

	void InitScore() {
		score = new Score();
	}

	void InitLife() {
		life = new Life(5);
	}

	void InitCombo() {
		combo = new Combo(2);
	}

	public void Move(Vector2 dest) {
		move.MoveToDestInArea(dest);
	}

	public void AddScore(int score) {
		this.score.CurrentScore += score;
	}

	public void AddLife(float life) {
		this.life.CurrentLife += life;
	}

	public void IncreaseCombo(int combo) {
		this.combo.Increase(combo);
	}

	public void StopCombo() {
		combo.Stop();
	}
}
