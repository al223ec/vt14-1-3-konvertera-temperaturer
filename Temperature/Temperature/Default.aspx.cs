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
                    if ((slutTemp - startTemp)/step > 750) //Begränsar tabellen till 750 rader
                    {
                        throw new ApplicationException("För många rader begärdes");
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

                    OutputPanel.Visible = true; //allting har gått bra, visa output
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
        }
        private void FormatTableheader(bool isChecked)
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