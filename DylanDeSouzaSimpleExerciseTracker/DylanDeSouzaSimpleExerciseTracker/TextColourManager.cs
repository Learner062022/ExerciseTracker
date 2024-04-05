using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class TextColourManager
    {
        public static void SetTextColour(Label label, double average, int expectedAverage) => label.TextColor = average < expectedAverage ? Color.Red : Color.Green;
    }
}
