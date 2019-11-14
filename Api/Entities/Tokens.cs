using System;

namespace Api.Entities
{
    public class Tokens:BaseEntity
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredUTC { get; set; }
    }
}