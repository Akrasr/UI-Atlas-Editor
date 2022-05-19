using System.IO;

namespace UI_Atlas_Editor
{
    class UISpriteData
    {
		public string name;
		public int x;
		public int y;
		public int width;
		public int height;
		public int borderLeft;
		public int borderRight;
		public int borderTop;
		public int borderBottom;
		public int paddingLeft;
		public int paddingRight;
		public int paddingTop;
		public int paddingBottom;

		public UISpriteData() { }

		public UISpriteData(BinaryReader reader)
        {
			Load(reader);
        }

		public static string ReadStringEndian(BinaryReader br) //for reading name
        {
			int length = br.ReadInt32();
			int len = length;
			length = length % 4 != 0 ? length + (4 - length % 4) : len;
			byte[] str = new byte[length + 1];
			str[0] = (byte)len;
			for (int i = 1; i < length + 1; i++)
			{
				str[i] = br.ReadByte();
			}
			return new BinaryReader(new MemoryStream(str)).ReadString();
		}

		public static void WriteStringEndian(BinaryWriter writer, string text) //for writing name
		{
			writer.Write(text.Length);
			byte[] st = new byte[text.Length + 1];
			using (BinaryWriter bw = new BinaryWriter(new MemoryStream(st)))
			{
				bw.Write(text);
			}
			for (int i = 0; i < text.Length; i++)
			{
				writer.Write(st[i + 1]);
			}
			if (text.Length % 4 != 0)
				for (int i = 0; i < 4 - text.Length % 4; i++)
				{
					byte t = 0;
					writer.Write(t);
				}
		}

		public void Load(BinaryReader br)
        {
			name = ReadStringEndian(br);
			x = br.ReadInt32();
			y = br.ReadInt32();
			width = br.ReadInt32();
			height = br.ReadInt32();
			borderLeft = br.ReadInt32();
			borderRight = br.ReadInt32();
			borderTop = br.ReadInt32();
			borderBottom = br.ReadInt32();
			paddingLeft = br.ReadInt32();
			paddingRight = br.ReadInt32();
			paddingTop = br.ReadInt32();
			paddingBottom = br.ReadInt32();
		}

		public void Save(BinaryWriter bw)
        {
			WriteStringEndian(bw, name);
			bw.Write(x);
			bw.Write(y);
			bw.Write(width);
			bw.Write(height);
			bw.Write(borderLeft);
			bw.Write(borderRight);
			bw.Write(borderTop);
			bw.Write(borderBottom);
			bw.Write(paddingLeft);
			bw.Write(paddingRight);
			bw.Write(paddingTop);
			bw.Write(paddingBottom);
		}
	}
}
