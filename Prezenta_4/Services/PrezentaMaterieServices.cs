using Prezenta_4.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Prezenta_4.Services
{
	public class PrezentaMaterieServices : IPrezentaMaterie
	{
		public SQLiteAsyncConnection _db;
		string _dbPath;

		public PrezentaMaterieServices(string dbPath)
		{
			_dbPath = dbPath;
		}

		private async Task InitAsync()
		{
			if (_db != null) { return; }
			_db = new SQLiteAsyncConnection(_dbPath);
			await _db.CreateTableAsync<PrezentaMaterie>();
		}

		public async Task<bool> AddUpdatePrezentaAsync(PrezentaMaterie pCurs)
		{
			await InitAsync();
			if (pCurs.Id > 0)
			{
				await _db.UpdateAsync(pCurs);
			}
			else
			{
				await _db.InsertAsync(pCurs);
			}
			return await Task.FromResult(true);
		}

		public async Task<bool> DeletePrezentaAsync(int prezentaCursId)
		{
			await InitAsync();
			await _db.DeleteAsync<PrezentaMaterie>(prezentaCursId);
			return await Task.FromResult(true);
		}

		public async Task<IEnumerable<PrezentaMaterie>> GetPrezentaCursAsync(bool tipPrezenta, int idMaterie)
		{
			await InitAsync();
			//return await _db.Table<PrezentaMaterie>().Where(p => p.Id == prezentaCursId).Where(k => k.Id == materieId).Where(z => z.isCurs == true).FirstOrDefaultAsync();
			//return await _db.Table<PrezentaMaterie>().Where(p => p.Id == prezentaId).FirstOrDefaultAsync();
			//return await Task.FromResult(await _db.Table<PrezentaMaterie>().Where(p => p.isCurs == tipPrezenta).Where(z => z.MaterieId == idMaterie));
			//return await _db.QueryAsync<PrezentaMaterie>("Select * Where isCurs = ? And MaterieId = ? From ?", tipPrezenta , idMaterie);
			return await _db.Table<PrezentaMaterie>().Where(x => x.isCurs == tipPrezenta).Where(p => p.MaterieId == idMaterie).ToListAsync();


		}

		public async Task<IEnumerable<PrezentaMaterie>> GetAllPrezenteAsync(int idMaterie)
		{
			await InitAsync();
			return await _db.Table<PrezentaMaterie>().Where(p => p.MaterieId == idMaterie).ToListAsync();
		}

		public async Task<PrezentaMaterie> GetPrezentaAsync(int prezentaId)
		{
			await InitAsync();
			return await _db.Table<PrezentaMaterie>().Where(p => p.Id == prezentaId).FirstOrDefaultAsync();
		}

	}
}
