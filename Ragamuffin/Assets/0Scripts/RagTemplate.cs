using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


public class RagTemplate : MonoScript
{
    /// <summary>
    /// Add a menu item to the 'Create' list called 'C# Scripts - Rag Template' & generate a new script with a custom template on click. 
    /// </summary>
    [MenuItem("Assets/Create/C# Script - Rag Template", priority = 82)]
    static void CreateScript()
    {
        const string scriptTemplateName = "/82-C# Script-NewTemplateScript.cs.txt";
        string filePath = Application.persistentDataPath + "/" + scriptTemplateName;

        WriteTemplateToPersistentDataPath(filePath);

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(filePath, "NewTemplateScript.cs");
    }

    /// <summary>
    /// Creates and saves the template to a persistent data path
    /// </summary>
    private static void WriteTemplateToPersistentDataPath(string filePath)
    {
        string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

        if (File.Exists(filePath))
        {
            string dateInFile = File.ReadLines(filePath).Skip(3).Take(1).First();

            if (!dateInFile.Equals(currentDate))
            {
                File.WriteAllText(filePath, GetTemplateAsString(currentDate));
            }
        }
        else
        {
            File.WriteAllText(filePath, GetTemplateAsString(currentDate));
        }
    }

    /// <summary>
    /// Builds the template string
    /// </summary>
    /// <returns>The custom template</returns>
    private static string GetTemplateAsString(string currentDate)
    {
        string userName = GetUnityAccountRealName();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("/*\n");
        sb.Append("#SCRIPTNAME#.cs\n");
        sb.Append(userName + "\n");
        sb.Append(currentDate + "\n");
        sb.Append("1.0\n");
        sb.Append("#SCRIPTNAME# DESCRIPTION GOES HERE\n");
        sb.Append("*/\n");
        sb.Append("using UnityEngine;\n\n");

        sb.Append("/// <summary>\n");
        sb.Append("/// Author: " + userName + "\n");
        sb.Append("/// #SCRIPTNAME# CLASS DESCRIPTION GOES HERE\n");
        sb.Append("/// </summary>\n");
        sb.Append("public class #SCRIPTNAME# : MonoBehaviour\n");
        sb.Append("{\n\n");

        sb.Append("\t/// <summary>\n");
        sb.Append("\t/// Author: " + userName + "\n");
        sb.Append("\t/// Start is called before the first frame update\n");
        sb.Append("\t/// </summary>\n");
        sb.Append("\tvoid Start()\n");
        sb.Append("\t{\n");
        sb.Append("\t\t#NOTRIM#\n");
        sb.Append("\t}\n\n");

        sb.Append("\t/// <summary>\n");
        sb.Append("\t/// Author: " + userName + "\n");
        sb.Append("\t/// Update is called once per frame\n");
        sb.Append("\t/// </summary>\n");
        sb.Append("\tvoid Update()\n");
        sb.Append("\t{\n");
        sb.Append("\t\t#NOTRIM#\n");
        sb.Append("\t}\n");
        sb.Append("}");
        return sb.ToString();
    }

    /// <summary>
    /// Gets the real name of the account logged into the current Unity editor. If not available, return name of current system.
    /// Thanks to: https://answers.unity.com/questions/1258276/accessing-unity-account-data-in-unity-editor.html 
    /// </summary>
    /// <returns>The users name on their Unity account or their name on the account they are logged into on their computer</returns>
    private static string GetUnityAccountRealName()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(UnityEditor.EditorWindow));
        object uc = assembly.CreateInstance("UnityEditor.Connect.UnityConnect", false, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null, null);

        string displayName = null;
        if (uc != null)
        {
            Type t = uc.GetType();

            object userInfo = t.GetProperty("userInfo")?.GetValue(uc, null);

            if (userInfo != null)
            {
                Type userInfoType = userInfo.GetType();
                displayName = userInfoType.GetProperty("displayName")?.GetValue(userInfo, null) as string;
            }
        }

        if (displayName == null)
        {
            displayName = Environment.UserName;
        }

        return displayName;
    }
}
