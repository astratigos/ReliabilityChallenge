using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ReliabilityChallenge.Models
{
    public class Request : IRequest<Response>
    {
        [Key]
        public int Id { get; set; }
    }
}
