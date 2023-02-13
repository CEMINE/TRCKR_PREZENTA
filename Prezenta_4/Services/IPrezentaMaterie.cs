using Prezenta_4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezenta_4.Services
{
	public interface IPrezentaMaterie
	{
		Task<bool> AddUpdatePrezentaAsync(PrezentaMaterie pCurs);
		Task<bool> DeletePrezentaAsync(int prezentaCursId);
		Task<IEnumerable<PrezentaMaterie>> GetPrezentaCursAsync(bool tipPrezenta, int materieId);
		//Task<IEnumerable<PrezentaMaterie>> GetPrezentaSeminarAsync(int materieId);
		Task<IEnumerable<PrezentaMaterie>> GetAllPrezenteAsync(int idMaterie);
		Task<PrezentaMaterie> GetPrezentaAsync(int prezentaId);

	}
}
