using System;
using Kledex.Domain;
using MyProject.Domain.Models.Products.Events;

namespace MyProject.Domain.Models.Products
{
    public class Product : AggregateRoot
    {
        public string Name { get; set; }
        public ProductStatus Status { get; set; }

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

        public void UpdateName(string name)
        {
            AddAndApplyEvent(new ProductNameUpdated
            {
                AggregateRootId = Id,
                Name = name
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

        private void Apply(ProductNameUpdated @event)
        {
            Name = @event.Name;
        }

        private void Apply(ProductWithdrew @event)
        {
            Status = ProductStatus.Draft;
        }
    }
}
