namespace IsubuSatis.OdemeApi.Models
{
	public class OdemeDto
	{
		public string KartAdi { get; set; }
		public string KartNumarasi { get; set; }
		public string Ay { get; set; }
		public string Yil { get; set; }
		public string Cv2 { get; set; }
		public decimal ToplamTutar { get; set; }

		public SiparisDto Siparis { get; set; }
	}
}
