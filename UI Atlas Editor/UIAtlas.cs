using System.IO;

namespace UI_Atlas_Editor
{
    class UIAtlas
    {
        public byte[] pre_data; //data before spritedata list
        public UISpriteData[] mSprites;
        public byte[] post_data; //data before spritedata list

        public UIAtlas() { }

        public UIAtlas(BinaryReader reader)
        {
            Load(reader);
        }

        public void Load(BinaryReader reader)
        {
            pre_data = new byte[44];
            for (int i = 0; i < pre_data.Length; i++)
            {
                pre_data[i] = reader.ReadByte();
            }
            mSprites = new UISpriteData[reader.ReadInt32()];
            for (int i = 0; i < mSprites.Length; i++)
            {
                mSprites[i] = new UISpriteData(reader);
            }
            post_data = new byte[24];
            for (int i = 0; i < post_data.Length; i++)
            {
                post_data[i] = reader.ReadByte();
            }
        }

        public void Save(BinaryWriter writer)
        {
            for (int i = 0; i < pre_data.Length; i++)
            {
                writer.Write(pre_data[i]);
            }
            writer.Write(mSprites.Length);
            for (int i = 0; i < mSprites.Length; i++)
            {
                mSprites[i].Save(writer);
            }
            for (int i = 0; i < post_data.Length; i++)
            {
                writer.Write(post_data[i]);
            }
        }

        public string[] GetSpriteNames()
        {
            string[] names = new string[mSprites.Length];
            for (int i = 0; i < mSprites.Length; i++)
            {
                names[i] = mSprites[i].name;
            }
            return names;
        }

        public UISpriteData GetSpriteData(int index)
        {
            return mSprites[index];
        }
    }
}
