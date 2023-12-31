﻿using Controller;
using System.Web.UI;
using System.Web.UI.WebControls;
using Views;

namespace Views
{
    public static class Validation
    {
        public static bool IsTextBoxEmpty(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.CssClass = CssClassController.ChangeValidState(textBox.CssClass, false);
                return true;
            }

            textBox.CssClass = CssClassController.ChangeValidState(textBox.CssClass, true);
            return false;
        }
    }
}
