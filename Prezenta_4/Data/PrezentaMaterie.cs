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
	[Table("PrezentaMaterie")]
	public class PrezentaMaterie
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[Indexed]
		public int MaterieId { get; set; }
		public DateTime Date { get; set; }
		public bool isCurs { get; set; }

	}
}
