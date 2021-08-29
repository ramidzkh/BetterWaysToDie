using UnityEngine;

namespace BetterWaysToDie.Gui
{
    public class TestGuiWindow : GUIWindow
    {
        private Vector2i lastResolution;
        private GUIStyle labelStyle;
        private GUIStyle buttonStyle;
        private GUIStyle textfieldStyle;

        public TestGuiWindow(GameManager _gameManager)
            : base(GUIWindowConsole.ID, new Rect(0.0f, 0.0f, Screen.width / 3, Screen.height))
        {
            alwaysUsesMouseCursor = true;
        }

        public void Open()
        {
            windowManager.Open(this, false);
        }

        public override void OnGUI(bool _inputActive)
        {
            base.OnGUI(_inputActive);
            var vector2i = new Vector2i(Screen.width, Screen.height);
            if (lastResolution != vector2i)
            {
                lastResolution = vector2i;
                labelStyle = new GUIStyle(GUI.skin.label);
                textfieldStyle = new GUIStyle(GUI.skin.textField);
                buttonStyle = new GUIStyle(GUI.skin.button);
                if (vector2i.y > 1200)
                {
                    var num = vector2i.y / 90;
                    labelStyle.fontSize = num;
                    textfieldStyle.fontSize = num;
                    buttonStyle.fontSize = num;
                }
                else
                {
                    labelStyle.fontSize = 0;
                    textfieldStyle.fontSize = 0;
                    buttonStyle.fontSize = 0;
                }
            }
            
            GUI.Box(new Rect(0, 0, Screen.width / 3, Screen.height), "");
        }
    }
}
