using Dapper;
using IsubuSatis.IndirimService.Models;
using Npgsql;
using System.Data;

namespace IsubuSatis.IndirimService.Services
{
	public class MyIndirimService : IIndirimService
	{

		private readonly IDbConnection dbConnection;

		public MyIndirimService(IConfiguration configuration)
		{
			var constr = configuration.GetConnectionString("Default");
			dbConnection = new NpgsqlConnection(constr);
		}

		public async Task<List<Indirim>> GetAllIndirim()
		{
			var sonuc = await dbConnection
				.QueryAsync<Indirim>("select * from indirim");

			return sonuc.ToList();

		}

		public async Task<Indirim> GetById(int id)
		{
			var sonuc = await  dbConnection
				.QueryAsync<Indirim>("select * from indirim where id=@Id",
				new
				{
					Id = id
				});

			return sonuc.FirstOrDefault();
		}

		public async Task Guncelle(Indirim indirim)
		{
			var sonuc = await dbConnection
				.ExecuteAsync("update indirim set UserId = @UserId, Oran = @Oran, Kod= @Kod, IsActive=@IsActive",
			   indirim);
		}

		public async Task Kaydet(Indirim indirim)
		{
			var sonuc = await dbConnection
				 .ExecuteAsync("insert into indirim (UserId,Oran,Kod,IsActive) values (@UserId,@Oran,@Kod,@IsActive)",
				indirim);
		}

		public async Task Sil(int id)
		{
			var sonuc = await dbConnection.ExecuteAsync("delete from indirim where id=@Id",
				new
				{
					Id = id
				});
		}
	}
}
