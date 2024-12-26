using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Shared.Mesajlar
{
	public class SiparisOlusturMessageCommand
	{
		public SiparisOlusturMessageCommand()
		{
			SiparisItems = new List<SiparisDto>();
		}

		public string UserId { get; set; }

		public List<SiparisDto> SiparisItems { get; set; }

		public string Sehir { get; set; }
		public string Ilce { get; set; }
		public string Mahalle { get; set; }
		public string Cadde { get; set; }
		public string BinaNo { get; set; }
		public string DaireNo { get; set; }
	}

	public class SiparisDto
	{
		public Guid UrunId { get; set; }
		public string UrunAdi { get; set; }
		public string UrunImageUrl { get; set; }
		public decimal Fiyat { get; set; }
	}
}
