using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Todos_los_items_del_Indec
{
    public class PDFPath
    {

		private string filePath;

		public string FilePath
		{
			get { return filePath; }
			set { filePath = value; }
		}

		private int firstPage;

		public int FirstPage
		{
			get { return firstPage; }
			set { firstPage = value; }
		}

		private int lastPage;

		public int LastPage
		{
			get { return lastPage; }
			set { lastPage = value; }
		}

		private string text;

		public string Text
		{
			get { return text; }
			set { text = value; }
		}

		public string GetPath()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				filePath = openFileDialog.FileName;
			}

			return filePath;
		}
	}
}