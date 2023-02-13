using Prezenta_4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezenta_4.Services
{
	public interface IMaterieService
	{
		Task<bool> AddUpdateMaterieAsync(Materie materie);
		Task<bool> DeleteMaterieAsync(int materieId);
		Task<Materie> GetMaterieAsync(int materieId);
		Task<IEnumerable<Materie>> GetMateriiAsync();
		Task<string> GetMaterieNameAsync(int materieId);
	}
}
