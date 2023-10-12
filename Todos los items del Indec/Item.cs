using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Todos_los_items_del_Indec
{
    public class Item
    {
		private string id;

		public string ID
		{
			get { return id; }
			set { id = value; }
		}


		private string codeCPC;

		public string CodeCPC
		{
			get { return codeCPC; }
			set { codeCPC = value; }
		}

		private string description;

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		private string worth;

		public string Worth
		{
			get { return worth; }
			set { worth = value; }
		}

		public void Insert()
		{

		}
		public void Edit()
		{

		}

		public void Delete()
		{

		}

		public static List<Item> tolist()
		{
			List<Item> list = new List<Item>();
			Access access = new Access();
			access.Open();

			string SQL = "SELECT Id, CodigoCPC, Descripcion, Valor FROM worksheet$";

			SqlDataReader reader = access.Reader(SQL);

			while (reader.Read())
			{
				Item item = new Item();

				item.id = reader["Id"].ToString();
				item.codeCPC = reader["CodigoCPC"].ToString();
				item.description = reader["Descripcion"].ToString();
				item.worth = reader["Valor"].ToString();
				list.Add(item);
			}

			reader.Close();
			access.Close();
			return list;
		}
	}
}