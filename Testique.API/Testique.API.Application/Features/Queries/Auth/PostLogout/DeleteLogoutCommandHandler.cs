﻿using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Testique.API.Application.Features.Queries.Auth.PostLogout;

public class DeleteLogoutCommandHandler(SignInManager<IdentityUser> signInManager)
    : IRequestHandler<DeleteLogoutCommand>
{
    public async Task Handle(DeleteLogoutCommand request, CancellationToken cancellationToken)
        => await signInManager.SignOutAsync();
}