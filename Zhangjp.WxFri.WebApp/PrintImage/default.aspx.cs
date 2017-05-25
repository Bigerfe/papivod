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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace Easo.Web.PrintImage
{
    public partial class _default : System.Web.UI.Page
    {

        int randlenght = 4;//产生的随机数的长度 

        protected void Page_Load(object sender, EventArgs e)
        {
            string vNum = this.RndNum(randlenght);
            base.Response.Cookies["LoginCode"].Value = vNum.Replace(" ", "");
            base.Response.Cookies["LoginCode"].Expires = DateTime.Now.AddHours(1);
            this.ValidateCode(vNum);
        }



        /// <summary>
        /// 返回随即数字
        /// </summary>
        /// <param name="VcodeNum"></param>
        /// <returns></returns>
        private string RndNum(int VcodeNum)
        {
            string[] textArray = "0,1,2,3,4,5,6,7,8,9".Split(new char[] { ',' });
            string text2 = "";
            int num = -1;
            Random random = new Random();
            for (int i = 1; i < (VcodeNum + 1); i++)
            {
                if (num != -1)
                {
                    random = new Random((i * num) * ((int)DateTime.Now.Ticks));
                }
                int index = random.Next(9);
                if ((num != -1) && (num == index))
                {
                    return this.RndNum(VcodeNum);
                }
                num = index;
                text2 = text2 + textArray[index] + " ";
            }
            return text2;
        }



        private void ValidateCode(string VNum)
        {
            Bitmap image = null;
            Graphics graphics = null;
            MemoryStream stream = null;
            int width = 40;
            image = new Bitmap(width, 0x10);
            graphics = Graphics.FromImage(image);
            graphics.Clear(Color.MintCream);
            Font font = new Font("Verdana,Arial", 10f, FontStyle.Bold);
         
            SolidBrush brush = new SolidBrush(Color.DeepPink);
            string[] textArray = VNum.Split(new char[] { ' ' });
            for (int i = 0; i < textArray.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        brush = new SolidBrush(Color.Blue);
                        break;

                    case 2:
                        brush = new SolidBrush(Color.DarkSeaGreen);
                        break;

                    case 3:
                        brush = new SolidBrush(Color.MediumOrchid);
                        break;

                    case 4:
                        brush = new SolidBrush(Color.Firebrick);
                        break;
                }
                graphics.DrawString(textArray[i], font, brush, (float)(i * 9), 1f);
            }
            stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);


            base.Response.ClearContent();
            base.Response.ContentType = "image/Jpeg";
            base.Response.BinaryWrite(stream.ToArray());
            graphics.Dispose();
            image.Dispose();
            base.Response.End();
        }
    }
}
