using System;

namespace GuestBookApp.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; }

        protected BaseEntity() => Id = new Guid();
    }
}