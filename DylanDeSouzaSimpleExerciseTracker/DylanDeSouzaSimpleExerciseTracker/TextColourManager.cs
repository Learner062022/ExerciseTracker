using System.Collections.Generic;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class TextColourManager
    {
        static readonly Dictionary<string, Color> _colourMap = new Dictionary<string, Color>
        {
            ["Default"] = Color.Black,
            ["Blue"] = Color.Blue,
        };

        public static void UpdateTextColour(Picker colourPicker)
        {
            if (_colourMap.TryGetValue(colourPicker.SelectedItem.ToString(), out Color selectedColour))
            {
                foreach (var control in Settings.controlsInSettings)
                {
                    SetTextColour(control, selectedColour);
                }
            }
        }

        public static void SetTextColour(View view, Color color)
        {
            switch (view)
            {
                case Picker picker:
                    picker.TextColor = color;
                    break;
                case Button button:
                    button.TextColor = color;
                    break;
            }
        }
    }
}