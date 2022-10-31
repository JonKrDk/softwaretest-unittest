using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookApp.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
        public string? Publisher { get; set; }
        public double Price { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Title={Title}, Author={Author}, NumberOfPages={NumberOfPages}, Publisher={Publisher}, Price={Price}, ISBN={ISBN}, Category={Category}, Created={Created}";
        }
    }
}
