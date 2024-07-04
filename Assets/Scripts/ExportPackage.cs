using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Diagnostics;

public static class ExportPackage
{


    [MenuItem("Export/Export with tags and layers, Input settings")]
    public static void export()
    {
        string[] projectContent = new string[] { "Assets", "ProjectSettings/TagManager.asset", "ProjectSettings/InputManager.asset", "ProjectSettings/ProjectSettings.asset" };
        AssetDatabase.ExportPackage(projectContent, "Done.unitypackage", ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies);
        UnityEngine.Debug.Log("Project Exported");
    }

}