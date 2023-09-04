using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Todos_los_items_del_Indec
{
    public class TXTPath
    {

		private string archive;

		public string Archive
		{
			get { return archive; }
			set { archive = value; }
		}

		private string archivePath;

		public string ArchivePath
		{
			get { return archivePath; }
			set { archivePath = value; }
		}

		private string line = null;

		public string Line
		{
			get { return line; }
			set { line = value; }
		}

		private int lineNumber;

		public int LineNumber
		{
			get { return lineNumber; }
			set { lineNumber = value; }
		}

		public string SaveFileTXT()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
                if(File.Exists(saveFileDialog.FileName))
				{

				}

				archive = saveFileDialog.FileName;
            }

			return archive;
		}

		public string GetPath()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				archivePath = openFileDialog.FileName;
			}

			return archivePath;
		}

	}
}