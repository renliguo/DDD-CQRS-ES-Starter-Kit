using System;
using Kledex.Domain;
using MyProject.Domain.Products.Events;

namespace MyProject.Domain.Products
{
    public class Product : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public ProductStatus Status { get; private set; }

        public Product()
        {
        }

        public Product(Guid id, string name)
        {
            AddAndApplyEvent(new ProductCreated
            {
                AggregateRootId = id,
                Name = name,
                Status = ProductStatus.Draft
            });
        }

        public void UpdateDetails(string name, string description, decimal price)
        {
            AddAndApplyEvent(new ProductDetailsUpdated
            {
                AggregateRootId = Id,
                Name = name,
                Description = description,
                Price = price
            });
        }

        public void Publish()
        {
            AddAndApplyEvent(new ProductPublished
            {
                AggregateRootId = Id
            });
        }

        public void Withdraw()
        {
            AddAndApplyEvent(new ProductWithdrew
            {
                AggregateRootId = Id
            });
        }

        public void Delete()
        {
            AddAndApplyEvent(new ProductDeleted
            {
                AggregateRootId = Id
            });
        }

        private void Apply(ProductCreated @event)
        {
            Id = @event.AggregateRootId;
            Name = @event.Name;
            Status = @event.Status;
        }

        private void Apply(ProductDeleted @event)
        {
            Status = ProductStatus.Deleted;
        }

        private void Apply(ProductPublished @event)
        {
            Status = ProductStatus.Published;
        }

        private void Apply(ProductDetailsUpdated @event)
        {
            Name = @event.Name;
            Description = @event.Description;
            Price = @event.Price;
        }

        private void Apply(ProductWithdrew @event)
        {
            Status = ProductStatus.Draft;
        }
    }
}
