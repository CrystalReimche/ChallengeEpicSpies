using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            // Sets default selected days on calendar
            previousCalendar.SelectedDate = DateTime.Now.Date;
            newCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
            endCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Calculating budget for length of deployment
        TimeSpan totalDurationOfDeployment = endCalendar.SelectedDate.Subtract(newCalendar.SelectedDate);   // Calculates how many days new assignment is
        double budget = totalDurationOfDeployment.TotalDays * 500;   // Multiplying 500 to the total amount of days in new assignment

        // If length of deployment is > 21, add extra $1000
        if (totalDurationOfDeployment.TotalDays > 21)
        {
            budget += 1000;
        }

        resultLabel.Text = String.Format("Assignment of {0} to assignment {1} is authorized.  Budget total: {2:C}", spyTextBox.Text, assignmentTextBox.Text, budget);


        TimeSpan timeBetweenDeployments = newCalendar.SelectedDate.Subtract(previousCalendar.SelectedDate); // Calculates how many days there from today's date until the start of the next deployment date
        if (timeBetweenDeployments.TotalDays < 14)
        {
            resultLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment.";
            DateTime earliestNewDeploymentDate = previousCalendar.SelectedDate.AddDays(14); // Since there's a 14 day cooldown, display earliest deployment date possible on newCalendar
            newCalendar.SelectedDate = earliestNewDeploymentDate;
            newCalendar.VisibleDate = earliestNewDeploymentDate;
        }









     

        //resultLabel.Text = String.Format("Assignment of {0} to assignment {1} is authorized", spyTextBox.Text, assignmentTextBox.Text);
    }
    
}