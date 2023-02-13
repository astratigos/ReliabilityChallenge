using System.ComponentModel.DataAnnotations;

namespace ReliabilityChallenge.Models
{
    public class Response
    {
        [Key]
        public int Id { get; set; }

        public int RequestId { get; set; }
    }
}
