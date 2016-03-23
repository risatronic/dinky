using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WebPartTraining.TemperatureConverterPart
{
    [ToolboxItemAttribute(false)]
    public class TemperatureConverterPart : WebPart
    {
        Label lblText = new Label();
        Label lblResult = new Label();
        TextBox txtTemp = new TextBox();
        Button btnCtoF = new Button();
        Button btnFtoC = new Button();

        protected override void CreateChildControls()
        {
            lblText.Text = "Temperature to convert:   ";
            btnCtoF.Text = "Celcius to Fahrenheit";
            btnFtoC.Text = "Fahrenheit to Celcius";

            btnCtoF.Click += BtnCtoF_Click;
            btnFtoC.Click += BtnFtoC_Click;
           
            this.Controls.Add(new LiteralControl("<div style='width: 300px;text-align: center; font-weight: bold;'>"));

            this.Controls.Add(lblText);
            this.Controls.Add(txtTemp);

            this.Controls.Add(new LiteralControl("<br /><br />"));

            this.Controls.Add(btnCtoF);
            this.Controls.Add(btnFtoC);

            this.Controls.Add(new LiteralControl("<br /><br />"));

            this.Controls.Add(lblResult);
        }


        void BtnCtoF_Click(object sender, EventArgs e)
        {
            double tempC;
            if(double.TryParse(txtTemp.Text.ToString(), out tempC))
            {
                double fahrenheit = tempC * (9 / 5) + 32;
                fahrenheit = Math.Round(fahrenheit, 2);

                lblResult.ForeColor = System.Drawing.Color.Green;

                lblResult.Text = tempC + " degrees C is equal to " + fahrenheit + " degrees F";
            }

            else if (txtTemp.Text.Equals(""))
            {
                lblResult.ForeColor = System.Drawing.Color.Red;

                lblResult.Text = "You must enter a number to convert";
            }

            else
            {
                lblResult.ForeColor = System.Drawing.Color.Red;

                lblResult.Text = "Invalid input, please enter a number";
            }

        }

        void BtnFtoC_Click(object sender, EventArgs e)
        {
            double tempF;
            if (double.TryParse(txtTemp.Text.ToString(), out tempF))
            {
                double celcius = (tempF - 32) * (5 / 9);
                celcius = Math.Round(celcius, 2);

                lblResult.ForeColor = System.Drawing.Color.Green;

                lblResult.Text = tempF + " degrees F is equal to " + celcius + " degrees C";
            }

            else if (txtTemp.Text.Equals(""))
            {
                lblResult.ForeColor = System.Drawing.Color.Red;

                lblResult.Text = "You must enter a number to convert";
            }

            else
            {
                lblResult.ForeColor = System.Drawing.Color.Red;

                lblResult.Text = "Invalid input, please enter a number";
            }
        }

    }
}
