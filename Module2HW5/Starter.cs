using System;
using Module2HW5.Exceptions;
using Module2HW5.Service.Abstractions;

namespace Module2HW5
{
    public class Starter
    {
        private readonly Actions _actions;
        private readonly ILogger _logger;
        private readonly Random _rand;

        public Starter(Actions actions, ILogger logger)
        {
            _actions = actions;
            _logger = logger;
            _rand = new Random();
        }

        public void RunActions()
        {
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    var a = _rand.Next(1, 4);

                    switch (a)
                    {
                        case 0:
                            _actions.First();
                            break;
                        case 1:
                            _actions.Second();
                            break;
                        case 2:
                            _actions.Third();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    _logger.Warning($"Action got this custom Exception : {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.Error($"Action failed by reason: {ex.Message}");
                }
            }
        }
    }
}
