using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace UserControls
{
    public enum suit
    {
        club, diamond, heart, spade
    }

    public partial class PCSUserC1 : System.Web.UI.UserControl
    {
        protected suit currentSuit;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public suit Suit
        {
            get
            {
                return currentSuit;
            }
            set
            {
                currentSuit = value;
                suitPic.ImageUrl = "Images/" + currentSuit.ToString() + ".bmp";
                suitLabel.Text = currentSuit.ToString();
            }
        }

        public void Club()
        {
            Suit = suit.club;
        }

        public void Diamond()
        {
            Suit = suit.diamond;
        }

        public void Heart()
        {
            Suit = suit.heart;
        }

        public void Spade()
        {
            Suit = suit.spade;
        }
    }
}