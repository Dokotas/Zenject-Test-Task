using UnityEditor;
using UnityEngine;

namespace App
{
    public sealed class ApplicationFinisher
    {
        public void Finish()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}



