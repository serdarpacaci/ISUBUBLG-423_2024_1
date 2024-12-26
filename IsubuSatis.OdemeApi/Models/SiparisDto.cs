namespace IsubuSatis.OdemeApi.Models
{
	public class SiparisDto
	{
		public SiparisDto()
		{
			SiparisUrunleri = new List<SiparisItemDto>();
		}

		public string UserId { get; set; }

		public List<SiparisItemDto> SiparisUrunleri { get; set; }

		public AddressDto Address { get; set; }
	}

}
