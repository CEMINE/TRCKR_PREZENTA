using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TableAttribute = SQLite.TableAttribute;

namespace Prezenta_4.Data
{
	[Table("Materie")]
	public class Materie
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
