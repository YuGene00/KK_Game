using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class EffectorMgrTest {

	//variable
	static int runNo = 0;
	MonoBehaviour target;

	private class MockEffector : Effector {

		public override void RunEffector(MonoBehaviour target) {
			runNo += 1;
		}

		public override Effector CopyWithNewParent(MonoBehaviour parent) {
			MockEffector copied = new MockEffector();
			copied.Init(parent);
			return copied;
		}
	}

	[TestFixtureSetUp]
	public void SetMono() {
		GameObject gameObj = new GameObject();
		target = gameObj.GetComponent<MonoBehaviour>();
	}

	[SetUp]
	public void Init() {
		runNo = 0;
	}

	[Test]
	public void RunEffectorsTest() {
		//Arrange
		MockEffector effector = new MockEffector();
		Effector[] effectors = { effector, effector, effector };
		EffectorMgr effectorMgr = new EffectorMgr(effectors);

		//Act
		effectorMgr.RunEffectors(target);

		//Assert
		Assert.AreEqual(3, runNo);
	}

	[Test]
	public void SynchronizeWithTestTrue() {
		//Arrange
		MockEffector effector = new MockEffector();
		Effector[] srcEffectors = { effector, effector, effector };
		EffectorMgr srcMgr = new EffectorMgr(srcEffectors);
		EffectorMgr tarMgr = new EffectorMgr();

		//Act
		tarMgr.SynchronizeWith(srcMgr);
		tarMgr.RunEffectors(target);

		//Assert
		Assert.AreEqual(3, runNo);
	}

	[Test]
	public void SynchronizeWithTestFalse() {
		//Arrange
		MockEffector effector = new MockEffector();
		Effector[] srcEffectors = { effector, effector, effector };
		EffectorMgr srcMgr = new EffectorMgr(srcEffectors);
		Effector[] tarEffectors = { effector };
		EffectorMgr tarMgr = new EffectorMgr(tarEffectors);

		//Act
		tarMgr.SynchronizeWith(srcMgr);
		tarMgr.RunEffectors(target);

		//Assert
		Assert.AreEqual(1, runNo);
	}

	[Test]
	public void SynchronizeWithTestVerNo() {
		//Arrange
		MockEffector effector = new MockEffector();
		Effector[] srcEffectors = { effector, effector, effector };
		EffectorMgr srcMgr = new EffectorMgr(srcEffectors, 3);
		EffectorMgr tarMgr = new EffectorMgr();

		//Act
		tarMgr.SynchronizeWith(srcMgr);

		//Assert
		Assert.AreEqual(3, tarMgr.VerNo);
	}

	[Test]
	public void UpdateEffectorsTestEffectors() {
		//Arrange
		MockEffector effector = new MockEffector();
		Effector[] effectors = { effector };
		EffectorMgr effectorMgr = new EffectorMgr(effectors);

		//Act
		effectorMgr.UpdateEffectors(effector, effector, effector);
		effectorMgr.RunEffectors(target);

		//Assert
		Assert.AreEqual(3, runNo);
	}

	[Test]
	public void UpdateEffectorsTestVerNo() {
		//Arrange
		MockEffector effector = new MockEffector();
		Effector[] effectors = { effector };
		EffectorMgr effectorMgr = new EffectorMgr(effectors, 2);

		//Act
		effectorMgr.UpdateEffectors(effector, effector, effector);

		//Assert
		Assert.AreEqual(3, effectorMgr.VerNo);
	}
}
