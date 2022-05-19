using System.Drawing;

namespace UI_Atlas_Editor
{
    class MainManager
    {
        public UIAtlas atlas;
        public SaveLoadManager slm;
        public UISpriteDrawer drawer;
        public UISpriteData uisd;
        public MainManager(string filePath, string imagePath, Graphics g)
        {
            slm = new SaveLoadManager(filePath);
            atlas = slm.Atlas;
            drawer = new UISpriteDrawer(Image.FromFile(imagePath), g);
        }

        public string[] GetSpriteNames()
        {
            return atlas.GetSpriteNames();
        }

        public void LoadSpriteData(int index)
        {
            uisd = GetSpriteData(index);
            DrawSprite(uisd);
        }

        public UISpriteData GetSpriteData(int index)
        {
            return atlas.GetSpriteData(index);
        }

        //setting sprite data params
        public void SetName(string name)
        {
            uisd.name = name;
        }

        public void SetX(int x)
        {
            uisd.x = x;
            DrawSprite(uisd);
        }

        public void SetY(int y)
        {
            uisd.y = y;
            DrawSprite(uisd);
        }

        public void SetWidth(int width)
        {
            if (width == 0)
            {
                drawer.Clear();
                return;
            }
            uisd.width = width;
            DrawSprite(uisd);
        }

        public void SetHeight(int height)
        {
            if (height == 0)
            {
                drawer.Clear();
                return;
            }
            uisd.height = height;
            DrawSprite(uisd);
        }

        public void SetBorderLeft(int border)
        {
            uisd.borderLeft = border;
        }

        public void SetBorderRight(int border)
        {
            uisd.borderRight = border;
        }

        public void SetBorderTop(int border)
        {
            uisd.borderTop = border;
        }

        public void SetBorderBottom(int border)
        {
            uisd.borderBottom = border;
        }

        public void SetPaddingLeft(int border)
        {
            uisd.paddingLeft = border;
        }

        public void SetPaddingRight(int border)
        {
            uisd.paddingRight = border;
        }

        public void SetPaddingTop(int border)
        {
            uisd.paddingTop = border;
        }

        public void SetPaddingBottom(int border)
        {
            uisd.paddingBottom = border;
        }
        public void DrawSprite(UISpriteData data)
        {
            drawer.DrawUISprite(data);
        }

        public void DrawAtlas()
        {
            uisd = null;
            drawer.DrawAtlas();
        }

        public void SaveAs(string path)
        {
            slm.SaveAs(path);
        }

        public void Save()
        {
            slm.Save();
        }
    }
}
