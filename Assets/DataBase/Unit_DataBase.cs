using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset(AssetPath = "Resources/DataBase", ExcelName = "Unit_DataBase")]
public class Unit_DataBase : ScriptableObject
{
	public List<EnemyData> EnemyDataBase; // Replace 'EntityType' to an actual type that is serializable.
}
