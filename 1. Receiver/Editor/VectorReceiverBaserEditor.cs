using UnityEditor;
using UnityEngine;

namespace BilliotGames
{
    [CustomEditor(typeof(VectorReceiverBase), true)]
    public class VectorReceiverBaserEditor : Editor
    {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            var _script = (VectorReceiverBase)target;
            if (GUILayout.Button("Connect Source")) {
                if (_script.IsInputConnected()) {
                    Debug.Log("input is already connected");
                }
                else {
                    if (_script.TryFindInput()) {
                        Debug.Log($"<color=cyan>input connected</color>");
                    }
                }
            }
        }
    }
}
