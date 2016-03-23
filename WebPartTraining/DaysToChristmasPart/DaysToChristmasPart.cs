using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WebPartTraining.DaysToChristmasPart
{
    [ToolboxItemAttribute(false)]
    public class DaysToChristmasPart : WebPart
    {
        protected override void CreateChildControls()
        {
            DateTime today = DateTime.Today;

            DateTime dtChristmas = new DateTime(DateTime.Today.Year, 12, 25);

            if (today > dtChristmas)

                dtChristmas = dtChristmas.AddYears(1);

            TimeSpan span = dtChristmas - today;

            string txt = String.Format("There are {0} days until Christmas.", span.Days);

            this.Controls.Add(new LiteralControl(txt));
        }
    }
}
