using System;

namespace Construlink.Data
{
    public class LayoutUpdateService
    {
        public event Action OnLayoutUpdateRequested;

        public void RequestLayoutUpdate()
        {
            OnLayoutUpdateRequested?.Invoke();
        }
    }
}
