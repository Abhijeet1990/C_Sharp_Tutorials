using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EWSoftware.ImageMaps;
using EWSoftware.ImageMaps.Windows.Forms;
using TestImageMap.Properties;

namespace TestImageMap
{
    public partial class Form1 : Form
    {
        ImageMap imMap = new ImageMap();
        public Form1()
        {
            InitializeComponent();


            // Example code that creates an image map and adds some image areas
            

            ImageAreaRectangle imageAreaRectangle1 = new ImageAreaRectangle();
            ImageAreaCircle imageAreaCircle1 = new ImageAreaCircle();
            ImageAreaPolygon imageAreaPolygon1 = new ImageAreaPolygon();
            ImageAreaRectangle imageAreaRectangle2 = new ImageAreaRectangle();
            ImageAreaEllipse imageAreaEllipse1 = new ImageAreaEllipse();

            imageAreaRectangle1.AccessKey = "R";
            imageAreaRectangle1.Rectangle = new System.Drawing.Rectangle(16, 16, 150, 94);
            imageAreaRectangle1.TabIndex = 3;
            imageAreaRectangle1.ToolTip = "A rectangle area";

            imageAreaCircle1.AccessKey = "C";
            imageAreaCircle1.CenterPoint = new System.Drawing.Point(380, 88);
            imageAreaCircle1.Radius = 60;
            imageAreaCircle1.TabIndex = 1;
            imageAreaCircle1.ToolTip = "A circle area";

            imageAreaPolygon1.AccessKey = "P";
            imageAreaPolygon1.Points.AddRange(new System.Drawing.Point[] {
    new System.Drawing.Point(42, 186),
    new System.Drawing.Point(110, 286),
    new System.Drawing.Point(144, 250),
    new System.Drawing.Point(138, 230),
    new System.Drawing.Point(160, 216),
    new System.Drawing.Point(190, 214),
    new System.Drawing.Point(152, 168),
    new System.Drawing.Point(112, 172),
    new System.Drawing.Point(70, 154)});

            imageAreaPolygon1.TabIndex = 2;
            imageAreaPolygon1.ToolTip = "A polygon area";

            imageAreaRectangle2.Action = AreaClickAction.None;
            imageAreaRectangle2.Rectangle = new System.Drawing.Rectangle(316, 176, 206, 118);
            imageAreaRectangle2.ToolTip = "A tool tip only area";

            imageAreaEllipse1.AccessKey = "E";
            imageAreaEllipse1.Ellipse = new System.Drawing.Rectangle(199, 88, 128, 58);
            imageAreaEllipse1.TabIndex = 4;
            imageAreaEllipse1.ToolTip = "An ellipse area";

            imMap.Areas.AddRange(new IImageArea[] {
    imageAreaRectangle1,
    imageAreaCircle1,
    imageAreaPolygon1,
    imageAreaRectangle2,
    imageAreaEllipse1 });

            imMap.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            imMap.Image = ((System.Drawing.Image)(Image.FromFile("C:\\Users\\Abhijeet\\Desktop\\lead_large.png")));
            imMap.Location = new System.Drawing.Point(8, 8);
            imMap.Name = "imMap";
            imMap.Size = new System.Drawing.Size(552, 448);
            imMap.TabIndex = 0;
            imMap.ToolTip = "A test image";

            // Add a click event handler
            imMap.Click += imMap_Click;
        }

// A simple image area click handler
        private void imMap_Click(object sender, ImageMapClickEventArgs e)
        {
            MessageBox.Show(String.Format(
                "You clicked area #{0} ({1}) at point {2}, {3}",
                    e.AreaIndex + 1, imMap.Areas[e.AreaIndex].ToolTip,
                    e.XCoordinate, e.YCoordinate), "Image Map Clicked",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}
