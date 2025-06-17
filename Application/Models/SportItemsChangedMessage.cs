using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Application.Messages
{
    public class SportItemsChangedMessage : ValueChangedMessage<bool>
    {
        public SportItemsChangedMessage(bool value) : base(value) { }
    }
}