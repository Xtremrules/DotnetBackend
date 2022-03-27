﻿namespace DotnetBackend.Core.Entity.Abstract
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
