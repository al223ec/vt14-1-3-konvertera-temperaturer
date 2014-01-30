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
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery", new ScriptResourceDefinition
                     {
                         Path = "/Scripts/jquery-2.1.0.min.js",
                         DebugPath = "/Scripts/jquery-2.1.0.js",
                         CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.0.min.js",
                         CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1..js",
                         CdnSupportsSecureConnection = true,
                         LoadSuccessExpression = "jQuery"
                     });
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    var startTemp = int.Parse(StartTempTextBox.Text);
                    var slutTemp = int.Parse(EndTempTextBox.Text);
                    var step = int.Parse(StepTextBox.Text);

                    if (startTemp - slutTemp > step)
                    {
                        throw new ApplicationException("Temperatursteg kan inte vara större än skillnaden mellan start och sluttemperaturen");
                    }

                    FormatTableheader(CelsiusRadioButton.Checked); 

                    for (var temp = startTemp; temp < slutTemp; temp += step)
                    {
                        TableRow tRow = new TableRow();
                        tRow.Cells.Add(new TableCell{ 
                            Text = temp.ToString()
                        }); 

                        TableCell tCell = new TableCell();
                        if (CelsiusRadioButton.Checked)
                        {
                            tCell.Text = temp.CelsiusToFahrenheit().ToString();
                        }
                        else
                        {
                            tCell.Text = temp.FahrenheitToCelsius().ToString();
                        }
                        tRow.Cells.Add(tCell);
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
        private void FormatTableheader(Boolean isChecked)
        {
            TableRow tRow = new TableRow();
            tRow.CssClass = "inverse-small";
            if (CelsiusRadioButton.Checked)
            {
                tRow.Cells.Add(new TableCell
                {
                    Text = "C&deg",
                });
                tRow.Cells.Add(new TableCell
                {
                    Text = "F&deg",
                });
            }
            else
            {
                tRow.Cells.Add(new TableCell
                {
                    Text = "F&deg",
                });
                tRow.Cells.Add(new TableCell
                {
                    Text = "C&deg",
                });
            }
            OutputTable.Rows.Add(tRow);
        }
    }
}