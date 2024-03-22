using System;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting;

namespace MvcBlog.Models
{
    [MetadataTypeAttribute(typeof(BlogMetadata))]
    public  class BlogMetadata
    {
                    [Display(Name = "Tên")]
            [Required(ErrorMessage = "Tên không được để trống")]
            [MaxLength(50, ErrorMessage = "Tên không được quá 50 ký tự")]
            public string Name;


            [Display(Name = "Mô tả")]
            [Required(ErrorMessage = "Mô tả không được đê trống")]
            [MaxLength(500, ErrorMessage = "Mô tả không được quá 500 ký tự")]
            public string Description;

            [Display(Name = "Chủ sở hữu")]
            [Required(ErrorMessage = "Chủ sở hữu không được để trống")]
            [MaxLength(50, ErrorMessage = "Chủ sở hữu không được quá 50 ký tự")]
            public string Owner;

            [Display(Name = "Xếp hạng")]
            [Range(1, 100, ErrorMessage = "Xếp loại chỉ có giá trị từ 1 đến 100")]
            [RegularExpression("^[0-9]*$", ErrorMessage = "Chỉ nhập số cho xếp loại")]
            public int Rank;
        }

    public  class PostMetadata
    {
        
            [MinLength(5, ErrorMessage = "Tiêu đề phải từ 5 đến 50 ký tự")]
            [MaxLength(50, ErrorMessage = "Tiêu đề phải từ 5 đến 50 ký tự")]
            [Required(ErrorMessage = "Tiêu đề không được để trống")]
            [Display(Name = "Tiêu đề")]
            public string Title { get; set; }

            [MinLength(10, ErrorMessage = "Nội dung phải từ 10 đến 500 ký tự")]
            [MaxLength(500, ErrorMessage = "Nội dung phải từ 10 đến 500 ký tự")]
            [Display(Name = "Nội dung")]
            [Required(ErrorMessage = "Nội dung không được để trống")]
            public string Content { get; set; }

            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Ngày tạo")]
            [Required(ErrorMessage = "Ngày tạo không được để trống")]
            public DateTime CreateDate { get; set; }

            [Required(ErrorMessage = "BlogID không được để trống")]
            [Range(1, int.MaxValue, ErrorMessage = "BlogID không thể bằng 0")]
            [Display(Name = "BlogID")]
            public int BlogID { get; set; }
        }
    }


