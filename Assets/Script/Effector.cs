using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorMgr {

	//enum
	enum VerNoType { NOT_SETTED = -1, INIT_VER = 0 }

	//variable
	MonoBehaviour parent;
	int verNo = (int)VerNoType.NOT_SETTED;
	List<Effector> effectorList = new List<Effector>();

	//property
	public int VerNo { get { return verNo; } }

	public EffectorMgr(MonoBehaviour parent = null) {
		this.parent = parent;
	}
	public EffectorMgr(Effector[] effectors, MonoBehaviour parent = null) {
		SetEffectorList(effectors);
		verNo = (int)VerNoType.INIT_VER;
		this.parent = parent;
	}
	public EffectorMgr(Effector[] effectors, uint verNo, MonoBehaviour parent = null) {
		SetEffectorList(effectors);
		this.verNo = (int)verNo;
		this.parent = parent;
	}

	void SetEffectorList(Effector[] effectors) {
		effectorList.Clear();
		foreach (Effector effector in effectors) {
			effectorList.Add(effector.CopyWithNewParent(parent));
		}
	}

	void SetEffectorList(List<Effector> effectorList) {
		this.effectorList.Clear();
		for (int i = 0; i < effectorList.Count; ++i) {
			this.effectorList.Add(effectorList[i].CopyWithNewParent(parent));
		}
	}

	public void RunEffectors(MonoBehaviour target) {
		for (int i = 0; i < effectorList.Count; ++i) {
			effectorList[i].RunEffector(target);
		}
	}

	public void SynchronizeWith(EffectorMgr target) {
		if (verNo == target.verNo) {
			return;
		}

		verNo = target.verNo;
		SetEffectorList(target.effectorList);
	}

	public void UpdateEffectors(params Effector[] effectors) {
		++verNo;
		SetEffectorList(effectors);
	}
}

public abstract class Effector {

	//variable
	protected MonoBehaviour parent;

	public abstract void RunEffector(MonoBehaviour target);
	public abstract Effector CopyWithNewParent(MonoBehaviour parent);
	protected virtual void Init(MonoBehaviour parent) {
		this.parent = parent;
	}
}

public class Destroyer : Effector {

	//caching
	ObjPool.Releaser parentReleaser;

	public override void RunEffector(MonoBehaviour target) {
		parentReleaser.Release();
	}

	public override Effector CopyWithNewParent(MonoBehaviour parent) {
		Destroyer copied = new Destroyer();
		copied.Init(parent);
		return copied;
	}

	protected override void Init(MonoBehaviour parent) {
		base.Init(parent);
		parentReleaser = this.parent.GetComponent<ObjPool.Releaser>();
	}
}

public class AddScore : Effector {

	//variable
	int score;

	public AddScore(int score) {
		this.score = score;
	}

	public override void RunEffector(MonoBehaviour target) {
		(target as SGT_Player).AddScore(score);
	}

	public override Effector CopyWithNewParent(MonoBehaviour parent) {
		AddScore copied = new AddScore(score);
		copied.Init(parent);
		return copied;
	}
}

public class AddLife : Effector {

	//variable
	float life;

	public AddLife(float life) {
		this.life = life;
	}

	public override void RunEffector(MonoBehaviour target) {
		(target as SGT_Player).AddLife(life);
	}

	public override Effector CopyWithNewParent(MonoBehaviour parent) {
		AddLife copied = new AddLife(life);
		copied.Init(parent);
		return copied;
	}
}

public class IncreaseCombo : Effector {

	//variable
	int combo;

	public IncreaseCombo(int combo) {
		this.combo = combo;
	}

	public override void RunEffector(MonoBehaviour target) {
		(target as SGT_Player).IncreaseCombo(combo);
	}

	public override Effector CopyWithNewParent(MonoBehaviour parent) {
		IncreaseCombo copied = new IncreaseCombo(combo);
		copied.Init(parent);
		return copied;
	}
}

public class StopCombo : Effector {

	public override void RunEffector(MonoBehaviour target) {
		(target as SGT_Player).StopCombo();
	}

	public override Effector CopyWithNewParent(MonoBehaviour parent) {
		StopCombo copied = new StopCombo();
		copied.Init(parent);
		return copied;
	}
}