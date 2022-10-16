using System.IO;
using UnityEditor;
using UnityEngine;

namespace MyNotes
{
    public class MyNotesMenu : MonoBehaviour
    {
        const string menuItem = "Tools/My Notes/";
        const string toolPath = "Packages/com.kiltec.mynotes/Editor/";

        [MenuItem(menuItem + "Edit Note %&n", priority = 20)] // Shortcut [Ctrl + Alt + N]
        public static void ShowWindow()
        {
            MyNotes.GetWindow(typeof(MyNotes));
        }

        [MenuItem(menuItem + "Note Style Settings", priority = 30)]
        private static void NoteSettings()
        {
            var path = $"{toolPath}New My Notes Style.asset";

            if (!File.Exists(path)) { return; }

            var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }

        [MenuItem(menuItem + "Note Help", priority = 40)]
        private static void NoteHelp()
        {
            var path = $"{toolPath}README.md";

            if (!File.Exists(path)) { return; }

            var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }

        [MenuItem(menuItem + "Delete/Clear Note")]
        public static void DeleteNote()
        {
            MyNotes.DeleteSavedText();
        }
    }
}