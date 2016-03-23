using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WebPartTraining.ColouredDaysToChristmasPart
{
    [ToolboxItemAttribute(false)]
    public class ColouredDaysToChristmasPart : WebPart
    {
        private string _leftImage;

        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),

        Microsoft.SharePoint.WebPartPages.SPWebCategoryName("Options"),

        WebDisplayName("Left Image"),

        WebDescription("Image to be placed on the left side.")]

        public string LeftImage

        {

            get { return _leftImage; }

            set { _leftImage = value; }

        }

        private string _rightImage;

        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),

        Microsoft.SharePoint.WebPartPages.SPWebCategoryName("Options"),

        WebDisplayName("Right Image"),

        WebDescription("Image to be placed on the right side.")]

        public string RightImage

        {

            get { return _rightImage; }

            set { _rightImage = value; }

        }

        private string _occasion;

        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),

        Microsoft.SharePoint.WebPartPages.SPWebCategoryName("Options"),

        WebDisplayName("Occasion Name"),

        WebDescription("Name of the occasion to count down to.")]

        public string Occasion

        {

            get { return _occasion; }

            set { _occasion = value; }

        }

        private int _dateMonth;

        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),

        Microsoft.SharePoint.WebPartPages.SPWebCategoryName("Options"),

        WebDisplayName("Month"),

        WebDescription("Month of the occasion to count down to.")]

        public int Month

        {

            get { return _dateMonth; }

            set { _dateMonth = value; }

        }

        private int _dateDay;

        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),

        Microsoft.SharePoint.WebPartPages.SPWebCategoryName("Options"),

        WebDisplayName("Day"),

        WebDescription("Day of the occasion to count down to.")]

        public int Day

        {

            get { return _dateDay; }

            set { _dateDay = value; }

        }

        protected override void CreateChildControls()
        {     

            DateTime today = DateTime.Today;

            if ((_dateMonth > 12) || (_dateMonth < 1))

                _dateMonth = 12;

            if ((_dateDay > 31) || (_dateDay < 1))

                _dateDay = 25;

            DateTime eventDate = new DateTime(DateTime.Today.Year, _dateMonth, _dateDay);

            if (today > eventDate)

                eventDate = eventDate.AddYears(1);            

            TimeSpan span = eventDate - today;

            LiteralControl imgLeft = new LiteralControl("<div style='float:left'><img src='" + _leftImage + "'/></div>");
            LiteralControl imgRight = new LiteralControl("<div style='float:right'><img src='" + _rightImage + "'/></div>");
            Label lblLeft = new Label();

            lblLeft.ForeColor = System.Drawing.Color.Red;

            lblLeft.Text = "There are";

            Label lblMiddle = new Label();

            lblMiddle.ForeColor = System.Drawing.Color.Green;

            lblMiddle.Text = String.Format(" {0} days ", span.Days);

            Label lblRight = new Label();

            lblRight.ForeColor = System.Drawing.Color.Red;

            lblRight.Text = "until " + _occasion + ".";

            this.Controls.Add(new LiteralControl("<div style='width: 300px;text-align: center;'>"));
            this.Controls.Add(imgLeft);

            this.Controls.Add(imgRight);

            this.Controls.Add(lblLeft);

            this.Controls.Add(new LiteralControl("<br />"));
            

            this.Controls.Add(lblMiddle);

            this.Controls.Add(new LiteralControl("<br />"));
            

            this.Controls.Add(lblRight);

            this.Controls.Add(new LiteralControl("</div>"));

            this.Controls.Add(new LiteralControl("<br style='clear: both;' />"));

}
    }
    }

