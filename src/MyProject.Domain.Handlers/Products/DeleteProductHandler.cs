﻿using System;
using System.Threading.Tasks;
using Kledex.Commands;
using Kledex.Domain;
using MyProject.Domain.Models.Products;
using MyProject.Domain.Models.Products.Commands;

namespace MyProject.Domain.Handlers.Products
{
    public class DeleteProductHandler : ICommandHandlerAsync<DeleteProduct>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(DeleteProduct command)
        {
            var product = await _repository.GetByIdAsync(command.AggregateRootId);

            if (product == null)
            {
                throw new ApplicationException($"Product not found. Id: {command.AggregateRootId}");
            }

            product.Delete();

            return new CommandResponse
            {
                Events = product.Events
            };
        }
    }
}
