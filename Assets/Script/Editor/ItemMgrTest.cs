using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ItemMgrTest {

	[Test]
	public void SetCreatorWithDurationTest() {
		//Arrange
		ItemMgr itemMgr = new ItemMgr();

		//Act
		ItemCreator itemCreator = new ItemCreator("Prefab/Temp");
		int idx0 = itemMgr.SetCreatorWithDuration(itemCreator, 3f);
		int idx1 = itemMgr.SetCreatorWithDuration(itemCreator, 3f);
		int idx2 = itemMgr.SetCreatorWithDuration(itemCreator, 3f);

		//Assert
		Assert.AreEqual(2, idx2);
	}

	[Test]
	public void RemoveCreatorWithIdxTest() {
		//Arrange
		ItemMgr itemMgr = new ItemMgr();

		//Act
		ItemCreator itemCreator = new ItemCreator("Prefab/Temp");
		int idx0 = itemMgr.SetCreatorWithDuration(itemCreator, 3f);
		int idx1 = itemMgr.SetCreatorWithDuration(itemCreator, 3f);
		int idx2 = itemMgr.SetCreatorWithDuration(itemCreator, 3f);
		itemMgr.RemoveCreatorWithIdx(idx1);
		int idxAfterRemove = itemMgr.SetCreatorWithDuration(itemCreator, 3f);

		//Assert
		Assert.AreEqual(1, idxAfterRemove);
	}
}
