using System.IO;

namespace UI_Atlas_Editor
{
    class SaveLoadManager
    {
        public UIAtlas Atlas;
        public string FilePath;
        private int Length;

        public SaveLoadManager(string path)
        {
            Load(path);
        }

        public void Load(string path)
        {
            byte[] file = File.ReadAllBytes(path);
            Length = file.Length;
            FilePath = path;
            Atlas = new UIAtlas(new BinaryReader(new MemoryStream(file)));
        }

        public void Save()
        {
            SaveAs(FilePath);
        }

        public void SaveAs(string path)
        {
            Atlas.Save(new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)));
            FilePath = path;
        }
    }
}
