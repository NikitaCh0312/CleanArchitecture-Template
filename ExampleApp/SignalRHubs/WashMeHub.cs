namespace BackendWashMe.SignalRHubs
{
    using ApplicationServices;
    using Entities;
    using MediatR;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Threading.Tasks;

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public partial class WashMeHub: Hub
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        private readonly IMessageReceiversCreatorService _messageReceiversCreatorService;

        public WashMeHub(IMediator mediator,
                         UserManager<User> userManager,
                         IMessageReceiversCreatorService messageReceiversCreatorService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _messageReceiversCreatorService = messageReceiversCreatorService ?? throw new ArgumentNullException(nameof(messageReceiversCreatorService));
        }


        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            await Clients.User(userId).SendAsync("InitializationResponse", "initialization response");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
