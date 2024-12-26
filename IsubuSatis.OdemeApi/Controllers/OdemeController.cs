using IsubuSatis.OdemeApi.Models;
using IsubuSatis.Shared.Mesajlar;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.OdemeApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OdemeController : ControllerBase
	{
		private readonly ISendEndpointProvider _sendEndpointProvider;

		public OdemeController(ISendEndpointProvider sendEndpointProvider)
		{
			_sendEndpointProvider = sendEndpointProvider;
		}



		[HttpPost]
		public async Task<IActionResult> OdemeAl(OdemeDto input)
		{
			//Ödeme işlemi gerçekleştirilecek
			var result = OdemeIsleminiYap(input);
			if (result)
			{
				var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:siparis-olustur-service"));

				var siparisOlusturMessage = new SiparisOlusturMessageCommand();

				siparisOlusturMessage.UserId = input.Siparis.UserId;
				siparisOlusturMessage.Sehir = input.Siparis.Address.Sehir;
				siparisOlusturMessage.BinaNo = input.Siparis.Address.BinaNo;
				siparisOlusturMessage.Mahalle = input.Siparis.Address.Mahalle;
				siparisOlusturMessage.Cadde = input.Siparis.Address.Cadde;
				siparisOlusturMessage.DaireNo = input.Siparis.Address.DaireNo;

				input.Siparis.SiparisUrunleri.ForEach(x =>
				{
					siparisOlusturMessage.SiparisItems.Add(new Shared.Mesajlar.SiparisDto
					{
						Fiyat = x.Fiyat,
						UrunAdi = x.UrunAdi,
						UrunId = x.UrunId,
						UrunImageUrl = x.UrunImageUrl
					});
				});

				await sendEndpoint.Send<SiparisOlusturMessageCommand>(siparisOlusturMessage);
			}

			return Ok();
		}

		private bool OdemeIsleminiYap(OdemeDto input)
		{
			return true;
		}
	}
}
