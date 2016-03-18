using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MessageControl : System.Web.UI.UserControl
    {
        private bool binded = false;
        public MessageType Type
        {
            get
            {
                if (ViewState["MessageType"] == null)
                {
                    ViewState["MessageType"] = MessageType.Error;
                }

                return (MessageType)Enum.Parse(typeof(MessageType), ViewState["MessageType"].ToString());
            }

            set
            {
                ViewState["MessageType"] = value;
            }
        }

        public string Text
        {
            get
            {
                if (ViewState["MessageText"] == null)
                    return "";
                else
                    return ViewState["MessageText"].ToString();
            }

            set
            {
                ViewState["MessageText"] = value;
            }
        }

        public void ShowErrorMessage(string message)
        {
            Bind(message, MessageType.Error);
        }

        public void ShowQuestionMessage(string strMessage)
        {
            Bind(strMessage, MessageType.Question);
        }

        public void ShowInfoMessage(string message)
        {
            Bind(message, MessageType.Info);
        }

        private void Bind()
        {
            messageContainerDIV.Visible = true;
            BindImage();
            BindText();
            binded = true;
        }

        private void Bind(string message, MessageType messageType)
        {
            Text = message;
            Type = messageType;
            Bind();
        }

        private void BindText()
        {
            if (Text.EndsWith(".") || Text.EndsWith("!"))
                MessageLabel.Text = Text;
            else
                MessageLabel.Text = Text + ".";

            MessageLabel.Visible = true;
        }

        private void BindImage()
        {
            switch (Type)
            {
                case MessageType.Error:
                    IconImage.ImageUrl = "~/Images/Message/error.png";
                    MessageLabel.Attributes.Add("class", "errorMessage");
                    break;
                case MessageType.Info:
                    IconImage.ImageUrl = "~/Images/Message/info.png";
                    MessageLabel.Attributes.Add("class", "infoMessage");
                    break;
                case MessageType.Question:
                    IconImage.ImageUrl = "~/Images/Message/Question.png";
                    MessageLabel.Attributes.Add("class", "infoMessage");
                    break;
                default:
                    IconImage.ImageUrl = "~/Images/Message/icon-error.gif"; 
                    break;
            }
            IconImage.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Visible = binded;
            IconImage.Visible = binded;
            messageContainerDIV.Visible = binded;
        }
    
}

public enum MessageType
{
    Error,
    Info,
    Question
}
