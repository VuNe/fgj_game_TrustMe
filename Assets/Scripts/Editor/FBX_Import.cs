using UnityEngine;
using UnityEditor;
using System.Collections;

//set mesh scale to 1
public class FBX_Import : AssetPostprocessor {

	public const float importScale = 1.0f;

	void OnPreprocessModel()
	{
		ModelImporter importer = assetImporter as ModelImporter;
		importer.globalScale = importScale;
	}
}
