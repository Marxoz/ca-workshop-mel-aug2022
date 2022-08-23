namespace CaWorkshop.Application.Services.Messaging;

public interface IMessagingService
{
    public bool SendMessage(MessageDto message);
}