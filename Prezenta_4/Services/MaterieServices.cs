using Prezenta_4.Data;
using SQLite;

namespace Prezenta_4.Services
{
	public class MaterieServices : IMaterieService
	{
		public SQLiteAsyncConnection _db;
		string _dbPath;


		public MaterieServices(string dbPath)
		{
			_dbPath = dbPath;
		}

		private async Task InitAsync()
		{
			if (_db != null) { return; }
			_db = new SQLiteAsyncConnection(_dbPath);
			await _db.CreateTableAsync<Materie>();
		}


		public async Task<bool> AddUpdateMaterieAsync(Materie materie)
		{
			await InitAsync();
			if (materie.Id > 0)
			{
				await _db.UpdateAsync(materie);
			}
			else
			{
				await _db.InsertAsync(materie);
			}
			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteMaterieAsync(int materieId)
		{
			await InitAsync();
			await _db.DeleteAsync<Materie>(materieId);
			await _db.DeleteAsync<PrezentaMaterie>(materieId);
			return await Task.FromResult(true);
		}

		public async Task<Materie> GetMaterieAsync(int materieId)
		{
			await InitAsync();
			return await _db.Table<Materie>().Where(p => p.Id == materieId).FirstOrDefaultAsync(); ;
		}

		public async Task<IEnumerable<Materie>> GetMateriiAsync()
		{
			await InitAsync();
			return await Task.FromResult(await _db.Table<Materie>().ToListAsync());
		}

		public async Task<string> GetMaterieNameAsync(int materieId)
		{
			var data = await _db.Table<Materie>().Where(p => p.Id == materieId).FirstOrDefaultAsync();
			return data.Name.ToString();

		}
	}
}
