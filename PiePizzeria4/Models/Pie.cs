using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiePizzeria.Models
{
    public class Pie
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name must be specified")]
        [StringLength(25, ErrorMessage = "Name must be between 5 and 25 characters", MinimumLength = 5)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = true)]
        [StringLength(50, ErrorMessage = "Short Description cannot be more than 50 characters")]
        public string ShortDescription { get; set; }
        [Required(AllowEmptyStrings = true)]
        [StringLength(1000, ErrorMessage = "Long Description cannot be more than 1000 characters")]
        public string LongDescription { get; set; }
        [Required(ErrorMessage = "The Price must be specified")]
        public decimal Price { get; set; }
        //[Required(AllowEmptyStrings = true)]
        //public string ImageUrl { get; set; }
        //[Required(AllowEmptyStrings = true)]
        //public string ImageThumbnailUrl { get; set; }
        public byte[] Image { get; set; }
        public string ImageContentType { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public string GetInlineImageSrc()
        {
            if (Image == null || ImageContentType == null)
                return null;

            var base64Image = System.Convert.ToBase64String(Image);
            return $"data:{ImageContentType};base64,{base64Image}";
        }

        public void SetImage(Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (file == null)
                return;

            ImageContentType = file.ContentType;

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);
                Image = stream.ToArray();
            }
        }
    }
}