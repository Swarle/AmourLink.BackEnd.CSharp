﻿using AmourLink.Infrastructure.Data.Abstract;

namespace AmourLink.Swipe.Data.Entities;

public class Like : Entity
{
    public Guid UserSentId { get; set; }
    public Guid UserReceiverId { get; set; }
    public LikeType LikeType { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public enum LikeType
{
    DefaultLike,
    SuperLike,
    LikeWithMessage
}