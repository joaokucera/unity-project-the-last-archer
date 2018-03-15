using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public static class LineEndings
{
    [MenuItem("Tools / Conversion / Windows Format")]
    public static void ConvertLineEndingsToWindowsFormat()
    {
        ConvertLineEndings(false);
    }

    [MenuItem("Tools / Conversion / UNIX Format")]
    public static void ConvertLineEndingsToUnixFormat()
    {
        ConvertLineEndings(true);
    }

    private static void ConvertLineEndings(bool isUnixFormat)
    {
        string title = string.Format(
            "Conversion to {0} Format",
            (isUnixFormat ? "UNIX" : "Windows"));
        
        if (!EditorUtility.DisplayDialog(
            title,
            "This operation may potentially modify " +
            "many files in the current project! " +
            "Hopefully you have backups of everything. " +
            "Are you sure you want to proceed?",
            "Yes",
            "No")) {
            Debug.Log("Conversion was not attempted.");
            return;
        }

        var fileTypes = new string[] {
            "*.txt",
            "*.cs",
            "*.js",
            "*.boo",
            "*.compute",
            "*.shader",
            "*.cginc",
            "*.glsl",
            "*.xml",
            "*.xaml",
            "*.json",
            "*.inc",
            "*.css",
            "*.htm",
            "*.html",
        };

        string projectAssetsPath = Application.dataPath;
        int totalFileCount = 0;
        var changedFiles = new List<string>();
        var regex = new Regex(@"(?<!\r)\n");
        const string LineEnd = "\r\n";
        var comparisonType = System.StringComparison.Ordinal;

        foreach (string fileType in fileTypes) {
            string[] filenames = Directory.GetFiles(
                projectAssetsPath,
                fileType,
                SearchOption.AllDirectories);

            totalFileCount += filenames.Length;

            foreach (string filename in filenames) {
                string originalText = File.ReadAllText(filename);
                string changedText;
                changedText = regex.Replace(originalText, LineEnd);
                if (isUnixFormat) {
                    changedText =
                        changedText.Replace(LineEnd, "\n");
                }

                bool isTextIdentical = string.Equals(
                    changedText, originalText, comparisonType);

                if (!isTextIdentical) {
                    changedFiles.Add(filename);
                    File.WriteAllText(
                        filename,
                        changedText,
                        System.Text.Encoding.UTF8);
                }
            }
        }

        int changedFileCount = changedFiles.Count;
        int skippedFileCount = (totalFileCount - changedFileCount);
        string message = string.Format(
            "Conversion skipped {0} " +
            "files and changed {1} files",
            skippedFileCount,
            changedFileCount);

        if (changedFileCount <= 0) {
            message += ".";
        }
        else {
            message += (":" + LineEnd);
            message += string.Join(LineEnd, changedFiles.ToArray());
        }

        Debug.Log(message);
        if (changedFileCount > 0) {
            // Recompile modified scripts.
            AssetDatabase.Refresh();
        }
    }
}