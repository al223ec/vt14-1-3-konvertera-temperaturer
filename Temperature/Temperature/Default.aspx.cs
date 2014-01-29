using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Temperature.Model; 

namespace Temperature
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                { 
                    int tal = 20;
                    tal.CelsiusToFahrenheit();
                    if ((int.Parse(StartTempTextBox.Text) - int.Parse(EndTempTextBox.Text)) > int.Parse(StepTextBox.Text))
                    {
                        throw new ApplicationException("Temperatursteg kan inte vara större än skillnaden mellan start och sluttemperaturen");
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        TableRow tRow = new TableRow();
                        for (int j = 0; j < 2; j++)
                        {
                            TableCell tCell = new TableCell();
                            tCell.Text = tal.FahrenheitToCelsius().ToString();
                            tRow.Cells.Add(tCell);
                        }
                        OutputTable.Rows.Add(tRow);
                    }
                    OutputPanel.Visible = true;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
        }
    }
}