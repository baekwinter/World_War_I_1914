using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset(AssetPath = "Resources/DataBase", ExcelName = "Unit_DataBase")]
public class Unit_DataBase : ScriptableObject
{
	public List<EnemyData> EnemyDataBase; // Replace 'EntityType' to an actual type that is serializable.
    public List<FortData> FortDataBase; // Replace 'EntityType' to an actual type that is serializable.
    public List<StageData> StageDataBase; // Replace 'EntityType' to an actual type that is serializable.
    public List<EnemyGroupData> EnemyGroupDataBase; // Replace 'EntityType' to an actual type that is serializable.
    public List<CommanderData> CommanderDataBase; // Replace 'EntityType' to an actual type that is serializable.
    public List<BulletData> BulletDataBase;
}
