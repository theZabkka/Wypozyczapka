using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Application.Messages
{
    public class BooksChangedMessage : ValueChangedMessage<bool>
    {
        public BooksChangedMessage(bool value) : base(value) { }
    }
}