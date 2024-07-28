using System;
namespace Iterator
{
    public interface IChannelCollection
    {
        void AddChannel(Channel c);
        void RemoveChannel(Channel c);
        IChannelIterator CreateIterator();
    }
}

