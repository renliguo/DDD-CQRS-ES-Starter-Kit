﻿using System;
using System.Threading.Tasks;
using Kledex.Commands;
using Kledex.Domain;

namespace MyProject.Domain.Products.Commands.Handlers
{
    public class WithdrawProductHandler : ICommandHandlerAsync<WithdrawProduct>
    {
        private readonly IRepository<Product> _repository;

        public WithdrawProductHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WithdrawProduct command)
        {
            var product = await _repository.GetByIdAsync(command.AggregateRootId);

            if (product == null)
            {
                throw new ApplicationException($"Product not found. Id: {command.AggregateRootId}");
            }

            product.Withdraw();

            return new CommandResponse
            {
                Events = product.Events
            };
        }
    }
}
