using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace GiftShop.Application.Features.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Request
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            Type myType = request.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                _logger.LogInformation("{Property} : {@Value}", prop.Name, prop.GetValue(request, null));
            }
            var response = await next();
            //Response
            string message = $"Handled {typeof(TResponse).Name}";
            _logger.LogInformation(message);
            return response;
        }
    }
}