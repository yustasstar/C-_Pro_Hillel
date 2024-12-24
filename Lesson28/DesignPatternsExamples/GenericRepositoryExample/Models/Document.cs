﻿using MongoDB.Bson;
using System;

namespace GenericRepositoryExample.Models
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
