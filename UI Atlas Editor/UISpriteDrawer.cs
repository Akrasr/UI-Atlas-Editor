using System.Drawing;

namespace UI_Atlas_Editor
{
    class UISpriteDrawer
    {
        public Graphics g;
        public Image SpriteAtlas;
        private const int BrushWidth = 2; 

        public UISpriteDrawer() { }

        public UISpriteDrawer(Image atlas, Graphics graph)
        {
            this.g = graph;
            this.SpriteAtlas = atlas;
        }

        public void DrawUISprite(UISpriteData data)
        {
            Rectangle rct = new Rectangle(data.x, data.y, data.width, data.height);
            Bitmap bmp = SpriteAtlas as Bitmap;
            try
            {
                Bitmap cropBmp = bmp.Clone(rct, bmp.PixelFormat); //extracting sprite from atlas
                DrawOnCenter(cropBmp);
            }
            catch
            {
                Clear();
            }
        }

        public void DrawAtlas()
        {
            DrawOnCenter(SpriteAtlas);
        }

        public void Clear()
        {
            g.Clear(Form1.Back);
        }

        public void DrawOnCenter(Image img)
        {
            g.Clear(Form1.Back);
            int wid = (int)(g.VisibleClipBounds.Width);
            int hei = (int)(g.VisibleClipBounds.Height);
            float mas = GetMaschtab(img);
            int imagewid = (int)((float)img.Width * mas); // getting coordinates for drawing at center
            int imagehei = (int)((float)img.Height * mas);
            int x = (wid - imagewid) / 2;
            int y = (hei - imagehei) / 2;
            g.DrawImage(img, x, y, imagewid, imagehei);
            g.DrawRectangle(new Pen(Color.Black, BrushWidth), x + 1, y + 1, //drawing borders
                imagewid - 1, imagehei - 1);
        }

        public float GetMaschtab(Image img)
        {
            int wid = (int)(g.VisibleClipBounds.Width);
            int hei = (int)(g.VisibleClipBounds.Height);
            float wex = (float)wid / (float)img.Width;
            float hex = (float)hei / (float)img.Height;
            return wex < hex ? wex : hex;
        }
    }
}
