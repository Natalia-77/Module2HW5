using System;
using Module2HW5.Exceptions;
using Module2HW5.Service.Abstractions;

namespace Module2HW5
{
    public class Actions
    {
        private readonly ILogger _logger;

        public Actions(ILogger logger)
        {
            _logger = logger;
        }

        public bool First()
        {
            _logger.Info($"Start method: {nameof(First)} ");
            return true;
        }

        public void Second()
        {
            throw new BusinessException($"Skipped logic in method: {nameof(Second)} ");
        }

        public void Third()
        {
            throw new Exception($"I broke a logic: {nameof(Third)}");
        }
    }
}
