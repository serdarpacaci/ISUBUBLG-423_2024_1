using IsubuSatis.Shared.Mesajlar;
using MassTransit;

namespace IsubuSatis.Siparis.Application.Consumers
{
    public class SiparisOlusturMessageCommandConsumer 
        : IConsumer<SiparisOlusturMessageCommand>
    {
        public Task Consume(ConsumeContext<SiparisOlusturMessageCommand> context)
        {
            var message = context.Message;

            return Task.CompletedTask;
        }
    }
}
